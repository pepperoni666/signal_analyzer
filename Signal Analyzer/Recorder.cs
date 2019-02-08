using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signal_Analyzer
{
	public partial class Recorder : Form
	{
		// Create class-level accessible variables to store the audio recorder and capturer instance
		private WaveFileWriter RecordedAudioWriter = null;
		private WaveIn CaptureInstance = null;
		public string outputFilePath = null;
		public bool recording = false;

		public Recorder()
		{
			InitializeComponent();
			stop_btn.Enabled = false;
		}

		private void start_btn_Click(object sender, EventArgs e)
		{
			recording = true;
			outputFilePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\recordedSound.wav";
			//System.IO.File.Create(outputFilePath);
			// Redefine the capturer instance with a new instance of the LoopbackCapture class
			CaptureInstance = new WaveIn();

			// Redefine the audio writer instance with the given configuration
			RecordedAudioWriter = new WaveFileWriter(outputFilePath, CaptureInstance.WaveFormat);

			// When the capturer receives audio, start writing the buffer into the mentioned file
			CaptureInstance.DataAvailable += (s, a) =>
			{
				// Write buffer into the file of the writer instance
				RecordedAudioWriter.Write(a.Buffer, 0, a.BytesRecorded);
			};

			// When the Capturer Stops, dispose instances of the capturer and writer
			CaptureInstance.RecordingStopped += (s, a) =>
			{
				RecordedAudioWriter.Dispose();
				RecordedAudioWriter = null;
				CaptureInstance.Dispose();
				recording = false;
				Close();
			};
			// Start audio recording !
			CaptureInstance.StartRecording();
			stop_btn.Enabled = true;
			start_btn.Enabled = false;
		}

		public void stop_btn_Click(object sender, EventArgs e)
		{
			CaptureInstance.StopRecording();
			stop_btn.Enabled = false;
			start_btn.Enabled = true;
		}
	}
}
