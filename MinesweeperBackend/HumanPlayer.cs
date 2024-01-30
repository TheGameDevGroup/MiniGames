using System.Drawing;

namespace MinesweeperBackend
{
	public class HumanPlayer : MinesweeperPlayerBase
	{
		private (int, int) ProposedMove;
		private ManualResetEventSlim ResetEvent = new(false);
		public HumanPlayer() : this("Human", Color.Blue) { }
		public HumanPlayer(string name, Color color)
		{
			Name = name;
			Color = color;
		}
		public override (int, int) MakeMove(int rows, int columns)
		{
			OnUpdateUI?.Invoke(this, new());
			ResetEvent.Reset();
			ResetEvent.Wait(CancellationToken);
			return ProposedMove;
		}
		public override void HandleClick(int row, int column)
		{
			ProposedMove = (row, column);
			ResetEvent.Set();
		}
		public override void NewGame()
		{
			// Do nothing, can't clear human memory
		}
	}
}
