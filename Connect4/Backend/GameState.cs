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
		public int player = 0;
		public int groupId = 0;

		public Piece() { }
		public Piece(int groupId) { this.groupId = groupId; }
	}
	class GameState
	{
		private const int BOARD_HEIGHT = 6, BOARD_WIDTH = 7;
		private const int NUM_NEIGHBORS = 8;
		private const int TERMINAL_LENGTH = 4;
		private int[,] board = new int[BOARD_HEIGHT, BOARD_WIDTH];
		// specify the rows in which a piece can be placed
		private int[] moves = new int[BOARD_WIDTH];

		private void setSurrounding()
		{

		}
		
		// surr: array of Pieces
		// cur: Piece
		// groups: List<Group> groups = new List<Group>();
		// End(): terminal function
		private void UpdateGroups(int player)
		{
			for (int i = 0; i < NUM_NEIGHBORS; i++)
			{
				Piece neighbor = surr[i]; // reference var?

				if (neighbor.player != player) continue;
				if (neighbor.groupId ==  0) continue;

				int curGroupId = neighbor.groupId;
				Group curGroup = groups[curGroupId]; // reference var?

				// TODO: use a pointer which points to curGroup.width for example
				if (i == 0 || i == 1)
				{
					curGroup.width++;
					if (curGroup.width >= TERMINAL_LENGTH) End();
				}
				if (i == 2 || i == 3)
				{
					curGroup.height++;
					if (curGroup.height >= TERMINAL_LENGTH) End();
				}
				if (i == 4 || i == 5)
				{
					curGroup.rdiag++;
					if (curGroup.rdiag >= TERMINAL_LENGTH) End();
				}
				if (i == 6 || i == 7)
				{
					curGroup.ldiag++;
					if (curGroup.ldiag >= TERMINAL_LENGTH) End();
				}
				cur.groupId = curGroupId;
			}
			
			if (cur.groupId == 0)
			{
				int newGroupId = groups.Count;
				Group group = new Group(newGroupId);
				groups.Add(group);
				cur.groupId = newGroupId;
			}
		}

		/// <summary>
		/// Place (drop) a board piece in the desired column. Updates the board and legal moves arrays.
		/// </summary>
		/// <param name="player">Integer representation of the player who is placing. Should always be 1 or 2.</param>
		/// <param name="col">Column in which the new piece is to be placed. Should never be greater than 6.</param>
		public void drop(int player, int col)
		{
			board[moves[col], col] = player;
			moves[col]++;
		}
	}
}
