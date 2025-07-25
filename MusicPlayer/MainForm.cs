using NAudio.Wave;

namespace MusicPlayer;

public partial class MainForm : Form
{
    private const float FadeDurationMsDefault = 3000;
    private string _folderName = string.Empty;

    private readonly List<string> _playlist = new();
    private readonly BindingSource _playlistBinding = new BindingSource();

    private int _currentIndex;

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
    }
    
    private void TextBoxAutofade_KeyPress(object? sender, KeyPressEventArgs e)
    {
        e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
    }
    
    private void ListBoxPlaylist_SelectedIndexChanged(object? sender, EventArgs e)
    {
        int selectedIndex = listBoxPlaylist.SelectedIndex;
        if (selectedIndex >= 0 && selectedIndex < _playlist.Count)
        {
            _currentIndex = selectedIndex;
            if (chckInstantPlayback.Checked)
            {
                PlayCurrent();
            }
        }
    }    
    private void ListBoxPlaylist_SelectedIndexChangedDouble(object? sender, EventArgs e)
    {
        int selectedIndex = listBoxPlaylist.SelectedIndex;
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

    private void BtnPlay_Click(object? sender, EventArgs e) => PlayCurrent();

    private void BtnStop_Click(object? sender, EventArgs e) => DisposeCurrentPlayback();

    private void BtnPause_Click(object? sender, EventArgs e)
    {
        if (_outputDeviceCurrent?.PlaybackState == PlaybackState.Playing)
            _outputDeviceCurrent.Pause();
        else if (_outputDeviceCurrent?.PlaybackState == PlaybackState.Paused)
            _outputDeviceCurrent.Play();
    }

    private void BtnPrevious_Click(object? sender, EventArgs e)
    {
        if (_currentIndex > 0) _currentIndex--;
        PlayCurrent();
    }

    private void BtnNext_Click(object? sender, EventArgs e)
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

    private async void BtnAutofadeNext_Click(object? sender, EventArgs e)
    {
        if (_currentIndex >= _playlist.Count - 1)
            return;

        int nextIndex = _currentIndex + 1;

        await AutofadeToIndex(nextIndex);
    }

    private async void BtnAutofadePrev_Click(object? sender, EventArgs e)
    {
        if (_currentIndex == 0)
            return;

        int nextIndex = _currentIndex - 1;

        await AutofadeToIndex(nextIndex);
    }

    private async Task AutofadeToIndex(int nextIndex)
    {
        // Load next song
        _audioReaderNext = new AudioFileReader(_playlist[nextIndex]);
        _outputDeviceNext = new WaveOutEvent();
        _outputDeviceNext.Init(_audioReaderNext);
        _audioReaderNext.Volume = 0f;
        _outputDeviceNext.Play();

        // Crossfade
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

        // Finalize switch
        _outputDeviceCurrent?.Stop();
        _outputDeviceCurrent?.Dispose();
        _audioReaderCurrent?.Dispose();

        // Move next to current
        _outputDeviceCurrent = _outputDeviceNext;
        _audioReaderCurrent = _audioReaderNext;
        _outputDeviceNext = null;
        _audioReaderNext = null;

        _currentIndex = nextIndex;
        listBoxPlaylist.SelectedIndex = _currentIndex;
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
        base.OnFormClosing(e);
    }
}