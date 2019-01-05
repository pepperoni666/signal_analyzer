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
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.select_btn = new System.Windows.Forms.Button();
			this.label_filename = new System.Windows.Forms.Label();
			this.radio_zoom_x = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.radio_zoom_y = new System.Windows.Forms.RadioButton();
			((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
			this.SuspendLayout();
			// 
			// chart1
			// 
			chartArea1.BorderColor = System.Drawing.Color.Gray;
			chartArea1.CursorX.IsUserEnabled = true;
			chartArea1.CursorX.IsUserSelectionEnabled = true;
			chartArea1.Name = "ChartArea1";
			this.chart1.ChartAreas.Add(chartArea1);
			this.chart1.Location = new System.Drawing.Point(12, 69);
			this.chart1.Name = "chart1";
			this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Grayscale;
			this.chart1.Size = new System.Drawing.Size(938, 207);
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
			this.label_filename.Location = new System.Drawing.Point(114, 12);
			this.label_filename.Name = "label_filename";
			this.label_filename.Padding = new System.Windows.Forms.Padding(5, 4, 0, 0);
			this.label_filename.Size = new System.Drawing.Size(836, 23);
			this.label_filename.TabIndex = 3;
			// 
			// radio_zoom_x
			// 
			this.radio_zoom_x.AutoSize = true;
			this.radio_zoom_x.Checked = true;
			this.radio_zoom_x.Location = new System.Drawing.Point(74, 44);
			this.radio_zoom_x.Name = "radio_zoom_x";
			this.radio_zoom_x.Size = new System.Drawing.Size(32, 17);
			this.radio_zoom_x.TabIndex = 4;
			this.radio_zoom_x.TabStop = true;
			this.radio_zoom_x.Text = "X";
			this.radio_zoom_x.UseVisualStyleBackColor = true;
			this.radio_zoom_x.CheckedChanged += new System.EventHandler(this.radio_zoom_x_CheckedChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(12, 41);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 20);
			this.label2.TabIndex = 5;
			this.label2.Text = "zoom: ";
			// 
			// radio_zoom_y
			// 
			this.radio_zoom_y.AutoSize = true;
			this.radio_zoom_y.Location = new System.Drawing.Point(113, 44);
			this.radio_zoom_y.Name = "radio_zoom_y";
			this.radio_zoom_y.Size = new System.Drawing.Size(32, 17);
			this.radio_zoom_y.TabIndex = 6;
			this.radio_zoom_y.Text = "Y";
			this.radio_zoom_y.UseVisualStyleBackColor = true;
			this.radio_zoom_y.CheckedChanged += new System.EventHandler(this.radio_zoom_y_CheckedChanged);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(962, 497);
			this.Controls.Add(this.radio_zoom_y);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.radio_zoom_x);
			this.Controls.Add(this.label_filename);
			this.Controls.Add(this.select_btn);
			this.Controls.Add(this.chart1);
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
		private System.Windows.Forms.Button select_btn;
		private System.Windows.Forms.Label label_filename;
		private System.Windows.Forms.RadioButton radio_zoom_x;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RadioButton radio_zoom_y;
	}
}

