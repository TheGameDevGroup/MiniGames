using System.Drawing;

namespace MinesweeperBackend
{
	public class HumanPlayer : IMinesweeperPlayer
	{
		public string Name { get; set; } = "Human";
		public Color Color { get; set; } = Color.Red;
		public EventHandler<((int, int), byte)>? OnUpdateState { get; set; }
		public EventHandler? OnUpdateUI { get; set; }

		private (int, int) ProposedMove;
		private ManualResetEvent ResetEvent = new(false);

		public (int, int) MakeMove()
		{
			OnUpdateUI?.Invoke(this, new());
			ResetEvent.Reset();
			ResetEvent.WaitOne();
			return ProposedMove;
		}
		public void HandleClick(int row, int column)
		{
			ProposedMove = (row, column);
			ResetEvent.Set();
		}
		public void UpdateState(int row, int col, byte bombCount)
		{
			OnUpdateState?.Invoke(this, ((row, col), bombCount));
		}
		public void NewGame()
		{
			// Do nothing
		}
	}
}
