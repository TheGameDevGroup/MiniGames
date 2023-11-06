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

		public Game(int rowCount, int columnCount, List<IConnect4Player> playerHandlers)
		{
			State = new int[rowCount, columnCount];
			Players = new(playerHandlers);
		}

		/// <summary>
		/// Checks if the player has won the game.
		/// </summary>
		/// <param name="columnIndex">The index of the column in which the last piece was placed</param>
		/// <param name="winningPosition">List of positions that make up the winning connect 4.</param>
		/// <returns></returns>
		private bool IsWinningMove(int columnIndex, out List<(int, int)> winningPosition)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Check if the game cannot continue. e.g., no moves left.
		/// </summary>
		/// <returns>True if stalemated.</returns>
		private bool IsStalemate()
		{
			int row = State.GetLength(0);
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
		private bool ValidMove(int column)
		{
			if (column >= State.GetLength(1))
			{
				return false;
			}
			else if (State[State.GetLength(0), column] != 0)
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
		private void PlaceMove(int column, int playerToken)
		{
			throw new NotImplementedException();

			// This invokes the event listeners
			OnMove?.Invoke(this, column);
		}

		/// <summary>
		/// Starts the game asynchronously.
		/// </summary>
		/// <returns>-1 if there is no winner; otherwise the player's index in <see cref="Players"/></returns>
		public async Task<int> Play()
		{
			return await Task.Run(() =>
			{
				while(true)
				{
					for (int i = 0; i < Players.Count; i++)
					{
						var player = Players[i];
						do
						{
							int move = player.MakeMove((int[,])State.Clone(), i + 1);
							if (ValidMove(move))
							{
								PlaceMove(move, i + 1);
								if (IsWinningMove(move, out var _))
								{
									return i;
								}
								else if (IsStalemate())
								{
									return -1;
								}
								break;
							}
							else
							{
								// The player made an invalid move... now what?
								throw new InvalidOperationException($"Player {i} attempted to make an invalid move.");
							}
						} while (true);
					}
				}
			});
		}
	}
}
