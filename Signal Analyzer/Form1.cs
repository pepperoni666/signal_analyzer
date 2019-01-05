using NAudio.Dsp;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Signal_Analyzer
{
	public partial class Form1 : Form
	{
		private string fileName;

		public Form1()
		{
			InitializeComponent();
		}

		/*internal class AutoTuneWaveProvider: IWaveProvider
		{

			internal class AutoCorrelator
			{
				public float sampleRate;
				public int maxOffset;
				public int minOffset;

				public AutoCorrelator(int sampleRate)
				{
					this.sampleRate = (float)sampleRate;
					int minFreq = 85;
					int maxFreq = 255;

					this.maxOffset = sampleRate / minFreq;
					this.minOffset = sampleRate / maxFreq;
				}

				public float DetectPitch(float[] buffer, int frames)
				{
					if (prevBuffer == null)
					{
						prevBuffer = new float[frames];
					}

					float maxCorr = 0;
					int maxLag = 0;
					// начинаем с низких частот и заканчиваем высокими
					for (int lag = maxOffset; lag >= minOffset; lag--)
					{
						float corr = 0; //  сумма квадратов
						for (int i = 0; i < frames; i++)
						{
							int oldIndex = i - lag;
							float sample = ((oldIndex < 0) ? prevBuffer[frames +
							corr += (sample * buffer[i]);
						}
						if (corr > maxCorr)
						{
							maxCorr = corr;
							maxLag = lag;
						}

					}
					for (int n = 0; n < frames; n++)
					{
						prevBuffer[n] = buffer[n];
					}
					float noiseThreshold = frames / 1000f;

					if (maxCorr < noiseThreshold || maxLag == 0) return 0.0f;
					return this.sampleRate / maxLag;
				}
			}

			public IWaveProvider source;
			public AutoCorrelator pitchDetector;
			public SmbPitchShifter pitchShifter;
			public WaveBuffer waveBuffer;

			public AutoTuneWaveProvider(IWaveProvider source, AutoTuneSettings autoTuneSettings)
			{
				//this.autoTuneSettings = autoTuneSettings;
				if (source.WaveFormat.SampleRate != 44100)
					throw new ArgumentException("AutoTune only works at 44.1kHz");
				if (source.WaveFormat.Encoding != WaveFormatEncoding.IeeeFloat)
					throw new ArgumentException("AutoTune only works on IEEE floating point audio data");
				if (source.WaveFormat.Channels != 1)
					throw new ArgumentException("AutoTune only works on mono input sources");

				this.source = source;
				this.pitchDetector = new AutoCorrelator(source.WaveFormat.SampleRate);
				this.pitchShifter = new SmbPitchShifter();
				this.waveBuffer = new WaveBuffer(8192);
			}

			public WaveFormat WaveFormat => throw new NotImplementedException();

			public int Read(byte[] buffer, int offset, int count)
			{
				if (waveBuffer == null || waveBuffer.MaxSize < count)
				{
					waveBuffer = new WaveBuffer(count);
				}

				int bytesRead = source.Read(waveBuffer, 0, count);

				// иногда последнюю порцию данных необходимо округлить:
				if (bytesRead > 0) bytesRead = count;

				int frames = bytesRead / sizeof(float);
				float pitch = pitchDetector.DetectPitch(waveBuffer.FloatBuffer, frames);

				// попытка увеличить значимость, удерживая высоту тона
				// на протяжении, по крайней мере, еще одного буфера
				if (pitch == 0f && release < maxHold)
				{
					pitch = previousPitch;
					release++;
				}
				else
				{
					this.previousPitch = pitch;
					release = 0;
				}

				WaveBuffer outBuffer = new WaveBuffer(buffer);

				pitchShifter.ShiftPitch(waveBuffer.FloatBuffer, pitch, 0.0f, outBuffer.FloatBuffer, frames);

				return frames * 4;
			}
		}*/

		short[] readAmplitudeValues(string filename)
		{
			var file = System.IO.File.OpenRead(filename);
			byte[] buffer = new byte[file.Length];
			file.Read(buffer, 0, buffer.Length);

			var waveBuffer = new WaveBuffer(buffer);

			return waveBuffer.ShortBuffer;
		}


		/*public void ApplyAutoTune(string fileToProcess, string tempFile, AutoTuneSettings autotuneSettings)
		{
			using (WaveFileReader reader = new WaveFileReader(fileToProcess))
			{
				IWaveProvider stream32 = new Wave16ToFloatProvider(reader);
				IWaveProvider streamEffect = new AutoTuneWaveProvider(stream32, autotuneSettings);
				IWaveProvider stream16 = new WaveFloatTo16Provider(streamEffect);
				using (WaveFileWriter converted = new WaveFileWriter(tempFile, stream16.WaveFormat))
				{
					// для правильной работы алгоритма быстрого преобразования Фурье (FFT) необходимо,
					// чтобы длина буфера была степенью 2, однако если длина буфера окажется слишком большой
					// то  высота тона, не будет определяться достаточно быстро
					// подходящий размер буфера: 8192, 4096, 2048, 1024
					// (некоторым алгоритмам определения высоты звука требуется размер по крайней мере 2048)
					byte[] buffer = new byte[8192];
					int bytesRead;
					do
					{
						bytesRead = stream16.Read(buffer, 0, buffer.Length);
						converted.WriteData(buffer, 0, bytesRead);
					} while (bytesRead != 0 && converted.Length < reader.Length);
				}
			}
		}*/

		private void select_btn_Click(object sender, EventArgs e)
		{
			OpenFileDialog open = new OpenFileDialog();
			//open.Filter = "Wave File (.wav)|.wav";
			if (open.ShowDialog() != DialogResult.OK) return;
			label_filename.Text = open.FileName;
			chart1.Series.Clear();
			chart1.Series.Add("wave");
			chart1.Series["wave"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
			chart1.Series["wave"].IsVisibleInLegend = false;
			chart1.Series["wave"].Color = System.Drawing.Color.Green;
			chart1.Series["wave"].ChartArea = "ChartArea1";
			NAudio.Wave.WaveChannel32 wave = new NAudio.Wave.WaveChannel32(new NAudio.Wave.WaveFileReader(open.FileName));

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
		}

		private void radio_zoom_x_CheckedChanged(object sender, EventArgs e)
		{
			if (radio_zoom_x.Checked)
			{
				chart1.ChartAreas["ChartArea1"].CursorX.IsUserEnabled = true;
				chart1.ChartAreas["ChartArea1"].CursorX.IsUserSelectionEnabled = true;
			}
			else
			{
				chart1.ChartAreas["ChartArea1"].CursorX.IsUserEnabled = false;
				chart1.ChartAreas["ChartArea1"].CursorX.IsUserSelectionEnabled = false;
			}
		}

		private void radio_zoom_y_CheckedChanged(object sender, EventArgs e)
		{
			if (radio_zoom_y.Checked)
			{
				chart1.ChartAreas["ChartArea1"].CursorY.IsUserEnabled = true;
				chart1.ChartAreas["ChartArea1"].CursorY.IsUserSelectionEnabled = true;
			}
			else
			{
				chart1.ChartAreas["ChartArea1"].CursorY.IsUserEnabled = false;
				chart1.ChartAreas["ChartArea1"].CursorY.IsUserSelectionEnabled = false;
			}
		}
	}
}
