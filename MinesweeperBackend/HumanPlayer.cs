using System.Drawing;

namespace MinesweeperBackend
{
	public class HumanPlayer : MinesweeperPlayerBase
	{
		private (int, int) ProposedMove;
		private Queue<(int, int)> ProposedMassMove = new();
		private ManualResetEventSlim ResetEvent = new(false);
		public HumanPlayer() : this("Human", Color.Blue) { }
		public HumanPlayer(string name, Color color)
		{
			Name = name;
			Color = color;
		}
		public override (int, int) MakeMove(int rows, int columns)
		{
			if (ProposedMassMove.TryDequeue(out var move))
			{
				return move;
			}
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
		public override void HandleMassClick(IEnumerable<(int row, int column)> clicks)
		{
			if (ProposedMassMove.Any()) return; // Only allow one mass move at a time
			ProposedMassMove = new(clicks);
			ProposedMove = ProposedMassMove.Dequeue();
			ResetEvent.Set();
		}
		public override void NewGame()
		{
			// Do nothing, can't clear human memory
		}
	}
}
