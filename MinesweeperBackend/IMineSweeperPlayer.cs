using Utilities;

namespace MinesweeperBackend
{
	public interface IMineSweeperPlayer : IGenericPlayer
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="boardState">Null if not uncovered, otherwise the number of surrounding bombs.</param>
		/// <returns>The row and column to uncover.</returns>
		public (int, int) MakeMove(byte?[,] boardState);
		/// <summary>
		/// Optionally handle when a user clicks on the game board.
		/// </summary>
		/// <param name="row"></param>
		/// <param name="column"></param>
		public void HandleClick(int row, int column) { }
	}
}
