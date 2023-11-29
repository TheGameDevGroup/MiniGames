using Utilities;

namespace MinesweeperBackend
{
	public interface IMinesweeperPlayer : IGenericPlayer
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="columns"></param>
		/// <param name="rows"></param>
		/// <returns>The row and column to uncover.</returns>
		public (int, int) MakeMove(int rows, int columns);
		public void UpdateState(int row, int col, byte bombCount)
		{
			OnUpdateState?.Invoke(this, ((row, col), bombCount));
		}
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
		/// <summary>
		/// Used to indicate that a new game has begun and the player should clear anything from the previous game.
		/// </summary>
		public void NewGame();
	}
}
