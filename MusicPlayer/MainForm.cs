using System.Net;
using System.Net.Sockets;
using CoreOSC;
using CoreOSC.IO;
using NAudio.Wave;

namespace MusicPlayer;

public partial class MainForm : Form
{
    private const float FadeDurationMsDefault = 3000;
    private string _folderName = string.Empty;

    private readonly List<string> _playlist = new();
    private readonly BindingSource _playlistBinding = new();

    private readonly object _fadeLock = new();

    private Thread oscListenerThread;
    private bool oscRunning = false;
    private const int OscPort = 9000;

    private int _currentIndex;
    private bool _isFading = false;

    private WaveOutEvent? _outputDeviceCurrent;
    private AudioFileReader? _audioReaderCurrent;

    private WaveOutEvent? _outputDeviceNext;
    private AudioFileReader? _audioReaderNext;

    public MainForm()
    {
        InitializeComponent();
        volumeSlider.ValueChanged += VolumeSlider_ValueChanged;

        var toolTip = new ToolTip();

        btnPlay.Click += BtnPlay_Click;
        btnPause.Click += BtnPause_Click;
        btnPrevious.Click += BtnPrevious_Click;
        btnNext.Click += BtnNext_Click;
        btnAutofadeNext.Click += BtnAutofadeNext_Click;
        btnAutofadePrev.Click += BtnAutofadePrev_Click;
        btnStop.Click += BtnStop_Click;

        toolTip.SetToolTip(btnPlay, "Start/Restart track from 0");
        toolTip.SetToolTip(btnPause, "Pause or resume");
        toolTip.SetToolTip(btnPrevious, "Previous track");
        toolTip.SetToolTip(btnNext, "Next track");
        toolTip.SetToolTip(btnAutofadeNext, "Autofade to next track");
        toolTip.SetToolTip(btnAutofadePrev, "Autofade to previous track");
        toolTip.SetToolTip(btnStop, "Stop playback");
        toolTip.SetToolTip(btnOpenFolder, "Load folder with tracks");

        textBoxAutofade.KeyPress += TextBoxAutofade_KeyPress;

        listBoxPlaylist.SelectedIndexChanged += ListBoxPlaylist_SelectedIndexChanged;
        listBoxPlaylist.DoubleClick += ListBoxPlaylist_SelectedIndexChangedDouble;

        textBoxOscPrefix.TextChanged += TextBoxOscPrefix_TextChanged;

        InitializeOscListener();
    }

    private void InitializeOscListener()
    {
        oscRunning = true;

        oscListenerThread = new Thread(async void () =>
        {
            try
            {
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, OscPort);
                using var udpClient = new UdpClient(endPoint);
                while (oscRunning)
                {
                    try
                    {
                        var response = await udpClient.ReceiveMessageAsync();
                        HandleOscMessage(response);
                        Console.WriteLine($"Received OSC message: {response.Address.Value}");
                    }
                    catch (SocketException ex)
                    {
                        // ignore if closed
                        if (oscRunning) Console.WriteLine($"OSC socket error: {ex.Message}");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in OSC listener thread:");
                Console.WriteLine(e.Message);
            }
        })
        {
            IsBackground = true
        };

        oscListenerThread.Start();
    }

    private void TextBoxOscPrefix_TextChanged(object? sender, EventArgs e)
    {
        // Ensure the prefix is not empty
        if (string.IsNullOrWhiteSpace(textBoxOscPrefix.Text))
        {
            textBoxOscPrefix.Text = "player";
        }
    }

    private void HandleOscMessage(OscMessage msg)
    {
        string address = msg.Address.Value.ToLowerInvariant();
        string currentPrefix = textBoxOscPrefix.Text.ToLowerInvariant();
        string expectedPrefix = $"/{currentPrefix}/";

        if (!address.StartsWith(expectedPrefix))
        {
            Console.WriteLine($"Ignoring OSC message with wrong prefix: {address}");
            return;
        }

        string command = address.Substring(expectedPrefix.Length);

        // Use Invoke to safely call UI-related methods
        BeginInvoke((MethodInvoker)(() =>
        {
            switch (command)
            {
                case "play":
                    PlayCurrent();
                    break;

                case "pause":
                    Pause();
                    break;

                case "next":
                    PlayNext();
                    break;

                case "prev":
                case "previous":
                    PlayPrevious();
                    break;

                case "next_autofade":
                    AutofadeToNext();
                    break;

                case "prev_autofade":
                    AutofadeToPrevious();
                    break;

                default:
                    break;
            }
        }));
    }

    private void TextBoxAutofade_KeyPress(object? sender, KeyPressEventArgs e)
    {
        e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
    }

    private void PreselectTrackAtIndex(int selectedIndex)
    {
        if (selectedIndex >= 0 && selectedIndex < _playlist.Count)
        {
            _currentIndex = selectedIndex;
            if (chckInstantPlayback.Checked)
            {
                PlayCurrent();
            }
        }
    }

    private void PlayTrackAtIndex(int selectedIndex)
    {
        if (selectedIndex >= 0 && selectedIndex < _playlist.Count)
        {
            _currentIndex = selectedIndex;
            PlayCurrent();
        }
    }

    private void BindPlaylist()
    {
        _playlistBinding.DataSource = _playlist.Select(Path.GetFileName).ToList();
        listBoxPlaylist.DataSource = _playlistBinding;
    }

    private void button1_Click(object sender, EventArgs e)
    {
        // Show the FolderBrowserDialog.
        DialogResult result = folderBrowserDialog1.ShowDialog();
        if (result == DialogResult.OK)
        {
            _folderName = folderBrowserDialog1.SelectedPath;
            label2.Text = _folderName;
            FetchFilesFromFolder();
            BindPlaylist();
        }
    }

    private void FetchFilesFromFolder()
    {
        _playlist.Clear();
        var files = Directory.GetFiles(_folderName, "*", SearchOption.TopDirectoryOnly);

        var validExtensions = new[] { ".mp3", ".wav", ".ogg" };
        foreach (var file in files)
        {
            if (validExtensions.Contains(Path.GetExtension(file)))
            {
                _playlist.Add(file);
            }
        }
    }

    private void PlayCurrent()
    {
        DisposeCurrentPlayback();

        if (_playlist.Count == 0 || _currentIndex >= _playlist.Count) return;

        _audioReaderCurrent = new AudioFileReader(_playlist[_currentIndex]);
        _outputDeviceCurrent = new WaveOutEvent();
        _outputDeviceCurrent.Init(_audioReaderCurrent);
        _audioReaderCurrent.Volume = volumeSlider.Value / 100f;

        _outputDeviceCurrent.Play();
        listBoxPlaylist.SelectedIndex = _currentIndex;
    }

    private void DisposeCurrentPlayback()
    {
        _outputDeviceCurrent?.Stop();
        _outputDeviceCurrent?.Dispose();
        _audioReaderCurrent?.Dispose();
        _outputDeviceCurrent = null;
        _audioReaderCurrent = null;

        _outputDeviceNext?.Stop();
        _outputDeviceNext?.Dispose();
        _audioReaderNext?.Dispose();
        _outputDeviceNext = null;
        _audioReaderNext = null;
    }

    private void Pause()
    {
        if (_outputDeviceCurrent?.PlaybackState == PlaybackState.Playing)
            _outputDeviceCurrent.Pause();
        else if (_outputDeviceCurrent?.PlaybackState is PlaybackState.Paused)
            _outputDeviceCurrent.Play();
    }

    private void PlayPrevious()
    {
        if (_currentIndex > 0) _currentIndex--;
        PlayCurrent();
    }

    private void PlayNext()
    {
        if (_currentIndex < _playlist.Count - 1) _currentIndex++;
        PlayCurrent();
    }

    private void VolumeSlider_ValueChanged(object? sender, EventArgs e)
    {
        SetVolume(volumeSlider.Value);
        lblVolume.Text = $"{volumeSlider.Value}%";
    }

    private void SetVolume(int volume)
    {
        if (_audioReaderCurrent != null)
        {
            _audioReaderCurrent.Volume = volume / 100f;
        }
    }

    private async Task AutofadeToNext()
    {
        if (_currentIndex >= _playlist.Count - 1)
            return;

        int nextIndex = _currentIndex + 1;

        await AutofadeToIndex(nextIndex);
    }


    private async Task AutofadeToPrevious()
    {
        if (_currentIndex == 0)
            return;

        int nextIndex = _currentIndex - 1;

        await AutofadeToIndex(nextIndex);
    }

    private async Task AutofadeToIndex(int nextIndex)
    {
        if (_isFading)
            return;

        _isFading = true;

        try
        {
            lock (_fadeLock) // Synchronize access to playback transition
            {
                if (_audioReaderNext != null || _outputDeviceNext != null)
                {
                    // A fade is already running
                    Console.WriteLine("Fade already in progress. Ignoring.");
                    return;
                }

                if (nextIndex < 0 || nextIndex >= _playlist.Count)
                {
                    Console.WriteLine("Invalid next index.");
                    return;
                }

                try
                {
                    _audioReaderNext = new AudioFileReader(_playlist[nextIndex]);
                    _outputDeviceNext = new WaveOutEvent();
                    _outputDeviceNext.Init(_audioReaderNext);
                    _audioReaderNext.Volume = 0f;
                    _outputDeviceNext.Play();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error starting next track: {ex.Message}");
                    return;
                }
            }

            // Crossfade outside of lock to avoid blocking OSC listener
            int steps = 30;
            float stepDuration = GetFadeDuration() / steps;
            float targetVolume = volumeSlider.Value / 100f;
            if (_audioReaderCurrent != null)
            {
                float currentVol = _audioReaderCurrent.Volume;

                for (int i = 0; i <= steps; i++)
                {
                    float fadeOutVol = currentVol * (1 - i / (float)steps);
                    float fadeInVol = targetVolume * (i / (float)steps);

                    _audioReaderCurrent.Volume = fadeOutVol;
                    _audioReaderNext.Volume = fadeInVol;

                    await Task.Delay((int)stepDuration);
                }
            }

            // Finalize and clean up (under lock)
            lock (_fadeLock)
            {
                _outputDeviceCurrent?.Stop();
                _outputDeviceCurrent?.Dispose();
                _audioReaderCurrent?.Dispose();

                _outputDeviceCurrent = _outputDeviceNext;
                _audioReaderCurrent = _audioReaderNext;
                _outputDeviceNext = null;
                _audioReaderNext = null;

                _currentIndex = nextIndex;
                listBoxPlaylist.SelectedIndex = _currentIndex;
            }
        }
        finally
        {
            _isFading = false;
        }
    }

    private float GetFadeDuration()
    {
        var isNumeric = int.TryParse(textBoxAutofade.Text, out int duration);
        if (!isNumeric)
        {
            return FadeDurationMsDefault;
        }

        return duration;
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
        DisposeCurrentPlayback();
        oscRunning = false;
        base.OnFormClosing(e);
    }

    private void ListBoxPlaylist_SelectedIndexChanged(object? sender, EventArgs e) =>
        PreselectTrackAtIndex(listBoxPlaylist.SelectedIndex);

    private void ListBoxPlaylist_SelectedIndexChangedDouble(object? sender, EventArgs e) =>
        PlayTrackAtIndex(listBoxPlaylist.SelectedIndex);

    private void BtnPlay_Click(object? sender, EventArgs e) => PlayCurrent();

    private void BtnStop_Click(object? sender, EventArgs e) => DisposeCurrentPlayback();

    private void BtnPause_Click(object? sender, EventArgs e) => Pause();
    private void BtnPrevious_Click(object? sender, EventArgs e) => PlayPrevious();
    private void BtnNext_Click(object? sender, EventArgs e) => PlayNext();
    private async void BtnAutofadeNext_Click(object? sender, EventArgs e) => await AutofadeToNext();
    private async void BtnAutofadePrev_Click(object? sender, EventArgs e) => await AutofadeToPrevious();
}