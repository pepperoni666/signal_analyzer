namespace Signal_Analyzer
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.select_btn = new System.Windows.Forms.Button();
			this.label_filename = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.play_btn = new System.Windows.Forms.Button();
			this.record_btn = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// chart1
			// 
			chartArea3.BorderColor = System.Drawing.Color.Gray;
			chartArea3.CursorX.IsUserEnabled = true;
			chartArea3.CursorX.IsUserSelectionEnabled = true;
			chartArea3.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea3);
			this.chart1.Location = new System.Drawing.Point(12, 41);
			this.chart1.Name = "chart1";
			this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
			this.chart1.Size = new System.Drawing.Size(938, 124);
			this.chart1.TabIndex = 0;
			this.chart1.Text = "chart1";
			// 
			// select_btn
			// 
			this.select_btn.Location = new System.Drawing.Point(12, 12);
			this.select_btn.Name = "select_btn";
			this.select_btn.Size = new System.Drawing.Size(96, 23);
			this.select_btn.TabIndex = 1;
			this.select_btn.Text = "Select file";
			this.select_btn.UseVisualStyleBackColor = true;
			this.select_btn.Click += new System.EventHandler(this.select_btn_Click);
			// 
			// label_filename
			// 
			this.label_filename.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label_filename.Location = new System.Drawing.Point(114, 9);
			this.label_filename.Name = "label_filename";
			this.label_filename.Padding = new System.Windows.Forms.Padding(5, 4, 0, 0);
			this.label_filename.Size = new System.Drawing.Size(674, 23);
			this.label_filename.TabIndex = 3;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Location = new System.Drawing.Point(12, 171);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(938, 346);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 7;
			this.pictureBox1.TabStop = false;
			// 
			// play_btn
			// 
			this.play_btn.Location = new System.Drawing.Point(875, 7);
			this.play_btn.Name = "play_btn";
			this.play_btn.Size = new System.Drawing.Size(75, 23);
			this.play_btn.TabIndex = 8;
			this.play_btn.Text = "Play";
			this.play_btn.UseVisualStyleBackColor = true;
			this.play_btn.Click += new System.EventHandler(this.play_btn_Click);
			// 
			// record_btn
			// 
			this.record_btn.Location = new System.Drawing.Point(794, 7);
			this.record_btn.Name = "record_btn";
			this.record_btn.Size = new System.Drawing.Size(75, 23);
			this.record_btn.TabIndex = 9;
			this.record_btn.Text = "Record";
			this.record_btn.UseVisualStyleBackColor = true;
			this.record_btn.Click += new System.EventHandler(this.record_btn_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(962, 529);
			this.Controls.Add(this.record_btn);
			this.Controls.Add(this.play_btn);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label_filename);
			this.Controls.Add(this.select_btn);
			this.Controls.Add(this.chart1);
			this.Name = "Form1";
			this.Text = "Signal Analizer";
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.Button select_btn;
		private System.Windows.Forms.Label label_filename;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button play_btn;
		private System.Windows.Forms.Button record_btn;
	}
}

