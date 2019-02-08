using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Un4seen.Bass;
using Un4seen.Bass.Misc;

namespace Signal_Analyzer
{
	class WavManager
	{
		private string filename;

		public async void playSound()
		{
			if (filename != null)
			{
				SoundPlayer snd = new SoundPlayer(filename);
				snd.Play();
			}
		}

		public async void loadSound(string filname, int height, int stepsPerSecond, Chart chart1, IntPtr Handle, PictureBox picture)
		{ 
			filename = filname;
			chart1.Series.Clear();
			chart1.Series.Add("wave");
			chart1.Series["wave"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			chart1.Series["wave"].IsVisibleInLegend = false;
			chart1.Series["wave"].Color = System.Drawing.Color.Green;
			chart1.Series["wave"].ChartArea = "ChartArea1";
			NAudio.Wave.WaveChannel32 wave = new NAudio.Wave.WaveChannel32(new NAudio.Wave.WaveFileReader(filename));

			byte[] buffer = new byte[426565];
			int read;
			while (wave.Position < wave.Length)
			{
				read = wave.Read(buffer, 0, 426565);
				for (int i = 0; i < read / 4; i++)
				{
					chart1.Series["wave"].Points.Add(BitConverter.ToSingle(buffer, i * 4));
				}
			}

			wave.Dispose();

			picture.Image = DrawSpectrogram(filename, height, stepsPerSecond, Handle);
			System.Windows.Forms.Cursor.Current = Cursors.Default;
		}

		private Bitmap DrawSpectrogram(string fileName, int height, int stepsPerSecond, IntPtr Handle)
		{
			Bass.BASS_Init(-1, 44100, BASSInit.BASS_DEVICE_DEFAULT, Handle);
			int channel = Bass.BASS_StreamCreateFile(fileName, 0, 0, BASSFlag.BASS_DEFAULT);

			long len = Bass.BASS_ChannelGetLength(channel, BASSMode.BASS_POS_BYTES); // the length in bytes
			double time = Bass.BASS_ChannelBytes2Seconds(channel, len); // the length in seconds

			int steps = (int)Math.Floor(stepsPerSecond * time);

			Bitmap result = new Bitmap(steps, height);
			Graphics g = Graphics.FromImage(result);

			Visuals visuals = new Visuals();	

			Bass.BASS_ChannelPlay(channel, false);

			for (int i = 0; i < steps; i++)
			{
				Bass.BASS_ChannelSetPosition(channel, 1.0 * i / stepsPerSecond);
				visuals.CreateSpectrum3DVoicePrint(channel, g, new Rectangle(0, 0, result.Width, result.Height), Color.Black, Color.White, i, true, true);
			}

			Bass.BASS_ChannelStop(channel);

			Bass.BASS_Stop();
			Bass.BASS_Free();

			return result;
		}
	}
}
