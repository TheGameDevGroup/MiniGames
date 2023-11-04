namespace Connect4.Backend
{
    class GameState
    {
        private const int BOARD_HEIGHT = 6, BOARD_WIDTH = 7;
        private int[,] board = new int[BOARD_HEIGHT, BOARD_WIDTH];
        // specify the rows in which a piece can be placed
        private int[] moves = new int[BOARD_WIDTH];
        
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
