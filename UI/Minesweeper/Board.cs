using UI.Properties;

namespace UI.Minesweeper
{
	public partial class Board : UserControl
	{
		private byte?[,] CurrentState;
		private int MineSize = 30;
		public Board() : this(30, 30) { }
		public Board(int rows, int columns)
		{
			InitializeComponent();
			CurrentState = new byte?[rows, columns];
			pictureBox1.Paint += HandlePaint;
			CurrentState[1, 1] = 1;
		}
		private void HandlePaint(object? sender, PaintEventArgs e)
		{
			var graphics = e.Graphics;
			var covered = Resources.Minesweeper_Covered;
			var uncovered = Resources.Minesweeper_Uncovered;
			for (int row = 0; row < CurrentState.GetLength(0); row++)
			{
				for (int column = 0; column < CurrentState.GetLength(1); column++)
				{
					if (CurrentState[row, column] != null)
					{
						graphics.DrawImage(uncovered, new Rectangle(row, column, MineSize, MineSize));
						graphics.DrawString(CurrentState[row, column].ToString(), new("Arial", MineSize), new SolidBrush(Color.Black), new Point(row, column));
					}
					else
					{
						graphics.DrawImage(covered, new Rectangle(row, column, MineSize, MineSize));
					}
				}
			}
		}
	}
}
