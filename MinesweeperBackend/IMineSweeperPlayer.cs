using Utilities;

namespace MinesweeperBackend
{
	public interface IMinesweeperPlayer : IGenericPlayer
	{
		/// <summary>
		/// 
		/// </summary>
		/// <returns>The row and column to uncover.</returns>
		public (int, int) MakeMove();
		public void UpdateState(int row, int col, byte bombCount);
		/// <summary>
		/// Optionally handle when a user clicks on the game board.
		/// </summary>
		/// <param name="row"></param>
		/// <param name="column"></param>
		public void HandleClick(int row, int column) { }
		/// <summary>
		/// ((row, column), bombCount)
		/// </summary>
		public EventHandler<((int, int), byte)>? OnUpdateState { get; set; }
		public EventHandler? OnUpdateUI { get; set; }
		public void NewGame();
	}
}
