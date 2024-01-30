using System.Drawing;

namespace Connect4Backend
{
	public class HumanPlayer : Connect4PlayerBase
	{
		private readonly ManualResetEventSlim MoveSubmitEvent = new(false);
		private int ProposedMove;
		public HumanPlayer() : this("Human", Color.Blue) { }
		public HumanPlayer(string name, Color color)
		{
			Name = name;
			Color = color;
			PlayerType = "Human";
		}

		public override int MakeMove(in int[,] gameState, int playerToken)
		{
			MoveSubmitEvent.Reset();
			MoveSubmitEvent.Wait(CancellationToken);
			lock (this)
			{
				return ProposedMove;
			}
		}
		public override void HandleClick(int column)
		{
			lock (this)
			{
				ProposedMove = column;
				MoveSubmitEvent.Set();
			}
		}
	}
}
