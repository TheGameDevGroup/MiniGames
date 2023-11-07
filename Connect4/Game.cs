using System.Numerics;

namespace Connect4
{
	public class Game
	{
		/// <summary>
		/// Event invoked after each move. Can be used to trigger updates to the UI.
		/// <br/>
		/// Event argument is an int corresponding to the column in which the last piece was played.
		/// </summary>
		public event EventHandler<int>? OnMove;
		public List<IConnect4Player> Players { get; init; }
		public int[,] State { get; init; }

		public int WinningLength { get; init; } = 4;

		public Game(int rowCount, int columnCount, List<IConnect4Player> playerHandlers)
		{
			State = new int[rowCount, columnCount];
			Players = new(playerHandlers);
		}


		// determine whether a board space is populated with a playerToken
		private bool IsPlayerPiece(int row, int col, int playerToken)
		{
			try
			{
				if (State[row, col] == playerToken) return true;
				return false;
			}
			catch (IndexOutOfRangeException)
			{
				return false;
			}
		}

		// find the number of playerToken's pieces in a specified direction
		private int CheckDirection(int row, int rowInc, int col, int colInc, int playerToken, out List<(int, int)> winningPieces)
		{
			winningPieces = new List<(int, int)>() { (row, col) };
            int count = 0;
			for (int k = 0; k < 2; k++)
			{
				int j = col + colInc;
				for (int i = row + rowInc; ; i += rowInc, j += colInc)
				{
					if (IsPlayerPiece(i, j, playerToken))
					{
						winningPieces.Add((i, j));
						count++;
					}
					else break;
				}
				rowInc = (rowInc == 0) ? 0 : -rowInc;
				colInc = (colInc == 0) ? 0 : -colInc;
			}
			return count;
		}

		/// <summary>
		/// Checks if the player has won the game.
		/// </summary>
		/// <param name="columnIndex">The index of the column in which the last piece was placed</param>
		/// <param name="winningPieces">List of positions that make up the winning connect 4.</param>
		/// <returns></returns>
		private bool IsWinningMove(int column, int row, out List<(int, int)> winningPieces)
		{
			int playerToken = State[row, column];
			int terminalLength = WinningLength - 1;
            return CheckDirection(row, -1, column, 0, playerToken, out winningPieces) >= terminalLength ||
					CheckDirection(row, 0, column, -1, playerToken, out winningPieces) >= terminalLength ||
					CheckDirection(row, -1, column, -1, playerToken, out winningPieces) >= terminalLength ||
					CheckDirection(row, -1, column, 1, playerToken, out winningPieces) >= terminalLength;
		}

		/// <summary>
		/// Check if the game cannot continue. e.g., no moves left.
		/// </summary>
		/// <returns>True if stalemated.</returns>
		private bool IsStalemate()
		{
			int row = State.GetLength(0) - 1;
			for (int col = 0; col < State.GetLength(1); col++)
			{
				if (State[row, col] == 0)
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// Check if the proposed move is valid.
		/// </summary>
		/// <param name="column">The column in which the player wishes to place their piece.</param>
		/// <returns>True if valid, false otherwise.</returns>
		private bool IsValidMove(int column)
		{
			if (column >= State.GetLength(1) || column < 0)
			{
				return false;
			}
			else if (State[State.GetLength(0) - 1, column] != 0)
			{
				return false;
			}
			return true;
		}

		/// <summary>
		/// Make a move
		/// </summary>
		/// <param name="column">The column to drop the token into.</param>
		/// <param name="playerToken">int representing the player's token.</param>
		private void PlaceMove(int column, int playerToken, out int placedRow)
		{
			for (int i = 0; i < State.GetLength(0); i++)
			{
				// find the row where the piece is to be placed
				if (State[i, column] == 0)
				{
					// update the board and check if a player has won
					State[i, column] = playerToken;
					placedRow = i;
					// This invokes the event listeners
					OnMove?.Invoke(this, column);
					return;
				}
			}
			// This should have gotten caught earlier...
			throw new Exception("Invalid Move.");
		}

		/// <summary>
		/// Starts the game synchronously.
		/// </summary>
		/// <returns>-1 if there is no winner; otherwise the player's index in <see cref="Players"/></returns>
		public int Play()
		{
			while(true)
			{
				// Loop through each player
				for (int i = 0; i < Players.Count; i++)
				{
					var player = Players[i];
					// Keep looping until they make a valid move
					do
					{
						// Get the move from the player
						int move = player.MakeMove((int[,])State.Clone(), i + 1);
						if (IsValidMove(move))
						{
							// Make the move (update the state)
							PlaceMove(move, i + 1, out int row);
							// Check if the move causes a win
							if (IsWinningMove(move, row, out var _))
							{
								// Return the index of the player
								return i;
							}
							else if (IsStalemate())
							{
								// Nobody wins
								return -1;
							}
							// Next player
							break;
						}
						else
						{
							// TODO: The player made an invalid move... now what?
							throw new InvalidOperationException($"Player {i} attempted to make an invalid move.");
						}
					} while (true);
				}
			}
		}
	}
}
