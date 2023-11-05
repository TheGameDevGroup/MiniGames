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

		// determine whether a board space is populated with a playerToken
		private bool IsPlayerPiece(int row, int col, int playerToken)
		{
			bool isPlayerPiece = false;
			try
			{
				if (board[row, col] == playerToken) isPlayerPiece = true;
			}
			catch (IndexOutOfRangeException)
			{
				return isPlayerPiece;
			}
			return isPlayerPiece;
		}

		// find the number of playerToken's pieces in a specified direction
		private int CheckDirection(int row, int col, int rowInc, int colInc, int playerToken)
		{
			int count = 0;
			int next = playerToken;
			int j = col + colInc;
			for (int i = row + rowInc; ; i += rowInc, j += colInc)
			{
                if (IsPlayerPiece(i, j, playerToken)) count++;
                else break;
            }
			return count;
		}

		// determine if a 4-in-a-row has occurred
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
