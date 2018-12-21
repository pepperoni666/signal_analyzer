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

namespace Signal_Analyzer
{
	public partial class Form1 : Form
	{
		private string fileName;

		public Form1()
		{
			InitializeComponent();
		}

		private void select_btn_Click(object sender, EventArgs e)
		{
			var fileDialog = new OpenFileDialog();
			DialogResult result = fileDialog.ShowDialog(); // Show the dialog.
			if (result == DialogResult.OK) // Test result.
			{
				fileName = fileDialog.FileName;
				try
				{
					label1.Text = File.ReadAllText(fileName);
				}
				catch (IOException)
				{
				}
			}
		}
	}
}
