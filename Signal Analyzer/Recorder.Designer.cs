﻿namespace Signal_Analyzer
{
	partial class Recorder
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
			this.start_btn = new System.Windows.Forms.Button();
			this.stop_btn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// start_btn
			// 
			this.start_btn.Location = new System.Drawing.Point(12, 12);
			this.start_btn.Name = "start_btn";
			this.start_btn.Size = new System.Drawing.Size(131, 72);
			this.start_btn.TabIndex = 0;
			this.start_btn.Text = "Record";
			this.start_btn.UseVisualStyleBackColor = true;
			this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
			// 
			// stop_btn
			// 
			this.stop_btn.Location = new System.Drawing.Point(149, 12);
			this.stop_btn.Name = "stop_btn";
			this.stop_btn.Size = new System.Drawing.Size(131, 72);
			this.stop_btn.TabIndex = 1;
			this.stop_btn.Text = "Done!";
			this.stop_btn.UseVisualStyleBackColor = true;
			this.stop_btn.Click += new System.EventHandler(this.stop_btn_Click);
			// 
			// Recorder
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(291, 94);
			this.Controls.Add(this.stop_btn);
			this.Controls.Add(this.start_btn);
			this.Name = "Recorder";
			this.Text = "Recorder";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button start_btn;
		private System.Windows.Forms.Button stop_btn;
	}
}