namespace Connect4Backend
{
	public class Game
	{
		public event EventHandler<int[,]>? OnMove;

		public event EventHandler<List<(int,int)>>? OnWin;
		public List<Connect4PlayerBase> Players { get; private init; }
		/// <summary>
		/// [row, column]
		/// <br/>
		/// [0,0] is the bottom left corner of the board.
		/// </summary>
		public int[,] BoardState { get; init; }
		public int WinningLength { get; init; } = 4;

		public Game(int rowCount, int columnCount, List<Connect4PlayerBase> playerHandlers)
		{
			BoardState = new int[rowCount, columnCount];
			Players = new(playerHandlers);
		}


		/// <summary>
		/// Determine whether a board space is populated with a playerToken.
		/// </summary>
		/// <param name="row"></param>
		/// <param name="col"></param>
		/// <param name="playerToken"></param>
		/// <returns></returns>
		private bool IsPlayerPiece(int row, int col, int playerToken)
		{
			if (row >= BoardState.GetLength(0) || col >= BoardState.GetLength(1) || row < 0 || col < 0)
			{
				return false;
			}
			return BoardState[row, col] == playerToken;
		}

		/// <summary>
		/// Find the number of playerToken's pieces in both a specified direction and its opposite
		/// (e.g. up-right would also look down-left).
		/// </summary>
		/// <param name="row">The starting row.</param>
		/// <param name="rowInc">How the row index should be incremented.</param>
		/// <param name="col">The starting column.</param>
		/// <param name="colInc">How the column index shoud be incremented.</param>
		/// <param name="playerToken">Integer representation of the current player.</param>
		/// <param name="visitedPieces">The positions of each piece visited.</param>
		/// <returns>The number of pieces visited.</returns>
		private int CheckDirection(int row, int rowInc, int col, int colInc, int playerToken, out List<(int, int)> visitedPieces)
		{
			visitedPieces = new List<(int, int)>() { (row, col) };
			int count = 0;
			for (int k = 0; k < 2; k++)
			{
				int j = col + colInc;
				for (int i = row + rowInc; ; i += rowInc, j += colInc)
				{
					if (IsPlayerPiece(i, j, playerToken))
					{
						visitedPieces.Add((i, j));
						count++;
					}
					else break;
				}
				// Reverse the direction
				rowInc = (rowInc == 0) ? 0 : -rowInc;
				colInc = (colInc == 0) ? 0 : -colInc;
			}
			return count + 1;
		}

		/// <summary>
		/// Checks if the player has won the game.
		/// </summary>
		/// <param name="columnIndex">The index of the column in which the last piece was placed</param>
		/// <param name="winningPieces">List of positions that make up the winning connect 4.</param>
		/// <returns></returns>
		private bool IsWinningMove(int column, int row, out List<(int, int)> winningPieces)
		{
			int playerToken = BoardState[row, column];
			return CheckDirection(row, -1, column, 0, playerToken, out winningPieces) >= WinningLength ||
					CheckDirection(row, 0, column, -1, playerToken, out winningPieces) >= WinningLength ||
					CheckDirection(row, -1, column, -1, playerToken, out winningPieces) >= WinningLength ||
					CheckDirection(row, -1, column, 1, playerToken, out winningPieces) >= WinningLength;
		}

		/// <summary>
		/// Check if the game cannot continue (i.e. no moves left).
		/// </summary>
		/// <returns>True if stalemated.</returns>
		private bool IsStalemate()
		{
			// Only check the top row
			int row = BoardState.GetLength(0) - 1;
			for (int col = 0; col < BoardState.GetLength(1); col++)
			{
				if (BoardState[row, col] == 0) return false;
			}
			return true;
		}

		/// <summary>
		/// Check if the proposed move is valid (i.e. not outside the board).
		/// </summary>
		/// <param name="column">The column in which the player wishes to place their piece.</param>
		/// <returns>True if valid, false otherwise.</returns>
		private bool IsValidMove(int column)
		{
			if (column >= BoardState.GetLength(1) || column < 0) return false;
			else if (BoardState[BoardState.GetLength(0) - 1, column] != 0) return false;
			return true;
		}

		/// <summary>
		/// </summary>
		/// <param name="column">The column to drop the token into.</param>
		/// <param name="playerToken">Integer representation of the player.</param>
		/// <param name="placedRow">Used in IsWinningMove.</param>
		private void PlaceMove(int column, int playerToken, out int placedRow)
		{
			for (int i = 0; i < BoardState.GetLength(0); i++)
			{
				if (BoardState[i, column] == 0)
				{
					BoardState[i, column] = playerToken;
					placedRow = i;
					OnMove?.Invoke(this, (int[,])BoardState.Clone());
					return;
				}
			}
			throw new Exception("Invalid Move.");
		}

		/// <summary>
		/// Starts the game synchronously.
		/// </summary>
		/// <returns>-1 if there is no winner; otherwise the player's index in <see cref="Players"/></returns>
		public int Play(CancellationToken ct)
		{
			if (Players.Count == 0) return -1;
			Players.ForEach(p => p.CancellationToken = ct);
			while(!ct.IsCancellationRequested)
			{
				for (int i = 0; i < Players.Count; i++)
				{
					var player = Players[i];
					int playerToken = i + 1;

					// Loop until a valid move is made
					while (!ct.IsCancellationRequested)
					{
						// Get the move from the player
						int column = player.MakeMove((int[,])BoardState.Clone(), playerToken);
						if (IsValidMove(column))
						{
							PlaceMove(column, playerToken, out int row);
							if (IsWinningMove(column, row, out var win))
							{
								OnWin?.Invoke(this, win);
								return i;
							}
							else if (IsStalemate())
							{
								return -1;
							}
							// Go to the next player
							break;
						}
						else
						{
							// TODO: The player made an invalid move... now what?
							//throw new InvalidOperationException($"Player {i} attempted to make an invalid move.");
						}
					}
				}
			}
			return -1;
		}

		public void Driver()
		{
			// (column, playerToken)
			List<(int, int)> moves = new()
			{
				(3, 1), (4, 2),
				(4, 1), (5, 2),
				(3, 1), (5, 2),
				(5, 1), (4, 2),
				(6, 1), (3, 2),
				(6, 1), (3, 2),
				(3, 1), (4, 2),
				(2, 1), (2, 2),
				(1, 1), (0, 2),
				(3, 1), (1, 2),
				(2, 1), (0, 2),
				(4, 1), (1, 2),
				(6, 1), (6, 2),
				(5, 1),
			};
			foreach (var move in moves)
			{
				if (this.IsValidMove(move.Item1))
				{
					Console.WriteLine($"Player {move.Item2} making move {move.Item1}");
					this.PlaceMove(move.Item1, move.Item2, out int row);
					Console.WriteLine($"Checking for win");
					if (this.IsWinningMove(move.Item1, row, out List<(int, int)> _))
					{
						Console.WriteLine($"Win! Player: {move.Item2}");
					}
					else if (this.IsStalemate())
					{
						Console.WriteLine("Stalemate");
					}
				}
				else
				{
					Console.WriteLine($"Bad move: {move.Item1} by Player: {move.Item2}");
					return;
				}
			}
		}
	}
}
