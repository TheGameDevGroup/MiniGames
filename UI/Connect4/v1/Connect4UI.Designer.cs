﻿namespace UI.Connect4.v1
{
	partial class Connect4UI
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Connect4UI));
			board1 = new Connect4Board();
			SuspendLayout();
			// 
			// board1
			// 
			board1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
			board1.AutoScroll = true;
			board1.Location = new Point(12, 12);
			board1.Name = "board1";
			board1.Size = new Size(777, 449);
			board1.TabIndex = 0;
			// 
			// Connect4UI
			// 
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(801, 473);
			Controls.Add(board1);
			Name = "Connect4UI";
			Text = "Connect4";
			WindowState = FormWindowState.Maximized;
			ResumeLayout(false);
		}

		#endregion

		private Connect4Board board1;
	}
}