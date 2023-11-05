namespace Connect4.Backend
{
	class GameState
	{
		private const int BOARD_HEIGHT = 6, BOARD_WIDTH = 7;
		private const int NUM_NEIGHBORS = 8;
		private const int TERMINAL_LENGTH = 4; // unused?
		private int[,] board = new int[BOARD_HEIGHT, BOARD_WIDTH];
		// specify the rows in which a piece can be placed
		private int[] moves = new int[BOARD_WIDTH];

		private int checkAbove(int row, int col, int playerToken, int count = 0)
		{	
			if (board[row, col] != playerToken) return count;
			if (row == BOARD_HEIGHT - 1) return count++;

			count++;
			count = checkAbove(row + 1, col, playerToken, count);
			return count;
		}

        private int checkBelow(int row, int col, int playerToken, int count = 0)
        {
            if (board[row, col] != playerToken) return count;
            if (row == 0) return count++;

            count++;
            count = checkBelow(row - 1, col, playerToken, count);
            return count;
        }

        private int checkLeft(int row, int col, int playerToken, int count = 0)
        {
            if (board[row, col] != playerToken) return count;
            if (col == 0) return count++;

            count++;
            count = checkLeft(row, col - 1, playerToken, count);
            return count;
        }

        private int checkRight(int row, int col, int playerToken, int count = 0)
        {
            if (board[row, col] != playerToken) return count;
            if (col == BOARD_WIDTH - 1) return count++;

            count++;
            count = checkRight(row, col + 1, playerToken, count);
            return count;
        }

        private int checkAboveLeft(int row, int col, int playerToken, int count = 0)
        {
            if (board[row, col] != playerToken) return count;
            if (row == 0 || col == 0) return count++;

            count++;
            count = checkAboveLeft(row - 1, col - 1, playerToken, count);
            return count;
        }

        private int checkBelowRight(int row, int col, int playerToken, int count = 0)
        {
            if (board[row, col] != playerToken) return count;
            if (row == BOARD_HEIGHT - 1 || col == BOARD_WIDTH - 1) return count++;

            count++;
            count = checkBelowRight(row + 1, col + 1, playerToken, count);
            return count;
        }

        private int checkAboveRight(int row, int col, int playerToken, int count = 0)
        {
            if (board[row, col] != playerToken) return count;
            if (row == 0 || col == BOARD_WIDTH - 1) return count++;

            count++;
            count = checkAboveRight(row - 1, col + 1, playerToken, count);
            return count;
        }

        private int checkBelowLeft(int row, int col, int playerToken, int count = 0)
        {
            if (board[row, col] != playerToken) return count;
            if (row == BOARD_HEIGHT - 1 || col == 0) return count++;

            count++;
            count = checkBelowLeft(row + 1, col - 1, playerToken, count);
            return count;
        }

        private bool IsTerminal(int row, int col, int playerToken)
		{
			return checkAbove(row, col, playerToken) + checkBelow(row, col, playerToken) >= TERMINAL_LENGTH ||
				   checkLeft(row, col, playerToken) + checkRight(row, col, playerToken) >= TERMINAL_LENGTH ||
				   checkAboveLeft(row, col, playerToken) + checkBelowRight(row, col, playerToken) >= TERMINAL_LENGTH ||
				   checkAboveRight(row, col, playerToken) + checkBelowLeft(row, col, playerToken) >= TERMINAL_LENGTH;
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
