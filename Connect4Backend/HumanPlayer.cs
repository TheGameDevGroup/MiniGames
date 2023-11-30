using System.Drawing;

namespace Connect4Backend
{
	public class HumanPlayer : IConnect4Player
	{
		public string Name { get; set; }
		public Color Color { get; set; }
		public int WinCount { get; set; }
		public IConnect4Player.PlayerTypes PlayerType => IConnect4Player.PlayerTypes.Human;
		public CancellationToken CancellationToken { get; set; }

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
			MoveSubmitEvent.Wait(CancellationToken);
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
