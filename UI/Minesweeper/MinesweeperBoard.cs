using Microsoft.VisualBasic.Devices;
using UI.General;
using UI.Properties;
using Utilities.Extensions;

namespace UI.Minesweeper
{
	public partial class MinesweeperBoard : GameBoardBase
	{
		public event EventHandler<(int row, int column, bool ignoreClick)>? MoveClick;
		public event EventHandler<IEnumerable<(int row, int column)>>? MassMoveClick;
		private byte?[,] CurrentState = new byte?[0,0];
		private bool[,] Flags = new bool[0,0];
		public int FlagCount => Flags.Cast<bool>().Count(x => x);
		private HashSet<(int, int)> HighlightedTiles = new();
		private Color HighlightColor = Color.Red;
		private int _TileSize = 35;
		public int TileSize
		{
			get => _TileSize;
			set
			{
				_TileSize = value;
				ReSizeBoard(CurrentState.GetLength(1) * _TileSize, CurrentState.GetLength(0) * _TileSize);
			}
		}
		private readonly Dictionary<byte, Brush> NumberColorMap = new()
		{
			{ 1, Brushes.Green },
			{ 2, Brushes.LimeGreen },
			{ 3, Brushes.YellowGreen },
			{ 4, Brushes.Olive },
			{ 5, Brushes.Goldenrod },
			{ 6, Brushes.DarkOrange },
			{ 7, Brushes.OrangeRed },
			{ 8, Brushes.Red },
		};
		public (Color light, Color dark) TileColorsCovered = (Color.GreenYellow, Color.YellowGreen);
		public (Color light, Color dark) TileColorsUncovered = (Color.AntiqueWhite, Color.NavajoWhite);
		public bool CheckeredStyle = true;
		public MinesweeperBoard() : this(16, 30) { }
		public MinesweeperBoard(int rows, int columns)
		{
			InitializeComponent();
			myPictureBox.Paint += HandlePaint;
			myPictureBox.MouseUp += Picture_Click;
			myPictureBox.MouseDown += Picture_MouseDown;
			Reset(rows, columns);
		}

		private void Picture_MouseDown(object? sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Middle || e.Button == MouseButtons.Right)
			{
				int row = e.Y / _TileSize;
				int column = e.X / _TileSize;
				if (CurrentState[row, column] is null) return; // Only usable on uncovered tiles
				CurrentState.DoAtEach(row - 1, column - 1, row + 1, column + 1, (r, c) =>
				{
					if (CurrentState[r, c] is null && !Flags[r, c])
					{
						OverlayTile(r, c, Color.FromArgb(64, Color.Black));
					}
				});
			}
		}

		public void UpdateState(((int, int), byte) stateUpdate)
		{
			CurrentState[stateUpdate.Item1.Item1, stateUpdate.Item1.Item2] = stateUpdate.Item2;
		}
		public void Reset(int rows, int columns)
		{
			CurrentState = new byte?[rows, columns];
			//CurrentState[0, 0] = 1;
			//CurrentState[1, 0] = 2;
			//CurrentState[2, 0] = 3;
			//CurrentState[3, 0] = 4;
			//CurrentState[4, 0] = 5;
			//CurrentState[5, 0] = 6;
			//CurrentState[6, 0] = 7;
			//CurrentState[7, 0] = 8;
			Flags = new bool[rows, columns];
			HighlightedTiles = new();
			ReSizeBoard(columns * _TileSize, rows * _TileSize);
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
		public void SetFlag(int row, int column, bool isFlagged)
		{
			if (row >= 0 && column >= 0 && row < Flags.GetLength(0) && column < Flags.GetLength(1) && CurrentState[row, column] is null)
				Flags[row, column] = isFlagged;
		}
		public void ClearArea(int row, int column)
		{
			if (CurrentState[row, column] is null) return; // Only usable on uncovered tiles
			// These counts consider the current tile (but it *should* not fulfill the conditions for either)
			var coveredCount = CurrentState.GetArea(row - 1, column - 1, row + 1, column + 1).Count(x => x is null);
			var flagCount = Flags.GetArea(row - 1, column - 1, row + 1, column + 1).Count(x => x);
			// Check if clearing the (unflagged) surrounding tiles is safe
			if (flagCount >= CurrentState[row, column] && coveredCount - flagCount > 0)
			{
				HashSet<(int row, int column)> moves = new();
				CurrentState.DoAtEach(row - 1, column - 1, row + 1, column + 1, (r, c) =>
				{
					if (CurrentState[r, c] is null && !Flags[r, c])
					{
						moves.Add((r, c));
					}
				});
				MassMoveClick?.Invoke(this, moves);
			}
		}
		private void Picture_Click(object? sender, MouseEventArgs e)
		{
			int row = e.Y / _TileSize;
			int column = e.X / _TileSize;
			if (row >= 0 && column >= 0 && row < CurrentState.GetLength(0) && column < CurrentState.GetLength(1))
			{
				if (CurrentState[row, column] is null) // currently covered tile
				{
					if (e.Button == MouseButtons.Right)
					{
						Flags[row, column] = !Flags[row, column];
						MoveClick?.Invoke(this, (row, column, true));
					}
					else if (e.Button == MouseButtons.Left)
					{
						MoveClick?.Invoke(this, (row, column, Flags[row, column]));
					}
					else
					{
						MoveClick?.Invoke(this, (row, column, true));
					}
				}
				else if (e.Button == MouseButtons.Middle || e.Button == MouseButtons.Right)
				{
					ClearArea(row, column);
					MoveClick?.Invoke(this, (row, column, true));
				}
				else
				{
					MoveClick?.Invoke(this, (row, column, true));
				}
			}
			// Always do this to clear overlays (if any)
			UpdateUI();
		}
		private void OverlayTile(int row, int column, Color color)
		{
			var g = myPictureBox.CreateGraphics();
			Rectangle rect = new(column * _TileSize, row * _TileSize, _TileSize, _TileSize);
			g.FillRectangle(new SolidBrush(color), rect);
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
			Font font = new("Arial", _TileSize * 0.55f, FontStyle.Bold, GraphicsUnit.Point);
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
					Rectangle rect = new(column * _TileSize, row * _TileSize, _TileSize, _TileSize);
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
					// Draw flag
					if (Flags[row, column])
					{
						graphics.DrawImage(Resources.Minesweeper_Flag, rect);
					}
				}
			}
		}
	}
}
