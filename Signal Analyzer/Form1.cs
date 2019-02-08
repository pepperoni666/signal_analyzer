using NAudio.Dsp;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
	public partial class Form1 : Form
	{
		WavManager wavManager;
		Recorder recorder;

		public Form1()
		{
			InitializeComponent();
			wavManager = new WavManager();
		}

		private void select_btn_Click(object sender, EventArgs e)
		{
			OpenFileDialog open = new OpenFileDialog();
			if (open.ShowDialog() != DialogResult.OK) return;
			label_filename.Text = open.FileName;
			System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
			wavManager.loadSound(open.FileName, pictureBox1.Height, 200, chart1, Handle, pictureBox1);
		}

		private void play_btn_Click(object sender, EventArgs e)
		{
			wavManager.playSound();
		}

		private void record_btn_Click(object sender, EventArgs e)
		{
			recorder = new Recorder();
			recorder.FormClosing += new FormClosingEventHandler(this.loadRecordedSound);
			recorder.Show();
		}

		public void loadRecordedSound(object sender, FormClosingEventArgs e)
		{
			if (!recorder.recording)
			{
				if (recorder.outputFilePath != null)
				{
					label_filename.Text = recorder.outputFilePath;
					System.Windows.Forms.Cursor.Current = Cursors.WaitCursor;
					wavManager.loadSound(recorder.outputFilePath, pictureBox1.Height, 200, chart1, Handle, pictureBox1);
				}
			}
			else
				recorder.stop_btn_Click(sender, e);
		}
	}
}
