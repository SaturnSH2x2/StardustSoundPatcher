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
        enum WHICHFILE { FILE_30 = 0, FILE_31 = 1 };

        // private class for storing useful for data which will be stored in JSON files later on 
        private class audioPatch
        {
            public String fileName;
            public int startOffset;
            public int lengthOffset;
            public WHICHFILE f;

            public audioPatch(String fileName, int startOffset, int lengthOffset, WHICHFILE f)
            {
                this.fileName = fileName;
                this.startOffset = startOffset;
                this.lengthOffset = lengthOffset;
                this.f = f;
            }
        }

        private WaveOutEvent outputDevice;

        private byte[] file30;
        private byte[] file31;
        private byte[] selectedAudio;

        private bool isFile30 = true;

        private int prevSamplingRate = 44100;
        private int currentStartOffset = 0;
        private int currentLengthOffset = 0;

        float prevAmplification = 1.0f;

        private String workingDirectory;

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

        // function that converts an audio file into mono 8-bit PCM, at the current sampling rate
        private void formatAudio(String filePath)
        {
            // convert to mono
            var ir = new AudioFileReader(filePath);
            var mono = new StereoToMonoSampleProvider(ir);
            mono.LeftVolume = 0.0f;
            mono.RightVolume = float.Parse(audioAmplifyTB.Text);
            var resampler = new WdlResamplingSampleProvider(mono, Int32.Parse(samplingRateTB.Text));
            WaveFileWriter.CreateWaveFile16("temp.wav", resampler);
            ir.Close();

            //File.Delete("temp.wav");

        }

        // function to patch out sound data
        private void patchAudio(byte[] replacementData)
        {
            byte[] dataToReplace;
            if (isFile30)
                dataToReplace = file30;
            else
                dataToReplace = file31;
            for (int i = 0; i < currentLengthOffset; i++)
            {
                if (i >= replacementData.Length)
                    dataToReplace[i + currentStartOffset] = 0;
                else
                    dataToReplace[i + currentStartOffset] = replacementData[i];
            }
        }

        private void overwriteFiles()
        {
            System.IO.File.WriteAllBytes(workingDirectory + "\\30", file30);
            System.IO.File.WriteAllBytes(workingDirectory + "\\31", file31);
            MessageBox.Show("The sound files have been patched.");
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

            workingDirectory = fbd.FileName;
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
                try
                {
                    if (isFile30)
                        selectedAudio[i] = file30[i + currentStartOffset];
                    else
                        selectedAudio[i] = file31[i + currentStartOffset];
                } catch (IndexOutOfRangeException)
                {
                    MessageBox.Show("The start time/play length specified exceeds the length of the audio.");
                    return;
                }
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

        // TODO:  text boxes kinda suck here, use NumericUpDown in the future
        private void startTimeSecond_TextChanged(object sender, EventArgs e)
        {
            if (startTimeSecond.Text.Length == 0)
            {
                startTimeSecond.Text = "0";
            }

            try
            {
                Int32.Parse(startTimeSecond.Text);
            } catch (Exception)
            {
                samplingRateTB_TextChanged(sender, e);
            } 
            recalculateOffset();
        }

        private void startTimeMs_TextChanged(object sender, EventArgs e)
        {
            if (startTimeMs.Text.Length == 0)
            {
                startTimeMs.Text = "0";
            }

            try
            {
                Int32.Parse(startTimeMs.Text);
            } catch (Exception) {
                samplingRateTB_TextChanged(sender, e);
            } 
            recalculateOffset();
        }

        private void startTimeMinute_TextChanged(object sender, EventArgs e)
        {
            if (startTimeMinute.Text.Length == 0)
            {
                startTimeMinute.Text = "0";
            }

            try
            {
                Int32.Parse(startTimeMinute.Text);
            } catch (Exception)
            {
                samplingRateTB_TextChanged(sender, e);
            }
            recalculateOffset();
        }

        private void lengthMinute_TextChanged(object sender, EventArgs e)
        {
            if (lengthMinute.Text.Length == 0)
            {
                lengthMinute.Text = "0";
            }

            try
            {
                Int32.Parse(lengthMinute.Text);
            } catch (Exception)
            {
                samplingRateTB_TextChanged(sender, e);
            }
            recalculateOffset();
        }

        private void lengthSecond_TextChanged(object sender, EventArgs e)
        {
            if (lengthSecond.Text.Length == 0)
            {
                lengthSecond.Text = "0";
            }

            try
            {
                Int32.Parse(lengthSecond.Text);
            } catch (Exception)
            {
                samplingRateTB_TextChanged(sender, e);
            }
            recalculateOffset();
        }

        private void lengthMs_TextChanged(object sender, EventArgs e)
        {
            if (lengthMs.Text.Length == 0)
            {
                lengthMs.Text = "0";
            }

            try
            {
                Int32.Parse(lengthMs.Text);
            } catch(Exception)
            {
                samplingRateTB_TextChanged(sender, e);
            }
            recalculateOffset();
        }

        private void loadSoundButton_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog ofd = new CommonOpenFileDialog();
            ofd.RestoreDirectory = true;

            // format audio
            if (ofd.ShowDialog() == CommonFileDialogResult.Ok)
            {
                formatAudio(ofd.FileName);
            } else
            {
                return;
            }

            // get raw data
            Stream wavFile = new FileStream("temp.wav", FileMode.Open);
            BinaryReader br = new BinaryReader(wavFile);

            wavFile.Position = 44;
            byte[] audioData = new byte[(wavFile.Length - 44)];
            for (int i = 0; i < (wavFile.Length - 44); i += 2) {
                short sixteenBitSample = br.ReadInt16();
                audioData[i] = (byte)(sixteenBitSample >> 8);
                audioData[i + 1] = (byte)(sixteenBitSample >> 8);
            }

            br.Close();

            // patch data into the audio
            patchAudio(audioData);
        }

        private void audioAmplifyTB_TextChanged(object sender, EventArgs e)
        {
            if (audioAmplifyTB.Text.Length == 0)
            {
                audioAmplifyTB.Text = "0";
                return;
            }

            float amplification;
            try
            {
                amplification = float.Parse(audioAmplifyTB.Text);
            } catch (FormatException)
            {
                audioAmplifyTB.Text = prevAmplification.ToString();
                return;
            } catch (OverflowException)
            {
                audioAmplifyTB.Text = prevAmplification.ToString();
                return;
            }

            prevAmplification = amplification;
        }

        private void patchChangesButton_Click(object sender, EventArgs e)
        {
            overwriteFiles();
        }

        private void patchChangesCtrlSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            overwriteFiles();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                overwriteFiles();
            }
        }
    }
}
