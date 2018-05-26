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

        private int prevSamplingRate = 44100;
        private int currentStartOffset = 0;
        private int currentLengthOffset = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private int timeToOffset(int minute, int second, int millisecond, int samplingRate = 0)
        {
            double totalSeconds = 0.0f;
            totalSeconds += (minute * 60);
            totalSeconds += second;
            totalSeconds += millisecond * 0.001;

            // number of seconds times samples per second to find the proper offset
            if (samplingRate == 0)
                return (int)Math.Round(totalSeconds * Int32.Parse(samplingRateTB.Text));
            else
                return (int)Math.Round(totalSeconds * samplingRate);
        }

        // recalculates current time offsets.  Useful for when the sampling rate changes and the times need to be recalculated.
        private void recalculateOffset()
        {
            currentStartOffset = timeToOffset(Int32.Parse(startTimeMinute.Text), Int32.Parse(startTimeSecond.Text), Int32.Parse(startTimeMs.Text));
            currentLengthOffset = timeToOffset(Int32.Parse(lengthMinute.Text), Int32.Parse(lengthSecond.Text), Int32.Parse(lengthMs.Text));
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

            selectedAudio = new byte[currentLengthOffset];

            for (int i = 0; i < currentLengthOffset; i++)
            {
                if (isFile30)
                    selectedAudio[i] = file30[i + currentStartOffset];
                else
                    selectedAudio[i] = file31[i + currentStartOffset];
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

        private void samplingRateTB_TextChanged(object sender, EventArgs e)
        {
            if (samplingRateTB.Text.Length == 0)
            {
                samplingRateTB.Text = "0";
                return;
            }

            int sampleRate;
            try
            {
                sampleRate = Int32.Parse(samplingRateTB.Text);
                if (sampleRate == 0)
                    return;
            } catch (FormatException)
            {
                samplingRateTB.Text = prevSamplingRate.ToString();
                return;
            } catch (OverflowException)
            {
                samplingRateTB.Text = prevSamplingRate.ToString();
                return;
            }

            double newStartTime = (float)currentStartOffset / (float)sampleRate;
            double newLengthTime = (float)currentLengthOffset / (float)sampleRate;

            int startMinute = (int)(newStartTime / 60);
            int startSecond = (int)(newStartTime % 60);
            int startMs = (int)(newStartTime % 1) * 100;

            startTimeMinute.Text = startMinute.ToString();
            startTimeSecond.Text = startSecond.ToString();
            startTimeMs.Text = startMs.ToString();

            int newLengthMinute = (int)(newLengthTime / 60);
            int newLengthSecond = (int)(newLengthTime % 60);
            int newLengthMs = (int)(newStartTime % 1 * 100);

            lengthMinute.Text = newLengthMinute.ToString();
            lengthSecond.Text = newLengthSecond.ToString();
            lengthMs.Text = newLengthMs.ToString();

            prevSamplingRate = sampleRate;
        }

        private void startTimeSecond_TextChanged(object sender, EventArgs e)
        {
            recalculateOffset();
        }

        private void startTimeMs_TextChanged(object sender, EventArgs e)
        {
            recalculateOffset();
        }

        private void startTimeMinute_TextChanged(object sender, EventArgs e)
        {
            recalculateOffset();
        }

        private void lengthMinute_TextChanged(object sender, EventArgs e)
        {
            recalculateOffset();
        }

        private void lengthSecond_TextChanged(object sender, EventArgs e)
        {
            recalculateOffset();
        }

        private void lengthMs_TextChanged(object sender, EventArgs e)
        {
            recalculateOffset();
        }
    }
}
