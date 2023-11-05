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

		private int CheckBelow(int row, int col, int playerToken)
		{
			int count = 0;
			int next = playerToken;
			for (int i = row - 1; ; i--)
			{
				next = getAdjacent(i, col, playerToken);
				if (next == playerToken) count++;
				else break;
			}
			return count;
		}

		private int CheckLeft(int row, int col, int playerToken)
		{
			int count = 0;
			int next = playerToken;
			for (int i = col - 1; ; i--)
			{
				next = getAdjacent(row, i, playerToken);
				if (next == playerToken) count++;
				else break;
			}
			return count;
		}

		private int CheckRight(int row, int col, int playerToken)
		{
			int count = 0;
			int next = playerToken;
			for (int i = col + 1; ; i++)
			{
				next = getAdjacent(row, i, playerToken);
				if (next == playerToken) count++;
				else break;
			}
			return count;
		}

		private int CheckAboveLeft(int row, int col, int playerToken)
		{
			int count = 0;
			int next = playerToken;
			int j = col - 1;
			for (int i = row - 1; ; i--, j--)
			{
				next = getAdjacent(i, j, playerToken);
				if (next == playerToken) count++;
				else break;
			}
			return count;
		}

		private int CheckBelowRight(int row, int col, int playerToken)
		{
            int count = 0;
            int next = playerToken;
            int j = col + 1;
            for (int i = row + 1; ; i++, j++)
            {
                next = getAdjacent(i, j, playerToken);
                if (next == playerToken) count++;
                else break;
            }
            return count;
        }

        private int CheckAboveRight(int row, int col, int playerToken)
        {
            int count = 0;
            int next = playerToken;
            int j = col + 1;
            for (int i = row - 1; ; i--, j++)
            {
                next = getAdjacent(i, j, playerToken);
                if (next == playerToken) count++;
                else break;
            }
            return count;
        }

        private int CheckBelowLeft(int row, int col, int playerToken)
		{
			int count = 0;
			int next = playerToken;
			int j = col - 1;
			for (int i = row + 1; ; i++, j--)
			{
				next = getAdjacent(i, j, playerToken);
				if (next == playerToken) count++;
				else break;
			}
			return count;
		}

        private bool IsTerminal(int row, int col, int playerToken)
        {
            return CheckBelow(row, col, playerToken) >= TERMINAL_LENGTH ||
                   CheckLeft(row, col, playerToken) + CheckRight(row, col, playerToken) >= TERMINAL_LENGTH ||
                   CheckAboveLeft(row, col, playerToken) + CheckBelowRight(row, col, playerToken) >= TERMINAL_LENGTH ||
                   CheckAboveRight(row, col, playerToken) + CheckBelowLeft(row, col, playerToken) >= TERMINAL_LENGTH;
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
