using System.Drawing.Imaging;
using UI.Properties;

namespace UI
{
	public partial class TokenSpace : UserControl
	{
		public TokenSpace()
		{
			InitializeComponent();
		}
		public static float[][] GetColorMatrix(float red, float green, float blue, float alpha)
		{
			return new float[5][]
			{
				new float[5] { red, 0, 0, 0, 0},
				new float[5] { 0, green, 0, 0, 0},
				new float[5] { 0, 0, blue, 0, 0},
				new float[5] { 0, 0, 0, alpha, 0},
				new float[5] { 0, 0, 0, 0, 1}
			};
		}
		public void SetToken(Color color)
		{
			var colorMatrix = GetColorMatrix(color.R / 255f, color.G / 255f, color.B / 255f, color.A / 255f);
			ImageAttributes attributes = new();
			attributes.SetColorMatrix(new ColorMatrix(colorMatrix), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
			Image image = new Bitmap(Resources.test);
			pictureBox1.Image = image;
			pictureBox1.Paint += (object? sender, PaintEventArgs e) =>
			{
				e.Graphics.DrawImage(
					image,
					new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height),
					0, 0,
					image.Width, image.Height,
					GraphicsUnit.Pixel,
					attributes);
			};
		}
	}
}
