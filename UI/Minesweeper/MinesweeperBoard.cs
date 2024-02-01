using UI.General;
using UI.Properties;

namespace UI.Minesweeper
{
	public partial class MinesweeperBoard : GameBoardBase
	{
		public event EventHandler<(int, int)>? MoveClick;
		private byte?[,] CurrentState = new byte?[0,0];
		private HashSet<(int, int)> HighlightedTiles = new();
		private Color HighlightColor = Color.Red;
		private int TileSize = 20;
		private readonly Dictionary<byte, Brush> NumberColorMap = new()
		{
			{ 1, Brushes.Lime },
			{ 2, Brushes.GreenYellow },
			{ 3, Brushes.YellowGreen },
			{ 4, Brushes.Yellow },
			{ 5, Brushes.Goldenrod },
			{ 6, Brushes.Orange },
			{ 7, Brushes.OrangeRed },
			{ 8, Brushes.Red },
		};
		public (Color light, Color dark) TileColorsCovered = (Color.GreenYellow, Color.YellowGreen);
		public (Color light, Color dark) TileColorsUncovered = (Color.AntiqueWhite, Color.NavajoWhite);
		public bool CheckeredStyle = true;
		public MinesweeperBoard() : this(30, 30) { }
		public MinesweeperBoard(int rows, int columns)
		{
			InitializeComponent();
			myPictureBox.Paint += HandlePaint;
			myPictureBox.MouseUp += Picture_Click;
			Reset(rows, columns);
		}
		public void UpdateState(((int, int), byte) stateUpdate)
		{
			CurrentState[stateUpdate.Item1.Item1, stateUpdate.Item1.Item2] = stateUpdate.Item2;
		}
		public void Reset(int rows, int columns)
		{
			CurrentState = new byte?[rows, columns];
			HighlightedTiles = new();
			ReSizeBoard(columns * TileSize, rows * TileSize);
		}
		public void HandleEnd(bool[,] bombs)
		{
			for (int row = 0; row < bombs.GetLength(0); row++)
			{
				for (int col = 0; col < bombs.GetLength(1); col++)
				{
					if (bombs[row, col])
					{
						CurrentState[row, col] = 255;
					}
				}
			}
			UpdateUI();
		}
		private void Picture_Click(object? sender, MouseEventArgs e)
		{
			int row = e.Y / TileSize;
			int column = e.X / TileSize;
			if (row >= 0 && column >= 0 && row < CurrentState.GetLength(0) && column < CurrentState.GetLength(1))
			{
				MoveClick?.Invoke(this, (row, column));
			}
		}
		public void HighlightTiles(IEnumerable<(int, int)> tiles, Color? color = null)
		{
			HighlightedTiles = new(tiles);
			if (color != null)
			{
				HighlightColor = color.Value;
			}
			UpdateUI();
		}
		private void HandlePaint(object? sender, PaintEventArgs e)
		{
			var graphics = e.Graphics;
			var covered = Resources.Minesweeper_Covered;
			var uncovered = Resources.Minesweeper_Uncovered;
			var bomb = Resources.Minesweeper_Bomb;
			Font font = new("Arial", TileSize * 0.55f, FontStyle.Bold, GraphicsUnit.Point);
			StringFormat format = new()
			{
				Alignment = StringAlignment.Center,
				LineAlignment = StringAlignment.Center,
			};
			var brushesCovered = (new SolidBrush(TileColorsCovered.light), new SolidBrush(TileColorsCovered.dark));
			var brushesUncovered = (new SolidBrush(TileColorsUncovered.light), new SolidBrush(TileColorsUncovered.dark));
			var Highlighter = new SolidBrush(HighlightColor);
			for (int row = 0; row < CurrentState.GetLength(0); row++)
			{
				for (int column = 0; column < CurrentState.GetLength(1); column++)
				{
					Rectangle rect = new(column * TileSize, row * TileSize, TileSize, TileSize);
					var state = CurrentState[row, column];
					bool checkerdOn = ((column + row) % 2) == 0;
					if (state != null)
					{
						if (HighlightedTiles.Contains((row, column)))
						{
							graphics.FillRectangle(Highlighter, rect);
						}
						else if (CheckeredStyle)
						{
							graphics.FillRectangle(checkerdOn ? brushesUncovered.Item1 : brushesUncovered.Item2, rect);
						}
						else
						{
							graphics.DrawImage(uncovered, rect);
						}
						if (state == 255)
						{
							graphics.DrawImage(bomb, rect);
						}
						else if (state != 0)
						{
							graphics.DrawString(
								state.ToString(),
								font,
								NumberColorMap.TryGetValue(state.Value, out var color) ? color : Brushes.Black,
								rect,
								format
							);
						}
					}
					else
					{
						if (CheckeredStyle)
						{
							graphics.FillRectangle(checkerdOn ? brushesCovered.Item1 : brushesCovered.Item2, rect);
						}
						else
						{
							graphics.DrawImage(covered, rect);
						}
					}
				}
			}
		}
	}
}
