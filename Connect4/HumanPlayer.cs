using System.Drawing;

namespace Connect4
{
	public class HumanPlayer : IConnect4Player
	{
		public string Name { get; set; }
		public Color Color { get; set; }

		private readonly ManualResetEventSlim MoveSubmitEvent = new(false);
		private int ProposedMove;
		public HumanPlayer(string name, Color color)
		{
			Name = name;
			Color = color;
		}

		public int MakeMove(in int[,] gameState, int playerToken)
		{
			MoveSubmitEvent.Reset();
			MoveSubmitEvent.Wait();
			lock (this)
			{
				return ProposedMove;
			}
		}
		public void HandleClick(int column)
		{
			lock (this)
			{
				ProposedMove = column;
				MoveSubmitEvent.Set();
			}
		}
	}
}
