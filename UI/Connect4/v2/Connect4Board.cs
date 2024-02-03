using System.Drawing.Imaging;
using UI.General;
using UI.Properties;
using Utilities.Extensions;

namespace UI.Connect4.v2
{
	public partial class Connect4Board : GameBoardBase
	{
		private Dictionary<(int, int), (int, ImageAttributes, Color?)> Attributes { get; set; } = new();
		private ImageAttributes DefaultAttributes { get; set; }
		public int TokenSize { get; private set; } = 100;
		public int RowCount { get; private set; }
		public int ColumnCount { get; private set; }
		public event EventHandler<int>? ColumnClick;
		private readonly Image TokenImage = new Bitmap(Resources.Connect4_Token);
		public Connect4Board() : this(6, 7) { }
		public Connect4Board(int rowCount, int columnCount)
		{
			InitializeComponent();
			SetTokenSize(TokenSize);
			DefaultAttributes = Color.White.BuildAttributes();
			myPictureBox.Paint += Board_Paint;
			myPictureBox.MouseUp += Picture_Click;
			myPictureBox.BackColor = Color.Yellow;
			Reset(rowCount, columnCount);
		}
		public void SetTokenSize(int size)
		{
			TokenSize = size;
			ReSizeBoard(ColumnCount * TokenSize, RowCount * TokenSize);
		}
		public void Reset(int rows, int columns)
		{
			RowCount = rows;
			ColumnCount = columns;
			Attributes = [];
			SetTokenSize(TokenSize);
		}
		public void Update(int[,] newState, List<Color> colorMap)
		{
			RowCount = newState.GetLength(0);
			ColumnCount = newState.GetLength(1);
			for (int row = 0; row < RowCount; row++)
			{
				for (int column = 0; column < ColumnCount; column++)
				{
					int tokenState = newState[row, column];
					if (tokenState != 0 && (!Attributes.TryGetValue((row, column), out var attr) || tokenState != attr.Item1))
					{
						Attributes[(row, column)] = (tokenState,colorMap[tokenState - 1].BuildAttributes(), null);
					}
				}
			}
			UpdateUI();
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
			UpdateUI();
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
