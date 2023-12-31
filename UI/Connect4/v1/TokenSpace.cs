﻿using System.Drawing.Imaging;
using UI.Properties;

namespace UI.Connect4.v1
{
	public partial class TokenSpace : UserControl
	{
		public int ColumnIndex { get; init; }
		public int RowIndex { get; init; }
		private ImageAttributes Attributes { get; set; } = new();
		private Image Image { get; set; } = new Bitmap(Resources.Connect4_Token);

		public TokenSpace(int row, int column, Color startColor)
		{
			InitializeComponent();
			RowIndex = row;
			ColumnIndex = column;
			pictureBox1.Image = Image;
			SetToken(startColor);
			pictureBox1.Paint += (object? sender, PaintEventArgs e) =>
			{
				e.Graphics.DrawImage(
					Image,
					new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height),
					0, 0,
					Image.Width, Image.Height,
					GraphicsUnit.Pixel,
					Attributes);
			};
		}
		public void SetToken(Color color)
		{
			ColorMatrix matrix = new(new float[5][]
			{
				new float[5] { color.R / 255f, 0, 0, 0, 0},
				new float[5] { 0, color.G / 255f, 0, 0, 0},
				new float[5] { 0, 0, color.B / 255f, 0, 0},
				new float[5] { 0, 0, 0, color.A / 255f, 0},
				new float[5] { 0, 0, 0, 0, 1}
			});
			lock(matrix)
			{
				Attributes.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
			}
			if (pictureBox1.InvokeRequired)
			{
				pictureBox1.Invoke(pictureBox1.Refresh);
			}
			else
			{
				pictureBox1.Refresh();
			}
		}
		public void SetBackGround(Color color)
		{
			pictureBox1.BackColor = color;
		}
		private void Picture_MouseUp(object sender, MouseEventArgs e)
		{
			this.OnMouseUp(e);
		}

		private void Picture_MouseDown(object sender, MouseEventArgs e)
		{
			this.OnMouseDown(e);
		}

		private void Picture_Click(object sender, EventArgs e)
		{
			this.OnClick(e);
		}
	}
}
