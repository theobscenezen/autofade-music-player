namespace MusicPlayer;

partial class MainForm
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
        btnOpenFolder = new System.Windows.Forms.Button();
        label1 = new System.Windows.Forms.Label();
        label2 = new System.Windows.Forms.Label();
        btnPlay = new System.Windows.Forms.Button();
        btnPause = new System.Windows.Forms.Button();
        btnPrevious = new System.Windows.Forms.Button();
        btnNext = new System.Windows.Forms.Button();
        btnAutofadeNext = new System.Windows.Forms.Button();
        volumeSlider = new System.Windows.Forms.TrackBar();
        lblVol = new System.Windows.Forms.Label();
        btnStop = new System.Windows.Forms.Button();
        listBoxPlaylist = new System.Windows.Forms.ListBox();
        chckInstantPlayback = new System.Windows.Forms.CheckBox();
        lblVolume = new System.Windows.Forms.Label();
        lblAutofade = new System.Windows.Forms.Label();
        textBoxAutofade = new System.Windows.Forms.TextBox();
        btnAutofadePrev = new System.Windows.Forms.Button();
        lblOscPrefix = new System.Windows.Forms.Label();
        textBoxOscPrefix = new System.Windows.Forms.TextBox();
        btnStartOscListener = new System.Windows.Forms.Button();
        comboBoxOutputDevices = new System.Windows.Forms.ComboBox();
        lblOutputDevice = new System.Windows.Forms.Label();
        textBoxOscPort = new System.Windows.Forms.TextBox();
        lblOscPort = new System.Windows.Forms.Label();
        btnStopOscListener = new System.Windows.Forms.Button();
        lblOscRunning = new System.Windows.Forms.Label();
        lblPlaybackStatus = new System.Windows.Forms.Label();
        lblTrackTime = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)volumeSlider).BeginInit();
        SuspendLayout();
        // 
        // folderBrowserDialog1
        // 
        folderBrowserDialog1.Description = "Select the directory that includes the playlist files.";
        folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyDocuments;
        folderBrowserDialog1.ShowNewFolderButton = false;
        // 
        // btnOpenFolder
        // 
        btnOpenFolder.Image = ((System.Drawing.Image)resources.GetObject("btnOpenFolder.Image"));
        btnOpenFolder.Location = new System.Drawing.Point(14, 397);
        btnOpenFolder.Name = "btnOpenFolder";
        btnOpenFolder.Size = new System.Drawing.Size(46, 46);
        btnOpenFolder.TabIndex = 2;
        btnOpenFolder.UseVisualStyleBackColor = true;
        btnOpenFolder.Click += button1_Click;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(75, 413);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(95, 26);
        label1.TabIndex = 3;
        label1.Text = "Current Path:";
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(157, 413);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(399, 28);
        label2.TabIndex = 4;
        label2.Text = "(Choose a folder)";
        // 
        // btnPlay
        // 
        btnPlay.Image = ((System.Drawing.Image)resources.GetObject("btnPlay.Image"));
        btnPlay.Location = new System.Drawing.Point(405, 352);
        btnPlay.Name = "btnPlay";
        btnPlay.Size = new System.Drawing.Size(46, 46);
        btnPlay.TabIndex = 5;
        btnPlay.UseVisualStyleBackColor = true;
        // 
        // btnPause
        // 
        btnPause.Image = ((System.Drawing.Image)resources.GetObject("btnPause.Image"));
        btnPause.Location = new System.Drawing.Point(353, 352);
        btnPause.Name = "btnPause";
        btnPause.Size = new System.Drawing.Size(46, 46);
        btnPause.TabIndex = 6;
        btnPause.UseVisualStyleBackColor = true;
        // 
        // btnPrevious
        // 
        btnPrevious.Image = ((System.Drawing.Image)resources.GetObject("btnPrevious.Image"));
        btnPrevious.Location = new System.Drawing.Point(301, 352);
        btnPrevious.Name = "btnPrevious";
        btnPrevious.Size = new System.Drawing.Size(46, 46);
        btnPrevious.TabIndex = 7;
        btnPrevious.UseVisualStyleBackColor = true;
        // 
        // btnNext
        // 
        btnNext.Image = ((System.Drawing.Image)resources.GetObject("btnNext.Image"));
        btnNext.Location = new System.Drawing.Point(509, 352);
        btnNext.Name = "btnNext";
        btnNext.Size = new System.Drawing.Size(46, 46);
        btnNext.TabIndex = 8;
        btnNext.UseVisualStyleBackColor = true;
        // 
        // btnAutofadeNext
        // 
        btnAutofadeNext.Image = ((System.Drawing.Image)resources.GetObject("btnAutofadeNext.Image"));
        btnAutofadeNext.Location = new System.Drawing.Point(509, 301);
        btnAutofadeNext.Name = "btnAutofadeNext";
        btnAutofadeNext.Size = new System.Drawing.Size(46, 46);
        btnAutofadeNext.TabIndex = 9;
        btnAutofadeNext.UseVisualStyleBackColor = true;
        // 
        // volumeSlider
        // 
        volumeSlider.Location = new System.Drawing.Point(14, 353);
        volumeSlider.Maximum = 100;
        volumeSlider.Name = "volumeSlider";
        volumeSlider.Size = new System.Drawing.Size(215, 45);
        volumeSlider.TabIndex = 10;
        volumeSlider.Value = 100;
        // 
        // lblVol
        // 
        lblVol.Location = new System.Drawing.Point(14, 327);
        lblVol.Name = "lblVol";
        lblVol.Size = new System.Drawing.Size(100, 23);
        lblVol.TabIndex = 11;
        lblVol.Text = "Volume";
        // 
        // btnStop
        // 
        btnStop.Image = ((System.Drawing.Image)resources.GetObject("btnStop.Image"));
        btnStop.Location = new System.Drawing.Point(457, 352);
        btnStop.Name = "btnStop";
        btnStop.Size = new System.Drawing.Size(46, 46);
        btnStop.TabIndex = 12;
        btnStop.UseVisualStyleBackColor = true;
        // 
        // listBoxPlaylist
        // 
        listBoxPlaylist.Dock = System.Windows.Forms.DockStyle.Top;
        listBoxPlaylist.FormattingEnabled = true;
        listBoxPlaylist.ItemHeight = 15;
        listBoxPlaylist.Location = new System.Drawing.Point(0, 0);
        listBoxPlaylist.Name = "listBoxPlaylist";
        listBoxPlaylist.Size = new System.Drawing.Size(806, 289);
        listBoxPlaylist.TabIndex = 14;
        // 
        // chckInstantPlayback
        // 
        chckInstantPlayback.Location = new System.Drawing.Point(14, 461);
        chckInstantPlayback.Name = "chckInstantPlayback";
        chckInstantPlayback.Size = new System.Drawing.Size(113, 21);
        chckInstantPlayback.TabIndex = 15;
        chckInstantPlayback.Text = "Instant Playback";
        chckInstantPlayback.UseVisualStyleBackColor = true;
        // 
        // lblVolume
        // 
        lblVolume.Location = new System.Drawing.Point(235, 359);
        lblVolume.Name = "lblVolume";
        lblVolume.Size = new System.Drawing.Size(38, 19);
        lblVolume.TabIndex = 16;
        lblVolume.Text = "100%";
        // 
        // lblAutofade
        // 
        lblAutofade.Location = new System.Drawing.Point(562, 301);
        lblAutofade.Name = "lblAutofade";
        lblAutofade.Size = new System.Drawing.Size(262, 20);
        lblAutofade.TabIndex = 17;
        lblAutofade.Text = "Autofade duration in ms (3000 = 3 seconds)";
        // 
        // textBoxAutofade
        // 
        textBoxAutofade.Location = new System.Drawing.Point(575, 324);
        textBoxAutofade.MaxLength = 32;
        textBoxAutofade.Name = "textBoxAutofade";
        textBoxAutofade.Size = new System.Drawing.Size(99, 23);
        textBoxAutofade.TabIndex = 18;
        textBoxAutofade.Text = "3000";
        // 
        // btnAutofadePrev
        // 
        btnAutofadePrev.Image = ((System.Drawing.Image)resources.GetObject("btnAutofadePrev.Image"));
        btnAutofadePrev.Location = new System.Drawing.Point(301, 301);
        btnAutofadePrev.Name = "btnAutofadePrev";
        btnAutofadePrev.Size = new System.Drawing.Size(46, 46);
        btnAutofadePrev.TabIndex = 19;
        btnAutofadePrev.UseVisualStyleBackColor = true;
        // 
        // lblOscPrefix
        // 
        lblOscPrefix.AutoSize = true;
        lblOscPrefix.Location = new System.Drawing.Point(562, 370);
        lblOscPrefix.Name = "lblOscPrefix";
        lblOscPrefix.Size = new System.Drawing.Size(66, 15);
        lblOscPrefix.TabIndex = 20;
        lblOscPrefix.Text = "OSC Prefix:";
        // 
        // textBoxOscPrefix
        // 
        textBoxOscPrefix.Location = new System.Drawing.Point(575, 388);
        textBoxOscPrefix.Name = "textBoxOscPrefix";
        textBoxOscPrefix.Size = new System.Drawing.Size(99, 23);
        textBoxOscPrefix.TabIndex = 21;
        textBoxOscPrefix.Text = "player";
        // 
        // btnStartOscListener
        // 
        btnStartOscListener.Location = new System.Drawing.Point(680, 382);
        btnStartOscListener.Name = "btnStartOscListener";
        btnStartOscListener.Size = new System.Drawing.Size(95, 37);
        btnStartOscListener.TabIndex = 22;
        btnStartOscListener.Text = "Start OSC";
        btnStartOscListener.UseVisualStyleBackColor = true;
        // 
        // comboBoxOutputDevices
        // 
        comboBoxOutputDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        comboBoxOutputDevices.FormattingEnabled = true;
        comboBoxOutputDevices.Location = new System.Drawing.Point(135, 462);
        comboBoxOutputDevices.Name = "comboBoxOutputDevices";
        comboBoxOutputDevices.Size = new System.Drawing.Size(300, 23);
        comboBoxOutputDevices.TabIndex = 28;
        // 
        // lblOutputDevice
        // 
        lblOutputDevice.Location = new System.Drawing.Point(135, 439);
        lblOutputDevice.Name = "lblOutputDevice";
        lblOutputDevice.Size = new System.Drawing.Size(120, 23);
        lblOutputDevice.TabIndex = 27;
        lblOutputDevice.Text = "Output Device:";
        // 
        // textBoxOscPort
        // 
        textBoxOscPort.Location = new System.Drawing.Point(575, 446);
        textBoxOscPort.Name = "textBoxOscPort";
        textBoxOscPort.Size = new System.Drawing.Size(99, 23);
        textBoxOscPort.TabIndex = 23;
        textBoxOscPort.Text = "9000";
        // 
        // lblOscPort
        // 
        lblOscPort.AutoSize = true;
        lblOscPort.Location = new System.Drawing.Point(562, 428);
        lblOscPort.Name = "lblOscPort";
        lblOscPort.Size = new System.Drawing.Size(58, 15);
        lblOscPort.TabIndex = 24;
        lblOscPort.Text = "OSC Port:";
        // 
        // btnStopOscListener
        // 
        btnStopOscListener.Location = new System.Drawing.Point(680, 432);
        btnStopOscListener.Name = "btnStopOscListener";
        btnStopOscListener.Size = new System.Drawing.Size(95, 37);
        btnStopOscListener.TabIndex = 25;
        btnStopOscListener.Text = "Stop OSC";
        btnStopOscListener.UseVisualStyleBackColor = true;
        // 
        // lblOscRunning
        // 
        lblOscRunning.Location = new System.Drawing.Point(509, 472);
        lblOscRunning.Name = "lblOscRunning";
        lblOscRunning.Size = new System.Drawing.Size(383, 27);
        lblOscRunning.TabIndex = 26;
        lblOscRunning.Text = "OSC listener waiting for start.";
        // 
        // lblPlaybackStatus
        // 
        lblPlaybackStatus.AutoSize = true;
        lblPlaybackStatus.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
        lblPlaybackStatus.Location = new System.Drawing.Point(14, 295);
        lblPlaybackStatus.Name = "lblPlaybackStatus";
        lblPlaybackStatus.Size = new System.Drawing.Size(54, 15);
        lblPlaybackStatus.TabIndex = 29;
        lblPlaybackStatus.Text = "Stopped";
        // 
        // lblTrackTime
        // 
        lblTrackTime.AutoSize = true;
        lblTrackTime.Location = new System.Drawing.Point(120, 295);
        lblTrackTime.Name = "lblTrackTime";
        lblTrackTime.Size = new System.Drawing.Size(60, 15);
        lblTrackTime.TabIndex = 30;
        lblTrackTime.Text = "0:00 / 0:00";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(806, 503);
        Controls.Add(lblTrackTime);
        Controls.Add(lblPlaybackStatus);
        Controls.Add(lblOscRunning);
        Controls.Add(btnStopOscListener);
        Controls.Add(lblOscPort);
        Controls.Add(textBoxOscPort);
        Controls.Add(btnStartOscListener);
        Controls.Add(textBoxOscPrefix);
        Controls.Add(lblOscPrefix);
        Controls.Add(comboBoxOutputDevices);
        Controls.Add(lblOutputDevice);
        Controls.Add(btnAutofadePrev);
        Controls.Add(textBoxAutofade);
        Controls.Add(lblAutofade);
        Controls.Add(lblVolume);
        Controls.Add(chckInstantPlayback);
        Controls.Add(listBoxPlaylist);
        Controls.Add(btnStop);
        Controls.Add(lblVol);
        Controls.Add(volumeSlider);
        Controls.Add(btnAutofadeNext);
        Controls.Add(btnNext);
        Controls.Add(btnPrevious);
        Controls.Add(btnPause);
        Controls.Add(btnPlay);
        Controls.Add(label2);
        Controls.Add(label1);
        Controls.Add(btnOpenFolder);
        Text = "Autofade music player";
        ((System.ComponentModel.ISupportInitialize)volumeSlider).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label lblPlaybackStatus;
    private System.Windows.Forms.Label lblTrackTime;

    private System.Windows.Forms.Label lblOscRunning;

    private System.Windows.Forms.Button btnStopOscListener;

    private System.Windows.Forms.Button btnStartOscListener;
    private System.Windows.Forms.TextBox textBoxOscPort;
    private System.Windows.Forms.Label lblOscPort;

    private System.Windows.Forms.Button btnAutofadePrev;

    private System.Windows.Forms.Label lblAutofade;
    private System.Windows.Forms.TextBox textBoxAutofade;

    private System.Windows.Forms.Label lblVolume;

    private System.Windows.Forms.CheckBox chckInstantPlayback;

    private System.Windows.Forms.ListBox listBoxPlaylist;

    private System.Windows.Forms.Button btnStop;

    private System.Windows.Forms.TrackBar volumeSlider;
    private System.Windows.Forms.Label lblVol;

    private System.Windows.Forms.Button btnPlay;
    private System.Windows.Forms.Button btnPause;
    private System.Windows.Forms.Button btnPrevious;
    private System.Windows.Forms.Button btnNext;
    private System.Windows.Forms.Button btnAutofadeNext;

    private System.Windows.Forms.Label label2;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.Button btnOpenFolder;

    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;

    private System.Windows.Forms.Label lblOscPrefix;
    private System.Windows.Forms.TextBox textBoxOscPrefix;

    private System.Windows.Forms.ComboBox comboBoxOutputDevices;
    private System.Windows.Forms.Label lblOutputDevice;

    #endregion
}

