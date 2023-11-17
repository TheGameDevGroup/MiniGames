namespace Connect4Backend
{
	/// <summary>
	/// This is used to enforce common behavior across different implementations.
	/// 
	/// If you want to make a Connect 4 (AI) player, implement this interface.
	/// </summary>
	public interface IConnect4Player : Utilities.IGenericPlayer
	{
		/// <summary>
		/// Choose a move to play.
		/// </summary>
		/// <param name="gameState">An array representing the current game state. (rows then columns).</param>
		/// <param name="playerToken">The int that represents this player's pieces in the game.</param>
		/// <returns>A column number to drop a piece into.</returns>
		int MakeMove(in int[,] gameState, int playerToken);
		/// <summary>
		/// Optionally handle when a user clicks on the game board.
		/// </summary>
		/// <param name="column"></param>
		void HandleClick(int column) { }
	}
}
