using Utilities.Extensions;

namespace MinesweeperBackend
{
	public class Game
	{
		/// <summary>
		/// Provides the array indicating which tiles have bombs
		/// </summary>
		public event EventHandler<bool[,]>? OnEnd;
		/// <summary>
		/// Triggers when the game is lost and provides the location of the bomb clicked
		/// </summary>
		public event EventHandler<(int, int)>? OnLose;

		public MinesweeperPlayerBase Player;

		private readonly bool[,] Bombs;
		private readonly bool[,] Uncovered;
		private readonly byte[,] BombCounts;

		private readonly int TotalBombCount;
		private int TotalClearedCount = 0;
		private readonly int TotalTileCount;

		// Use to store valid locations for new bombs
		private List<(int, int)> Replacement = new();
		public const int ReplacementBombCount = 9;
		public Game(int rows, int columns, int bombCount, MinesweeperPlayerBase player)
		{
			TotalTileCount = rows * columns;
			TotalBombCount = bombCount;
			Player = player;
			Bombs = new bool[rows, columns];
			Uncovered = new bool[rows, columns];
			BombCounts = new byte[rows, columns];

			ArgumentOutOfRangeException.ThrowIfGreaterThan(bombCount + ReplacementBombCount, TotalTileCount, nameof(bombCount));

			PopulateBombs(rows, columns, bombCount);
		}
		/// <summary>
		/// Synchronously start the game.
		/// </summary>
		/// <returns>True if the game is won.</returns>
		public bool Play(CancellationToken ct)
		{
			Player.CancellationToken = ct;
			bool isFirstMove = true;
			while (!ct.IsCancellationRequested)
			{
				var move = Player.MakeMove(BombCounts.GetLength(0), BombCounts.GetLength(1));
				if (isFirstMove)
				{
					// Filter the replacement list
					for(int i = move.Item1 - 1; i <= move.Item1 + 1; i++)
					{
						for (int j = move.Item2 - 1; j <= move.Item2 + 1; j++)
						{
							Replacement.RemoveAll(x => x.Item1 == i && x.Item2 == j);
						}
					}
					// Move the bomb
					for (int i = move.Item1 - 1; i <= move.Item1 + 1; i++)
					{
						for (int j = move.Item2 - 1; j <= move.Item2 + 1; j++)
						{
							if (i >= 0 && j >= 0 && i < Bombs.GetLength(0) && j < Bombs.GetLength(1) && Bombs[i, j])
							{
								RemoveBomb(i, j);
								AddBomb(Replacement.First().Item1, Replacement.First().Item2);
								Replacement.RemoveAt(0);
							}
						}
					}
				}
				isFirstMove = false;
				if (Bombs[move.Item1, move.Item2])
				{
					OnLose?.Invoke(this, move);
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
			return false;
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
		[Obsolete("Not truly random, earlier bombs have a higher chance.")]
		private HashSet<(int row, int column)> GenerateLocations_Mod(int rows, int columns, int count, Random random)
		{
			HashSet<(int, int)> toReturn = new();
			int row, column, randRow, randColumn;

			for (int i = 0; i < count; i++)
			{
				row = i / columns;
				column = i % columns;

				toReturn.Add((row, column));
			}

			for (int i = 0; i < count; i++)
			{
				row = i / columns;
				column = i % columns;

				randRow = random.Next(rows);
				randColumn = random.Next(columns);

				if (!toReturn.Contains((randRow, randColumn)))
				{
					toReturn.Remove((row, column));
					toReturn.Add((randRow, randColumn));
				}
				else
				{
					continue;
				}
			}
			return toReturn;
		}
		private HashSet<(int row, int column)> GenerateLocations(int rows, int columns, int count, Random random)
		{
			var locationsFlat = IEnumerableExtensions.PermuteIntegers(0, rows * columns - 1, random);
			var locations = new HashSet<(int, int)>();
			foreach (var location in locationsFlat)
			{
				locations.Add((location / columns, location % columns));
				if (locations.Count == count)
				{
					break;
				}
			}
			return locations;
		}
		private void PopulateBombs(int rows, int columns, int bombCount)
		{
			Random random = new();
			var locations = GenerateLocations(rows, columns, bombCount + ReplacementBombCount, random);
			int k = 0;
			Replacement = new();
			while (k++ < bombCount)
			{
				// randomly select a location
				var location = locations.ElementAt(random.Next(locations.Count));
				locations.Remove(location);
				AddBomb(location.Item1, location.Item2);
			}
			Replacement.AddRange(locations);
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
		/// <summary>
		/// Reveals the bombs array and breaks the game
		/// </summary>
		/// <returns></returns>
		public bool[,] GetBombs()
		{
			TotalClearedCount = -1; // Should now be impossible to win
			return Bombs;
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
