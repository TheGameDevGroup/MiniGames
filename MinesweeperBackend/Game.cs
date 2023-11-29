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

		// Use to store valid locations for new bombs
		private (int, int) Replacement;
		public Game(int rows, int columns, int bombCount, IMinesweeperPlayer player)
		{
			TotalTileCount = rows * columns;
			TotalBombCount = bombCount;
			Player = player;
			Bombs = new bool[rows, columns];
			Uncovered = new bool[rows, columns];
			BombCounts = new byte[rows, columns];

			if (bombCount > TotalTileCount)
			{
				throw new ArgumentOutOfRangeException(nameof(bombCount));
			}

			PopulateBombs(rows, columns, bombCount);
		}
		/// <summary>
		/// Synchronously start the game.
		/// </summary>
		/// <returns>True if the game is won.</returns>
		public bool Play()
		{
			bool isFirstMove = true;
			while (true)
			{
				var move = Player.MakeMove(BombCounts.GetLength(0), BombCounts.GetLength(1));
				if (isFirstMove && Bombs[move.Item1, move.Item2])
				{
					// Move the bomb
					RemoveBomb(move.Item1, move.Item2);
					AddBomb(Replacement.Item1, Replacement.Item2);
				}
				isFirstMove = false;
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
		private void AddBomb(int row, int column)
		{
			if (!Bombs[row, column])
			{
				Bombs[row, column] = true;
				for (int i = row - 1; i <= row + 1; i++)
				{
					for(int j = column - 1; j <= column + 1; j++)
					{
						if (i >= 0 && j >= 0 && i < BombCounts.GetLength(0) && j < BombCounts.GetLength(1))
						{
							BombCounts[i, j]++;
						}
					}
				}
			}
		}
		private void PopulateBombs(int rows, int columns, int bombCount)
		{
			HashSet<(int, int)> locations = new();
			Random random = new();
			int row, column, randRow, randColumn;

			for (int i = 0; i <= bombCount; i++)
			{
				row = i / columns;
				column = i % columns;

				locations.Add((row, column));
			}

			for (int i = 0; i <= bombCount; i++)
			{
				row = i / columns;
				column = i % columns;

				randRow = random.Next(rows);
				randColumn = random.Next(columns);

				if (!locations.Contains((randRow, randColumn)))
				{
					locations.Remove((row, column));
					locations.Add((randRow, randColumn));
				}
				else
				{
					continue;
				}
			}

			int k = 0;
			foreach (var location in locations)
			{
				if (k < bombCount) AddBomb(location.Item1, location.Item2);
				else Replacement = location;
			}
		}
		private void RemoveBomb(int row, int column)
		{
			if (Bombs[row, column])
			{
				Bombs[row, column] = false;
				for (int i = row - 1; i <= row + 1; i++)
				{
					for (int j = column - 1; j <= column + 1; j++)
					{
						if (i >= 0 && j >= 0 && i < BombCounts.GetLength(0) && j < BombCounts.GetLength(1))
						{
							BombCounts[i, j]--;
						}
					}
				}
			}
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
		[Obsolete]
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
		[Obsolete]
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
	}
}
