using UI.Properties;

namespace UI.Minesweeper
{
	public partial class MinesweeperBoard : UserControl
	{
		private byte?[,] CurrentState;
		private int MineSize = 20;
		private readonly Dictionary<byte, Brush> ColorMap = new()
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
		public MinesweeperBoard() : this(30, 30) { }
		public MinesweeperBoard(int rows, int columns)
		{
			InitializeComponent();
			CurrentState = new byte?[rows, columns];
			pictureBox1.Paint += HandlePaint;
			CurrentState[1, 1] = 1;
			CurrentState[1, 2] = 2;
			CurrentState[1, 3] = 3;
			CurrentState[1, 4] = 4;
			CurrentState[1, 5] = 5;
			CurrentState[1, 6] = 6;
			CurrentState[1, 7] = 7;
			CurrentState[1, 8] = 8;
			CurrentState[1, 9] = 9;
		}
		private void HandlePaint(object? sender, PaintEventArgs e)
		{
			var graphics = e.Graphics;
			var covered = Resources.Minesweeper_Covered;
			var uncovered = Resources.Minesweeper_Uncovered;
			Font font = new("Arial", MineSize * 0.55f, FontStyle.Bold, GraphicsUnit.Point);
			StringFormat format = new()
			{
				Alignment = StringAlignment.Center,
				LineAlignment = StringAlignment.Center,
			};
			for (int row = 0; row < CurrentState.GetLength(0); row++)
			{
				for (int column = 0; column < CurrentState.GetLength(1); column++)
				{
					Rectangle rect = new(row * MineSize, column * MineSize, MineSize, MineSize);
					var state = CurrentState[row, column];
					if (state != null)
					{
						graphics.DrawImage(uncovered, rect);
						graphics.DrawString(
							state.ToString(),
							font,
							ColorMap.TryGetValue(state.Value, out var color) ? color : Brushes.Black,
							rect,
							format
						);
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
