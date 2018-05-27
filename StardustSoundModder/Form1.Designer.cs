namespace StardustSoundModder
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stardustSoundPatcherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startTimeMinute = new System.Windows.Forms.TextBox();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.lengthLabel = new System.Windows.Forms.Label();
            this.playButton = new System.Windows.Forms.Button();
            this.stopButton = new System.Windows.Forms.Button();
            this.file30Radio = new System.Windows.Forms.RadioButton();
            this.file31Radio = new System.Windows.Forms.RadioButton();
            this.patchChangesButton = new System.Windows.Forms.Button();
            this.loadSoundPatchCtrlOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportSoundPatchCtrlSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patchChangesCtrlSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadSoundButton = new System.Windows.Forms.Button();
            this.startTimeSecond = new System.Windows.Forms.TextBox();
            this.startTimeMs = new System.Windows.Forms.TextBox();
            this.lengthMinute = new System.Windows.Forms.TextBox();
            this.lengthSecond = new System.Windows.Forms.TextBox();
            this.lengthMs = new System.Windows.Forms.TextBox();
            this.colon1 = new System.Windows.Forms.Label();
            this.colon2 = new System.Windows.Forms.Label();
            this.colon3 = new System.Windows.Forms.Label();
            this.colon4 = new System.Windows.Forms.Label();
            this.minuteLabel = new System.Windows.Forms.Label();
            this.secondLabel = new System.Windows.Forms.Label();
            this.msLabel = new System.Windows.Forms.Label();
            this.samplingRateTB = new System.Windows.Forms.TextBox();
            this.samplingRateLabel = new System.Windows.Forms.Label();
            this.hzLabel = new System.Windows.Forms.Label();
            this.audioAmplifyTB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.patchList = new System.Windows.Forms.ListView();
            this.patchLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(537, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadSoundPatchCtrlOToolStripMenuItem,
            this.exportSoundPatchCtrlSToolStripMenuItem,
            this.patchChangesCtrlSToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stardustSoundPatcherToolStripMenuItem});
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // stardustSoundPatcherToolStripMenuItem
            // 
            this.stardustSoundPatcherToolStripMenuItem.Name = "stardustSoundPatcherToolStripMenuItem";
            this.stardustSoundPatcherToolStripMenuItem.Size = new System.Drawing.Size(197, 22);
            this.stardustSoundPatcherToolStripMenuItem.Text = "Stardust Sound Patcher";
            // 
            // startTimeMinute
            // 
            this.startTimeMinute.Location = new System.Drawing.Point(88, 67);
            this.startTimeMinute.Name = "startTimeMinute";
            this.startTimeMinute.Size = new System.Drawing.Size(53, 20);
            this.startTimeMinute.TabIndex = 1;
            this.startTimeMinute.Text = "0";
            this.startTimeMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.startTimeMinute.TextChanged += new System.EventHandler(this.startTimeMinute_TextChanged);
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.Location = new System.Drawing.Point(12, 67);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(58, 13);
            this.startTimeLabel.TabIndex = 3;
            this.startTimeLabel.Text = "Start Time:";
            // 
            // lengthLabel
            // 
            this.lengthLabel.AutoSize = true;
            this.lengthLabel.Location = new System.Drawing.Point(12, 93);
            this.lengthLabel.Name = "lengthLabel";
            this.lengthLabel.Size = new System.Drawing.Size(43, 13);
            this.lengthLabel.TabIndex = 4;
            this.lengthLabel.Text = "Length:";
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(12, 171);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(129, 23);
            this.playButton.TabIndex = 5;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(149, 171);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(142, 23);
            this.stopButton.TabIndex = 6;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // file30Radio
            // 
            this.file30Radio.AutoSize = true;
            this.file30Radio.Location = new System.Drawing.Point(16, 28);
            this.file30Radio.Name = "file30Radio";
            this.file30Radio.Size = new System.Drawing.Size(56, 17);
            this.file30Radio.TabIndex = 7;
            this.file30Radio.TabStop = true;
            this.file30Radio.Text = "File 30";
            this.file30Radio.UseVisualStyleBackColor = true;
            this.file30Radio.CheckedChanged += new System.EventHandler(this.file30Radio_CheckedChanged);
            // 
            // file31Radio
            // 
            this.file31Radio.AutoSize = true;
            this.file31Radio.Location = new System.Drawing.Point(149, 28);
            this.file31Radio.Name = "file31Radio";
            this.file31Radio.Size = new System.Drawing.Size(56, 17);
            this.file31Radio.TabIndex = 8;
            this.file31Radio.TabStop = true;
            this.file31Radio.Text = "File 31";
            this.file31Radio.UseVisualStyleBackColor = true;
            this.file31Radio.CheckedChanged += new System.EventHandler(this.file31Radio_CheckedChanged);
            // 
            // patchChangesButton
            // 
            this.patchChangesButton.Location = new System.Drawing.Point(12, 296);
            this.patchChangesButton.Name = "patchChangesButton";
            this.patchChangesButton.Size = new System.Drawing.Size(279, 23);
            this.patchChangesButton.TabIndex = 9;
            this.patchChangesButton.Text = "Patch Changes";
            this.patchChangesButton.UseVisualStyleBackColor = true;
            this.patchChangesButton.Click += new System.EventHandler(this.patchChangesButton_Click);
            // 
            // loadSoundPatchCtrlOToolStripMenuItem
            // 
            this.loadSoundPatchCtrlOToolStripMenuItem.Name = "loadSoundPatchCtrlOToolStripMenuItem";
            this.loadSoundPatchCtrlOToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.loadSoundPatchCtrlOToolStripMenuItem.Text = "Load Sound Patch... (Ctrl + O)";
            // 
            // exportSoundPatchCtrlSToolStripMenuItem
            // 
            this.exportSoundPatchCtrlSToolStripMenuItem.Name = "exportSoundPatchCtrlSToolStripMenuItem";
            this.exportSoundPatchCtrlSToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.exportSoundPatchCtrlSToolStripMenuItem.Text = "Export Sound Patch... (Ctrl + E)";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // patchChangesCtrlSToolStripMenuItem
            // 
            this.patchChangesCtrlSToolStripMenuItem.Name = "patchChangesCtrlSToolStripMenuItem";
            this.patchChangesCtrlSToolStripMenuItem.Size = new System.Drawing.Size(236, 22);
            this.patchChangesCtrlSToolStripMenuItem.Text = "Patch Changes (Ctrl + S)";
            this.patchChangesCtrlSToolStripMenuItem.Click += new System.EventHandler(this.patchChangesCtrlSToolStripMenuItem_Click);
            // 
            // loadSoundButton
            // 
            this.loadSoundButton.Location = new System.Drawing.Point(12, 267);
            this.loadSoundButton.Name = "loadSoundButton";
            this.loadSoundButton.Size = new System.Drawing.Size(279, 23);
            this.loadSoundButton.TabIndex = 10;
            this.loadSoundButton.Text = "Load Sound File...";
            this.loadSoundButton.UseVisualStyleBackColor = true;
            this.loadSoundButton.Click += new System.EventHandler(this.loadSoundButton_Click);
            // 
            // startTimeSecond
            // 
            this.startTimeSecond.Location = new System.Drawing.Point(163, 67);
            this.startTimeSecond.Name = "startTimeSecond";
            this.startTimeSecond.Size = new System.Drawing.Size(53, 20);
            this.startTimeSecond.TabIndex = 11;
            this.startTimeSecond.Text = "0";
            this.startTimeSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.startTimeSecond.TextChanged += new System.EventHandler(this.startTimeSecond_TextChanged);
            // 
            // startTimeMs
            // 
            this.startTimeMs.Location = new System.Drawing.Point(238, 67);
            this.startTimeMs.Name = "startTimeMs";
            this.startTimeMs.Size = new System.Drawing.Size(53, 20);
            this.startTimeMs.TabIndex = 12;
            this.startTimeMs.Text = "0";
            this.startTimeMs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.startTimeMs.TextChanged += new System.EventHandler(this.startTimeMs_TextChanged);
            // 
            // lengthMinute
            // 
            this.lengthMinute.Location = new System.Drawing.Point(88, 93);
            this.lengthMinute.Name = "lengthMinute";
            this.lengthMinute.Size = new System.Drawing.Size(53, 20);
            this.lengthMinute.TabIndex = 13;
            this.lengthMinute.Text = "0";
            this.lengthMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.lengthMinute.TextChanged += new System.EventHandler(this.lengthMinute_TextChanged);
            // 
            // lengthSecond
            // 
            this.lengthSecond.Location = new System.Drawing.Point(163, 93);
            this.lengthSecond.Name = "lengthSecond";
            this.lengthSecond.Size = new System.Drawing.Size(53, 20);
            this.lengthSecond.TabIndex = 14;
            this.lengthSecond.Text = "0";
            this.lengthSecond.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.lengthSecond.TextChanged += new System.EventHandler(this.lengthSecond_TextChanged);
            // 
            // lengthMs
            // 
            this.lengthMs.Location = new System.Drawing.Point(238, 93);
            this.lengthMs.Name = "lengthMs";
            this.lengthMs.Size = new System.Drawing.Size(53, 20);
            this.lengthMs.TabIndex = 15;
            this.lengthMs.Text = "0";
            this.lengthMs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.lengthMs.TextChanged += new System.EventHandler(this.lengthMs_TextChanged);
            // 
            // colon1
            // 
            this.colon1.AutoSize = true;
            this.colon1.Location = new System.Drawing.Point(147, 74);
            this.colon1.Name = "colon1";
            this.colon1.Size = new System.Drawing.Size(10, 13);
            this.colon1.TabIndex = 16;
            this.colon1.Text = ":";
            // 
            // colon2
            // 
            this.colon2.AutoSize = true;
            this.colon2.Location = new System.Drawing.Point(222, 74);
            this.colon2.Name = "colon2";
            this.colon2.Size = new System.Drawing.Size(10, 13);
            this.colon2.TabIndex = 17;
            this.colon2.Text = ":";
            // 
            // colon3
            // 
            this.colon3.AutoSize = true;
            this.colon3.Location = new System.Drawing.Point(147, 100);
            this.colon3.Name = "colon3";
            this.colon3.Size = new System.Drawing.Size(10, 13);
            this.colon3.TabIndex = 18;
            this.colon3.Text = ":";
            // 
            // colon4
            // 
            this.colon4.AutoSize = true;
            this.colon4.Location = new System.Drawing.Point(222, 100);
            this.colon4.Name = "colon4";
            this.colon4.Size = new System.Drawing.Size(10, 13);
            this.colon4.TabIndex = 19;
            this.colon4.Text = ":";
            // 
            // minuteLabel
            // 
            this.minuteLabel.AutoSize = true;
            this.minuteLabel.Location = new System.Drawing.Point(85, 51);
            this.minuteLabel.Name = "minuteLabel";
            this.minuteLabel.Size = new System.Drawing.Size(39, 13);
            this.minuteLabel.TabIndex = 20;
            this.minuteLabel.Text = "Minute";
            // 
            // secondLabel
            // 
            this.secondLabel.AutoSize = true;
            this.secondLabel.Location = new System.Drawing.Point(160, 51);
            this.secondLabel.Name = "secondLabel";
            this.secondLabel.Size = new System.Drawing.Size(44, 13);
            this.secondLabel.TabIndex = 21;
            this.secondLabel.Text = "Second";
            // 
            // msLabel
            // 
            this.msLabel.AutoSize = true;
            this.msLabel.Location = new System.Drawing.Point(235, 51);
            this.msLabel.Name = "msLabel";
            this.msLabel.Size = new System.Drawing.Size(59, 13);
            this.msLabel.TabIndex = 22;
            this.msLabel.Text = "Millisecond";
            // 
            // samplingRateTB
            // 
            this.samplingRateTB.Location = new System.Drawing.Point(131, 136);
            this.samplingRateTB.Name = "samplingRateTB";
            this.samplingRateTB.Size = new System.Drawing.Size(127, 20);
            this.samplingRateTB.TabIndex = 23;
            this.samplingRateTB.Text = "44100";
            this.samplingRateTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.samplingRateTB.TextChanged += new System.EventHandler(this.samplingRateTB_TextChanged);
            // 
            // samplingRateLabel
            // 
            this.samplingRateLabel.AutoSize = true;
            this.samplingRateLabel.Location = new System.Drawing.Point(16, 142);
            this.samplingRateLabel.Name = "samplingRateLabel";
            this.samplingRateLabel.Size = new System.Drawing.Size(79, 13);
            this.samplingRateLabel.TabIndex = 24;
            this.samplingRateLabel.Text = "Sampling Rate:";
            // 
            // hzLabel
            // 
            this.hzLabel.AutoSize = true;
            this.hzLabel.Location = new System.Drawing.Point(265, 142);
            this.hzLabel.Name = "hzLabel";
            this.hzLabel.Size = new System.Drawing.Size(20, 13);
            this.hzLabel.TabIndex = 25;
            this.hzLabel.Text = "Hz";
            // 
            // audioAmplifyTB
            // 
            this.audioAmplifyTB.Location = new System.Drawing.Point(144, 221);
            this.audioAmplifyTB.Name = "audioAmplifyTB";
            this.audioAmplifyTB.Size = new System.Drawing.Size(147, 20);
            this.audioAmplifyTB.TabIndex = 26;
            this.audioAmplifyTB.Text = "0.5";
            this.audioAmplifyTB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.audioAmplifyTB.TextChanged += new System.EventHandler(this.audioAmplifyTB_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 221);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Amplify imported audio by:";
            // 
            // patchList
            // 
            this.patchList.Location = new System.Drawing.Point(315, 51);
            this.patchList.Name = "patchList";
            this.patchList.Size = new System.Drawing.Size(210, 268);
            this.patchList.TabIndex = 28;
            this.patchList.UseCompatibleStateImageBehavior = false;
            // 
            // patchLabel
            // 
            this.patchLabel.AutoSize = true;
            this.patchLabel.Location = new System.Drawing.Point(315, 28);
            this.patchLabel.Name = "patchLabel";
            this.patchLabel.Size = new System.Drawing.Size(83, 13);
            this.patchLabel.TabIndex = 29;
            this.patchLabel.Text = "Sound Patches:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 338);
            this.Controls.Add(this.patchLabel);
            this.Controls.Add(this.patchList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.audioAmplifyTB);
            this.Controls.Add(this.hzLabel);
            this.Controls.Add(this.samplingRateLabel);
            this.Controls.Add(this.samplingRateTB);
            this.Controls.Add(this.msLabel);
            this.Controls.Add(this.secondLabel);
            this.Controls.Add(this.minuteLabel);
            this.Controls.Add(this.colon4);
            this.Controls.Add(this.colon3);
            this.Controls.Add(this.colon2);
            this.Controls.Add(this.colon1);
            this.Controls.Add(this.lengthMs);
            this.Controls.Add(this.lengthSecond);
            this.Controls.Add(this.lengthMinute);
            this.Controls.Add(this.startTimeMs);
            this.Controls.Add(this.startTimeSecond);
            this.Controls.Add(this.loadSoundButton);
            this.Controls.Add(this.patchChangesButton);
            this.Controls.Add(this.file31Radio);
            this.Controls.Add(this.file30Radio);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.lengthLabel);
            this.Controls.Add(this.startTimeLabel);
            this.Controls.Add(this.startTimeMinute);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Stardust Sound Patcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stardustSoundPatcherToolStripMenuItem;
        private System.Windows.Forms.TextBox startTimeMinute;
        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.Label lengthLabel;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.RadioButton file30Radio;
        private System.Windows.Forms.RadioButton file31Radio;
        private System.Windows.Forms.ToolStripMenuItem loadSoundPatchCtrlOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportSoundPatchCtrlSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button patchChangesButton;
        private System.Windows.Forms.ToolStripMenuItem patchChangesCtrlSToolStripMenuItem;
        private System.Windows.Forms.Button loadSoundButton;
        private System.Windows.Forms.TextBox startTimeSecond;
        private System.Windows.Forms.TextBox startTimeMs;
        private System.Windows.Forms.TextBox lengthMinute;
        private System.Windows.Forms.TextBox lengthSecond;
        private System.Windows.Forms.TextBox lengthMs;
        private System.Windows.Forms.Label colon1;
        private System.Windows.Forms.Label colon2;
        private System.Windows.Forms.Label colon3;
        private System.Windows.Forms.Label colon4;
        private System.Windows.Forms.Label minuteLabel;
        private System.Windows.Forms.Label secondLabel;
        private System.Windows.Forms.Label msLabel;
        private System.Windows.Forms.TextBox samplingRateTB;
        private System.Windows.Forms.Label samplingRateLabel;
        private System.Windows.Forms.Label hzLabel;
        private System.Windows.Forms.TextBox audioAmplifyTB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView patchList;
        private System.Windows.Forms.Label patchLabel;
    }
}

