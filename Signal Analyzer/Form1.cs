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
			var fileDialog = new OpenFileDialog();
			DialogResult result = fileDialog.ShowDialog(); // Show the dialog.
			if (result == DialogResult.OK) // Test result.
			{
				fileName = fileDialog.FileName;
				try
				{
					short[] f = readAmplitudeValues(fileName);
					chart1.Series.Clear();
					var series1 = new System.Windows.Forms.DataVisualization.Charting.Series
					{
						Name = "Series1",
						Color = System.Drawing.Color.Green,
						IsVisibleInLegend = false,
						IsXValueIndexed = true,
						ChartType = SeriesChartType.Line
					};
					chart1.Series.Add(series1);
					for(int i = 0; i < f.Length && i < 1600000; i+=2)
					{
						series1.Points.AddY(f[i]);
					}
					chart1.Invalidate();
					//label1.Text = File.ReadAllText(fileName);
				}
				catch (IOException)
				{
				}
			}
		}
	}
}
