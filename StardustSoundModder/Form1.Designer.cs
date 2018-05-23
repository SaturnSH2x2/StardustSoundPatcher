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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stardustSoundPatcherToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startTimeInput = new System.Windows.Forms.TextBox();
            this.lengthInput = new System.Windows.Forms.TextBox();
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
            this.menuStrip1.Size = new System.Drawing.Size(303, 24);
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
            // startTimeInput
            // 
            this.startTimeInput.Location = new System.Drawing.Point(121, 67);
            this.startTimeInput.Name = "startTimeInput";
            this.startTimeInput.Size = new System.Drawing.Size(170, 20);
            this.startTimeInput.TabIndex = 1;
            this.startTimeInput.Text = "00:00:00";
            this.startTimeInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lengthInput
            // 
            this.lengthInput.Location = new System.Drawing.Point(121, 93);
            this.lengthInput.Name = "lengthInput";
            this.lengthInput.Size = new System.Drawing.Size(170, 20);
            this.lengthInput.TabIndex = 2;
            this.lengthInput.Text = "00:00:00";
            this.lengthInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
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
            this.playButton.Location = new System.Drawing.Point(12, 133);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(129, 23);
            this.playButton.TabIndex = 5;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(149, 133);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(142, 23);
            this.stopButton.TabIndex = 6;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
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
            // 
            // patchChangesButton
            // 
            this.patchChangesButton.Location = new System.Drawing.Point(12, 163);
            this.patchChangesButton.Name = "patchChangesButton";
            this.patchChangesButton.Size = new System.Drawing.Size(279, 23);
            this.patchChangesButton.TabIndex = 9;
            this.patchChangesButton.Text = "Patch Changes";
            this.patchChangesButton.UseVisualStyleBackColor = true;
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
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 197);
            this.Controls.Add(this.patchChangesButton);
            this.Controls.Add(this.file31Radio);
            this.Controls.Add(this.file30Radio);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.lengthLabel);
            this.Controls.Add(this.startTimeLabel);
            this.Controls.Add(this.lengthInput);
            this.Controls.Add(this.startTimeInput);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Stardust Sound Patcher";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.TextBox startTimeInput;
        private System.Windows.Forms.TextBox lengthInput;
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
    }
}

