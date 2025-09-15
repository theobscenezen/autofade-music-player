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
        btnOpenFolder.Location = new System.Drawing.Point(12, 431);
        btnOpenFolder.Name = "btnOpenFolder";
        btnOpenFolder.Size = new System.Drawing.Size(46, 46);
        btnOpenFolder.TabIndex = 2;
        btnOpenFolder.UseVisualStyleBackColor = true;
        btnOpenFolder.Click += button1_Click;
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(73, 447);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(95, 26);
        label1.TabIndex = 3;
        label1.Text = "Current Path:";
        // 
        // label2
        // 
        label2.Location = new System.Drawing.Point(150, 447);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(536, 28);
        label2.TabIndex = 4;
        label2.Text = "(Choose a folder)";
        // 
        // btnPlay
        // 
        btnPlay.Image = ((System.Drawing.Image)resources.GetObject("btnPlay.Image"));
        btnPlay.Location = new System.Drawing.Point(458, 343);
        btnPlay.Name = "btnPlay";
        btnPlay.Size = new System.Drawing.Size(46, 46);
        btnPlay.TabIndex = 5;
        btnPlay.UseVisualStyleBackColor = true;
        // 
        // btnPause
        // 
        btnPause.Image = ((System.Drawing.Image)resources.GetObject("btnPause.Image"));
        btnPause.Location = new System.Drawing.Point(406, 343);
        btnPause.Name = "btnPause";
        btnPause.Size = new System.Drawing.Size(46, 46);
        btnPause.TabIndex = 6;
        btnPause.UseVisualStyleBackColor = true;
        // 
        // btnPrevious
        // 
        btnPrevious.Image = ((System.Drawing.Image)resources.GetObject("btnPrevious.Image"));
        btnPrevious.Location = new System.Drawing.Point(354, 343);
        btnPrevious.Name = "btnPrevious";
        btnPrevious.Size = new System.Drawing.Size(46, 46);
        btnPrevious.TabIndex = 7;
        btnPrevious.UseVisualStyleBackColor = true;
        // 
        // btnNext
        // 
        btnNext.Image = ((System.Drawing.Image)resources.GetObject("btnNext.Image"));
        btnNext.Location = new System.Drawing.Point(562, 343);
        btnNext.Name = "btnNext";
        btnNext.Size = new System.Drawing.Size(46, 46);
        btnNext.TabIndex = 8;
        btnNext.UseVisualStyleBackColor = true;
        // 
        // btnAutofadeNext
        // 
        btnAutofadeNext.Image = ((System.Drawing.Image)resources.GetObject("btnAutofadeNext.Image"));
        btnAutofadeNext.Location = new System.Drawing.Point(614, 343);
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
        btnStop.Location = new System.Drawing.Point(510, 343);
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
        listBoxPlaylist.Size = new System.Drawing.Size(958, 289);
        listBoxPlaylist.TabIndex = 14;
        // 
        // chckInstantPlayback
        // 
        chckInstantPlayback.Location = new System.Drawing.Point(12, 495);
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
        lblAutofade.Location = new System.Drawing.Point(684, 330);
        lblAutofade.Name = "lblAutofade";
        lblAutofade.Size = new System.Drawing.Size(262, 20);
        lblAutofade.TabIndex = 17;
        lblAutofade.Text = "Autofade duration in ms (3000 = 3 seconds)";
        // 
        // textBoxAutofade
        // 
        textBoxAutofade.Location = new System.Drawing.Point(697, 353);
        textBoxAutofade.MaxLength = 32;
        textBoxAutofade.Name = "textBoxAutofade";
        textBoxAutofade.Size = new System.Drawing.Size(234, 23);
        textBoxAutofade.TabIndex = 18;
        textBoxAutofade.Text = "3000";
        // 
        // btnAutofadePrev
        // 
        btnAutofadePrev.Image = ((System.Drawing.Image)resources.GetObject("btnAutofadePrev.Image"));
        btnAutofadePrev.Location = new System.Drawing.Point(302, 343);
        btnAutofadePrev.Name = "btnAutofadePrev";
        btnAutofadePrev.Size = new System.Drawing.Size(46, 46);
        btnAutofadePrev.TabIndex = 19;
        btnAutofadePrev.UseVisualStyleBackColor = true;
        // 
        // lblOscPrefix
        // 
        lblOscPrefix.AutoSize = true;
        lblOscPrefix.Location = new System.Drawing.Point(684, 399);
        lblOscPrefix.Name = "lblOscPrefix";
        lblOscPrefix.Size = new System.Drawing.Size(66, 15);
        lblOscPrefix.TabIndex = 20;
        lblOscPrefix.Text = "OSC Prefix:";
        // 
        // textBoxOscPrefix
        // 
        textBoxOscPrefix.Location = new System.Drawing.Point(697, 417);
        textBoxOscPrefix.Name = "textBoxOscPrefix";
        textBoxOscPrefix.Size = new System.Drawing.Size(100, 23);
        textBoxOscPrefix.TabIndex = 21;
        textBoxOscPrefix.Text = "player";
        // 
        // MainForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(958, 540);
        Controls.Add(textBoxOscPrefix);
        Controls.Add(lblOscPrefix);
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

    #endregion
}