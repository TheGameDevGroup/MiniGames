namespace MinesweeperBackend
{
	public class Game
	{
		/// <summary>
		/// Provides the array indicating which tiles have bombs
		/// </summary>
		public event EventHandler<bool[,]>? OnEnd;

		public IMinesweeperPlayer Player;

		private readonly bool[,] Bombs;
		private readonly bool[,] Uncovered;
		private readonly byte[,] BombCounts;

		private readonly int TotalBombCount;
		private int TotalClearedCount = 0;
		private readonly int TotalTileCount;
		public Game(int rows, int columns, int bombCount, IMinesweeperPlayer player)
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
				// Make sure there is not already a bomb here
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
				var move = Player.MakeMove();
				if (Bombs[move.Item1, move.Item2])
				{
					OnEnd?.Invoke(this, Bombs);
					return false; // lost
				}
				else
				{
					DoMove(move.Item1, move.Item2);
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
		private byte CountSurroundingBombs(int row, int column)
		{
			// There is likely a better way to do this, any improvement is gladly accepted
			bool TryGetAt(int rowIndex, int columnIndex)
			{
				if (rowIndex < 0 || columnIndex < 0 || rowIndex >= Bombs.GetLength(0) || columnIndex >= Bombs.GetLength(1))
				{
					return false;
				}
				else
				{
					return Bombs[rowIndex, columnIndex];
				}
			}
			byte sum = 0;
			for (int i = row - 1; i <= row + 1; i++)
			{
				for (int j = column - 1; j <= column + 1; j++)
				{
					if (TryGetAt(i, j))
					{
						sum++;
					}
				}
			}
			return sum;
		}
		private void DoMove(int row, int column)
		{
			if (row < 0 || column < 0 || row >= Uncovered.GetLength(0) || column >= Uncovered.GetLength(1))
			{
				return; //invalid move
			}
			// Check for repeated move (e.i., already uncovered)
			if (Uncovered[row, column])
			{
				return;
			}
			Uncovered[row, column] = true;
			TotalClearedCount++;
			// Update state
			Player.UpdateState(row, column, BombCounts[row, column]);
			if (BombCounts[row, column] == 0 && !Bombs[row, column])
			{
				// Auto expand
				for (int i = row - 1; i <= row + 1; i++)
				{
					for (int j = column - 1; j <= column + 1; j++)
					{
						if (i != row || j != column)
						{
							DoMove(i, j);
						}
					}
				}
			}
		}
		private bool IsWin()
		{
			return TotalClearedCount == TotalTileCount - TotalBombCount;
		}
	}
}
