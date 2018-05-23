using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.WindowsAPICodePack.Dialogs;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace StardustSoundModder
{
    public partial class Form1 : Form
    {
        private WaveOutEvent outputDevice;

        private byte[] file30;
        private byte[] file31;
        private byte[] selectedAudio;

        private bool isFile30 = true;

        public Form1()
        {
            InitializeComponent();
        }

        private int timeToOffset(int minute, int second, int millisecond)
        {
            double totalSeconds = 0.0f;
            totalSeconds += (minute * 60);
            totalSeconds += second;
            totalSeconds += millisecond * 0.001;

            // number of seconds times samples per second to find the proper offset
            return (int)Math.Round(totalSeconds * Int32.Parse(samplingRateTB.Text));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CommonOpenFileDialog fbd = new CommonOpenFileDialog();
            fbd.Title = "Open extracted jojoban folder:";
            fbd.IsFolderPicker = true;
            fbd.InitialDirectory = "%HOMEPATH%";
            if (fbd.ShowDialog() != CommonFileDialogResult.Ok)
            {
                Application.Exit();
            }

            try
            {
                file30 = System.IO.File.ReadAllBytes(fbd.FileName + "\\30");
                file31 = System.IO.File.ReadAllBytes(fbd.FileName + "\\31");
            } catch (Exception ex)
            {
                MessageBox.Show("An exception occurred: " + ex.Message +
                                "\nPlease make sure you have all of your\n" +
                                "files in your jojoban folder, then restart\n" + 
                                "the program.");
                Application.Exit();
            }

            file30Radio.Select();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            stopButton_Click(sender, e);

            int startOffset = timeToOffset(Int32.Parse(startTimeMinute.Text), Int32.Parse(startTimeSecond.Text), Int32.Parse(startTimeMs.Text));
            int lengthBytes = timeToOffset(Int32.Parse(lengthMinute.Text), Int32.Parse(lengthSecond.Text), Int32.Parse(lengthMs.Text));

            selectedAudio = new byte[lengthBytes];

            for (int i = 0; i < lengthBytes; i++)
            {
                if (isFile30)
                    selectedAudio[i] = file30[i + startOffset];
                else
                    selectedAudio[i] = file31[i + startOffset];
            }

            var ms = new MemoryStream(selectedAudio);
            var rs = new RawSourceWaveStream(ms, new WaveFormat(Int32.Parse(samplingRateTB.Text), 1));

            outputDevice = new WaveOutEvent();
            outputDevice.Init(rs);
            outputDevice.Play();
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            outputDevice?.Stop();
            if (outputDevice != null)
            {
                outputDevice.Dispose();
                outputDevice = null;
            }
        }

        private void file31Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (file31Radio.Checked)
            {
                isFile30 = false;
            } else
            {
                isFile30 = true;
            }
        }

        private void file30Radio_CheckedChanged(object sender, EventArgs e)
        {
            file31Radio_CheckedChanged(sender, e);
        }
    }
}
