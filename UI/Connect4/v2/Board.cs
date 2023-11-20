using System.Drawing.Imaging;
using UI.Properties;

namespace UI.Connect4.v2
{
	public partial class Board : UserControl
	{
		private Dictionary<(int, int), (int, ImageAttributes, Color?)> Attributes { get; set; } = new();
		private ImageAttributes DefaultAttributes { get; set; }
		public List<Color> ColorMap { get; set; }
		public int TokenSize { get; private set; } = 100;
		public int RowCount { get; private set; }
		public int ColumnCount { get; private set; }
		public event EventHandler<int>? ColumnClick;
		private readonly Image TokenImage = new Bitmap(Resources.Connect4_Token);
		private static ImageAttributes BuildAttributes(Color color)
		{
			ColorMatrix matrix = new(new float[5][]
			{
				new float[5] { color.R / 255f, 0, 0, 0, 0},
				new float[5] { 0, color.G / 255f, 0, 0, 0},
				new float[5] { 0, 0, color.B / 255f, 0, 0},
				new float[5] { 0, 0, 0, color.A / 255f, 0},
				new float[5] { 0, 0, 0, 0, 1}
			});
			ImageAttributes toReturn = new();
			toReturn.SetColorMatrix(matrix);
			return toReturn;
		}
		public Board() : this(6, 7) { }
		public Board(int rowCount, int columnCount)
		{
			InitializeComponent();
			SetTokenSize(TokenSize);
			DefaultAttributes = BuildAttributes(Color.White);
			ColorMap = new() { Color.White };
			pictureBox1.Paint += Board_Paint;
			pictureBox1.MouseUp += Picture_Click;
			pictureBox1.BackColor = Color.Yellow;
			Reset(rowCount, columnCount);
		}
		public void SetTokenSize(int size)
		{
			TokenSize = size;
			if (this.InvokeRequired)
			{
				this.Invoke(() => { this.Size = new(ColumnCount * TokenSize, RowCount * TokenSize); });
			}
			else
			{
				this.Size = new(ColumnCount * TokenSize, RowCount * TokenSize);
			}
			if (pictureBox1.IsHandleCreated)
			{
				pictureBox1.Invoke(pictureBox1.Refresh);
			}
		}
		public void Reset(int rows, int columns)
		{
			RowCount = rows;
			ColumnCount = columns;
			Attributes = new();
			SetTokenSize(TokenSize);
		}
		public void Update(int[,] newState)
		{
			RowCount = newState.GetLength(0);
			ColumnCount = newState.GetLength(1);
			for (int row = 0; row < RowCount; row++)
			{
				for (int column = 0; column < ColumnCount; column++)
				{
					if (!Attributes.TryGetValue((row, column), out var attr) || newState[row, column] != attr.Item1)
					{
						Attributes[(row, column)] = (newState[row, column], BuildAttributes(ColorMap[newState[row, column]]), null);
					}
				}
			}
			pictureBox1.Invoke(pictureBox1.Refresh);
		}
		public void HighlightPieces(List<(int, int)> positions, Color color)
		{
			foreach (var pos in positions)
			{
				if (Attributes.TryGetValue(pos, out var temp))
				{
					Attributes[pos] = (temp.Item1, temp.Item2, color);
				}
			}
			pictureBox1.Invoke(pictureBox1.Refresh);
		}
		private void Picture_Click(object? sender, MouseEventArgs e)
		{
			if (e.X < 0 || e.Y < 0 || e.X > ColumnCount * TokenSize || e.Y > RowCount * TokenSize) { return; }
			ColumnClick?.Invoke(this, e.X / TokenSize);
		}
		private void Board_Paint(object? sender, PaintEventArgs e)
		{
			for (int row = 0; row < RowCount; row++)
			{
				for (int column = 0; column < ColumnCount; column++)
				{
					Rectangle rect = new(column * TokenSize, (RowCount - row - 1) * TokenSize, TokenSize, TokenSize);
					ImageAttributes? attributes = null;
					if (Attributes.TryGetValue((row, column), out var attr))
					{
						attributes = attr.Item2;
						if (attr.Item3 != null)
						{
							e.Graphics.FillRectangle(new SolidBrush(attr.Item3.Value), rect);
						}
					}
					e.Graphics.DrawImage(
							TokenImage,
							rect,
							0, 0, TokenImage.Width, TokenImage.Height,
							GraphicsUnit.Pixel,
							attributes ?? DefaultAttributes
						);
				}
			}
		}
	}
}
