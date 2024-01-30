using Utilities;

namespace MinesweeperBackend
{
	public abstract class MinesweeperPlayerBase : GenericPlayerBase
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="columns"></param>
		/// <param name="rows"></param>
		/// <returns>The row and column to uncover.</returns>
		public abstract (int, int) MakeMove(int rows, int columns);
		/// <summary>
		/// Used to pass game state updates to the player
		/// The base implementation invokes <seealso cref="OnUpdateState"/> for UI updates.
		/// </summary>
		/// <param name="row"></param>
		/// <param name="col"></param>
		/// <param name="bombCount"></param>
		public void UpdateState(int row, int col, byte bombCount)
		{
			OnUpdateState?.Invoke(this, ((row, col), bombCount));
		}
		/// <summary>
		/// Optionally handle when a user clicks on the game board.
		/// </summary>
		/// <param name="row"></param>
		/// <param name="column"></param>
		public virtual void HandleClick(int row, int column) { }
		/// <summary>
		/// ((row, column), bombCount)
		/// Provide a hook for player specific UI updates.
		/// </summary>
		public EventHandler<((int, int), byte)>? OnUpdateState { get; set; }
		public EventHandler? OnUpdateUI { get; set; }
		/// <summary>
		/// Used to indicate that a new game has begun and the player should clear anything from the previous game.
		/// </summary>
		public abstract void NewGame();
	}
}
