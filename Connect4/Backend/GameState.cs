using System.Collections.Generic;

namespace Connect4.Backend
{
	internal struct Group
	{
		public int width = 1;
		public int height = 1;
		public int rdiag = 1;
		public int ldiag = 1;

		public Group() { }
	}

	internal struct Piece
	{
		public int playerToken = 0;
		public int groupId = 0;

		public Piece() { }
		public Piece(int groupId) { this.groupId = groupId; }
	}

	class GameState
	{
		private const int BOARD_HEIGHT = 6, BOARD_WIDTH = 7;
		private const int NUM_NEIGHBORS = 8;
		private const int TERMINAL_LENGTH = 4; // unused?
		private int[,] board = new int[BOARD_HEIGHT, BOARD_WIDTH];
		// specify the rows in which a piece can be placed
		private int[] moves = new int[BOARD_WIDTH];
        private int[] surr = new int[NUM_NEIGHBORS];

        private void SetSurrounding(ref int[] surr, int row, int col)
		{
			surr[0] = (row - 1 < 0) ? 0 : board[row - 1, col];
			surr[1] = (row + 1 >= BOARD_HEIGHT) ? 0 : board[row + 1, col];
			surr[2] = (col - 1 < 0) ? 0 : board[row, col - 1];
			surr[3] = (col + 1 >= BOARD_WIDTH) ? 0 : board[row, col + 1];
			surr[4] = (row - 1 < 0 || col - 1 < 0) ? 0 : board[row - 1, col - 1];
			surr[5] = (row + 1 >= BOARD_HEIGHT || col + 1 >= BOARD_WIDTH) ? 0 : board[row + 1, col + 1];
			surr[6] = (row - 1 < 0 || col + 1 >= BOARD_WIDTH) ? 0 : board[row - 1, col + 1];
			surr[7] = (row + 1 >= BOARD_HEIGHT || col - 1 < 0) ? 0 : board[row + 1, col - 1];
        }

        // surr: array of Pieces
        // cur: Piece
        // groups: List<Group> groups = new List<Group>(); INDEXING NEEDS TO START AT 1
        // End(): terminal function
        private bool IsTerminal(int playerToken, int row, int col)
		{
            bool isTerminal = false;

            SetSurrounding(ref surr, row, col);

			for (int i = 0; i < NUM_NEIGHBORS; i++)
			{
				Piece neighbor = surr[i]; // reference var?
				int curGroupId = neighbor.groupId;
                if (neighbor.playerToken != playerToken) continue;
				if (curGroupId == 0) continue;

				Group curGroup = groups[curGroupId]; // reference var?

				if (i == 0 || i == 1) isTerminal = checkWidth(row, col); // checks only need 3 pieces b/c of the new addition
				if (i == 2 || i == 3) isTerminal = checkHeight(row, col);
				if (i == 4 || i == 5) isTerminal = checkRdiag(row, col);
				if (i == 6 || i == 7) isTerminal = checkLdiag(row, col);

				cur.groupId = curGroupId;
			}
			
			if (cur.groupId == 0)
			{
				int newGroupId = groups.Count;
				Group group = new Group(newGroupId);
				groups.Add(group);
				cur.groupId = newGroupId;
			}

			return isTerminal;
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
			if (IsTerminal(playerToken, row, col)) End();

			// update the legal moves
			moves[col]++;
		}
	}
}
