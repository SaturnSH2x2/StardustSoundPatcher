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
using Newtonsoft.Json;

namespace StardustSoundModder
{
    public partial class Form1 : Form
    {
        enum WHICHFILE { FILE_30 = 0, FILE_31 = 1 };

        private List<AudioPatch> audioPatches;

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


        // private class for storing useful for data which will be stored in JSON files later on 
        private class AudioPatch
        {
            public String fileName;
            public int startOffset;
            public int lengthOffset;
            public bool isFile30;
            public float audioAmplify;

            public AudioPatch(String fileName, int startOffset, int lengthOffset, bool isFile30, float audioAmplify)
            {
                this.fileName = fileName;
                this.startOffset = startOffset;
                this.lengthOffset = lengthOffset;
                this.isFile30 = isFile30;
                this.audioAmplify = audioAmplify;
            }

            public bool equals(AudioPatch that)
            {
                return (
                        this.startOffset == that.startOffset &&
                        this.lengthOffset == that.lengthOffset &&
                        this.isFile30 == that.isFile30);
            }

            public string ToString()
            {
                return Path.GetFileName(this.fileName) + ", Start: " + this.startOffset.ToString();
            }
        }

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
        private void formatAudio(String filePath, float audioAmplify)
        {
            // convert to mono
            var ir = new AudioFileReader(filePath);
            var mono = new StereoToMonoSampleProvider(ir);
            mono.LeftVolume = 0.0f;
            mono.RightVolume = audioAmplify;
            var resampler = new WdlResamplingSampleProvider(mono, Int32.Parse(samplingRateTB.Text));
            WaveFileWriter.CreateWaveFile16("temp.wav", resampler);
            ir.Close();

            //File.Delete("temp.wav");

        }

        // function to patch out sound data
        private bool patchAudio(byte[] replacementData)
        {
            byte[] dataToReplace;
            if (isFile30)
                dataToReplace = file30;
            else
                dataToReplace = file31;

            if (currentStartOffset + currentLengthOffset > dataToReplace.Length)
            {
                MessageBox.Show("Cannot replace audio.  The chunk of time specified is greater than the actual length of audio itself.");
                return false;
            } else if (currentLengthOffset == 0)
            {
                MessageBox.Show("No audio was replaced; the length was set to 0.");
                return false;
            }

            for (int i = 0; i < currentLengthOffset; i++)
            {
                if (i >= replacementData.Length)
                    dataToReplace[i + currentStartOffset] = 0;
                else
                    dataToReplace[i + currentStartOffset] = replacementData[i];
            }

            return true;
        }

        // unpatches audio by replacing bytes with the original audio data
        private void unpatchAudio(AudioPatch a)
        {
            Stream s;
            byte[] data;

            if (a.isFile30)
            {
                s = File.Open(workingDirectory + "\\30", FileMode.Open);
                data = file30;
            }
            else
            {
                s = File.Open(workingDirectory + "\\31", FileMode.Open);
                data = file31;
            }

            BinaryReader br = new BinaryReader(s);
            s.Position = a.startOffset - 1;
            for (int i = a.startOffset; i < a.startOffset + a.lengthOffset; i++)
            {
                data[i] = br.ReadByte();
            }

            br.Close();
        }

        private void overwriteFiles()
        {
            System.IO.File.WriteAllBytes(workingDirectory + "\\30", file30);
            System.IO.File.WriteAllBytes(workingDirectory + "\\31", file31);
            MessageBox.Show("The sound files have been patched.");
        }

        private void addAudioPatch(AudioPatch a)
        {
            foreach (ListViewItem ls in patchList.Items)
            {
                AudioPatch a1 = (AudioPatch)ls.Tag;
                if (a1.startOffset == a.startOffset)
                {
                    patchList.Items.Remove(ls);
                }
            }

            ListViewItem i = new ListViewItem();
            i.Text = a.ToString();
            i.Tag = a;
            patchList.Items.Add(i);
        }

        private void savePatch()
        {
            List<AudioPatch> jsPatchList = new List<AudioPatch>();

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "ZIP files (*.zip)|*.zip";

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            // delete old temporary directory, if there
            try
            {
                Directory.Delete("temp", true);
            }
            catch (DirectoryNotFoundException) { }
                

            Directory.CreateDirectory("temp");
            foreach (ListViewItem li in patchList.Items)
            {
                AudioPatch a = (AudioPatch)li.Tag;
                File.Copy(a.fileName, "temp\\" + Path.GetFileName(a.fileName));
                a.fileName = Path.GetFileName(a.fileName);
                jsPatchList.Add(a);
            }

            string jsonData = JsonConvert.SerializeObject(jsPatchList);
            File.WriteAllText("temp\\patch.json", jsonData);

            System.IO.Compression.ZipFile.CreateFromDirectory("temp", sfd.FileName);
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
                                "files in your ROM folder, then restart\n" + 
                                "the program.");
                Application.Exit();
            }

            workingDirectory = fbd.FileName;
            file30Radio.Select();

            audioPatches = new List<AudioPatch>();
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

        private void startTimeSecond_TextChanged(object sender, EventArgs e)
        {
            if (startTimeSecond.Text.Length == 0)
            {
                startTimeSecond.Text = "0";
            }

            try
            {
                int val = Int32.Parse(startTimeSecond.Text);
                if (val < 0)
                {
                    samplingRateTB_TextChanged(sender, e);
                }
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
                int val = Int32.Parse(startTimeMs.Text);
                if (val < 0)
                {
                    samplingRateTB_TextChanged(sender, e);
                }
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
                int val = Int32.Parse(startTimeMinute.Text);
                if (val < 0)
                {
                    samplingRateTB_TextChanged(sender, e);
                }
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
                int val = Int32.Parse(lengthMinute.Text);
                if (val < 0)
                {
                    samplingRateTB_TextChanged(sender, e);
                }
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
                int val = Int32.Parse(lengthSecond.Text);
                if (val < 0) {
                    samplingRateTB_TextChanged(sender, e);
                }
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
                int val = Int32.Parse(lengthMs.Text);
                if (val < 0)
                {
                    samplingRateTB_TextChanged(sender, e);
                }
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
                loadSound(ofd.FileName);
            } else
            {
                return;
            }
        }

        private void loadSound(string fileName, float audioAmplify = 0)
        {
            if (audioAmplify == 0)
                audioAmplify = float.Parse(audioAmplifyTB.Text);

            formatAudio(fileName, audioAmplify);

            // get raw data
            Stream wavFile = new FileStream("temp.wav", FileMode.Open);
            BinaryReader br = new BinaryReader(wavFile);

            wavFile.Position = 44;
            byte[] audioData = new byte[(wavFile.Length - 44)];
            for (int i = 0; i < (wavFile.Length - 44); i += 2)
            {
                short sixteenBitSample = br.ReadInt16();
                audioData[i] = (byte)(sixteenBitSample >> 8);
                audioData[i + 1] = (byte)(sixteenBitSample >> 8);
            }

            br.Close();

            // patch data into the audio
            if (patchAudio(audioData))
            {
                addAudioPatch(new AudioPatch(fileName, currentStartOffset, currentLengthOffset, isFile30, float.Parse(audioAmplifyTB.Text)));
            }
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

        private void deleteButton_Click(object sender, EventArgs e)
        {
            foreach (int i in patchList.SelectedIndices)
            {
                ListViewItem l = patchList.Items[i];
                AudioPatch a = (AudioPatch)l.Tag;
                unpatchAudio(a);
                patchList.Items.Remove(l);
            }
        }

        private void exportSoundPatchCtrlSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savePatch();
        }
    }
}
