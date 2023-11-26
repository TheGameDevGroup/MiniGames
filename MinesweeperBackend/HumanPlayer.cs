using System.Drawing;

namespace MinesweeperBackend
{
	public class HumanPlayer : IMineSweeperPlayer
	{
		public string Name { get; set; } = "Human";
		public Color Color { get; set; } = Color.Red;
		public EventHandler<byte?[,]>? OnUpdateUI { get; set; }

		private (int, int) ProposedMove;
		private ManualResetEvent ResetEvent = new(false);

		public (int, int) MakeMove(in byte?[,] boardState)
		{
			OnUpdateUI?.Invoke(this, boardState);
			ResetEvent.Reset();
			ResetEvent.WaitOne();
			return ProposedMove;
		}
		public void HandleClick(int row, int column)
		{
			ProposedMove = (row, column);
			ResetEvent.Set();
		}
	}
}
