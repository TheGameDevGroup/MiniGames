namespace MinesweeperBackend
{
	public class Game
	{
		/// <summary>
		/// Provides the location selected, the number of surrounding bombs, and whether that tile is a bomb
		/// </summary>
		public event EventHandler<((int,int),byte, bool)>? OnMove;
		/// <summary>
		/// Provides the array indicating which tiles have bombs
		/// </summary>
		public event EventHandler<bool[,]>? OnEnd;

		public IMineSweeperPlayer Player;

		private readonly bool[,] Bombs;
		private readonly bool[,] Uncovered;
		private readonly byte[,] BombCounts;
		private readonly int TotalBombCount;
		private int TotalClearedCount = 0;
		private readonly int TotalTileCount;
		public Game(int rows, int columns, int bombCount, IMineSweeperPlayer player)
		{
			TotalTileCount = rows * columns;
			TotalBombCount = bombCount;
			Player = player;
			Bombs = new bool[rows, columns];
			Uncovered = new bool[rows, columns];
			BombCounts = new byte[rows, columns];
			// There is probably a better way to populate the bombs
			Random random = new();
			for (int i = 0; i < bombCount; )
			{
				int r = random.Next(rows);
				int c = random.Next(columns);
				if (!Bombs[r, c])
				{
					Bombs[r, c] = true;
					i++;
				}
			}
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					BombCounts[i, j] = CountSurroundingBombs(i, j);
				}
			}
		}
		/// <summary>
		/// Synchronously start the game.
		/// </summary>
		/// <returns>True if the game is won.</returns>
		public bool Play()
		{
			while (true)
			{
				var move = Player.MakeMove(BuildState());
				if (Bombs[move.Item1, move.Item2])
				{
					OnMove?.Invoke(this, (move, BombCounts[move.Item1, move.Item2], true));
					OnEnd?.Invoke(this, Bombs);
					return false; // lost
				}
				else
				{
					DoMove(move.Item1, move.Item2);
					OnMove?.Invoke(this, (move, BombCounts[move.Item1, move.Item2], false));
					if (IsWin())
					{
						OnEnd?.Invoke(this, Bombs);
						return true; // win
					}
				}
			}
		}
		private byte?[,] BuildState()
		{
			int r = Uncovered.GetLength(0);
			int c = Uncovered.GetLength(1);
			var toReturn = new byte?[r, c];
			for (int i = 0; i < r; i++)
			{
				for (int j = 0; j < c; j++)
				{
					toReturn[i, j] = Uncovered[i, j] ? BombCounts[i, j] : null;
				}
			}
			return toReturn;
		}
		private byte CountSurroundingBombs(int rowIndex, int columnIndex)
		{
			throw new NotImplementedException();
		}
		private void DoMove(int row, int column)
		{
			// TODO: check for invalid move

			// Check for repeated move (e.i., already uncovered)
			if (!Uncovered[row, column])
			{
				Uncovered[row, column] = true;
				TotalClearedCount++;
			}
			if (BombCounts[row, column] == 0 && !Bombs[row, column])
			{
				// Auto expand
				DoMove(row - 1, column - 1);
				DoMove(row - 1, column);
				DoMove(row - 1, column + 1);
				DoMove(row, column - 1);
				DoMove(row, column + 1);
				DoMove(row + 1, column - 1);
				DoMove(row + 1, column);
				DoMove(row + 1, column + 1);
			}
		}
		private bool IsWin()
		{
			return TotalClearedCount == TotalTileCount - TotalBombCount;
		}
	}
}
