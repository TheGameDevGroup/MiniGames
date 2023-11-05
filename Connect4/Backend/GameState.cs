namespace Connect4.Backend
{
	class GameState
	{
		private const int BOARD_HEIGHT = 6, BOARD_WIDTH = 7;
		// specify the number of pieces in a row which ends the game
		// does not include the most recently placed piece
		private const int TERMINAL_LENGTH = 3;
		private int[,] board = new int[BOARD_HEIGHT, BOARD_WIDTH];
		// specify the rows in which a piece can be placed
		private int[] moves = new int[BOARD_WIDTH];

		private int getAdjacent(int row, int col, int playerToken)
		{
			int next = 0;
			try
			{
				if (board[row, col] == playerToken) next = playerToken;
			}
			catch (IndexOutOfRangeException)
			{
				return next;
			}
			return next;
		}

		private int CheckDirection(int row, int col, int rowInc, int colInc, int playerToken)
		{
			int count = 0;
			int next = playerToken;
			int j = col + colInc;
			for (int i = row + rowInc; ; i += rowInc, j += colInc)
			{
				next = getAdjacent(i, j, playerToken);
                if (next == playerToken) count++;
                else break;
            }
			return count;
		}

        private bool IsTerminal(int row, int col, int playerToken)
        {
            return CheckDirection(row, col, -1, 0, playerToken) >= TERMINAL_LENGTH ||
                   CheckDirection(row, col, 0, -1, playerToken) + CheckDirection(row, col, 0, 1, playerToken) >= TERMINAL_LENGTH ||
                   CheckDirection(row, col, -1, -1, playerToken) + CheckDirection(row, col, 1, 1, playerToken) >= TERMINAL_LENGTH ||
                   CheckDirection(row, col, -1, 1, playerToken) + CheckDirection(row, col, 1, -1, playerToken) >= TERMINAL_LENGTH;
        }

        private void End()
        {
            Console.WriteLine("END");
        }

        /// <summary>
        /// Place (drop) a board piece in the desired column. Updates the board and legal moves arrays.
        /// </summary>
        /// <param name="playerToken">Integer representation of the player who is placing. Should always be 1 or 2.</param>
        /// <param name="col">Column in which the new piece is to be placed. Should never be greater than 6.</param>
        public void Drop(int col, int playerToken)
		{
			// find the row where the piece is to be placed
			int row = moves[col];

			// update the board and check if a player has won
			board[row, col] = playerToken;
			if (IsTerminal(row, col, playerToken)) End();

			// update the legal moves
			moves[col]++;
		}
	}
}
