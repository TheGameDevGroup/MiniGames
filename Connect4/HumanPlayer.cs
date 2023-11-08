namespace Connect4
{
	public class HumanPlayer : IConnect4Player
	{

		public event EventHandler<int[,]> UpdateUI;
		private ManualResetEventSlim MoveSubmitEvent = new(false);
		public int ProposedMove;
		public HumanPlayer(EventHandler<int[,]> updateUICallback)
		{
			UpdateUI = updateUICallback;
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
		public void SubmitMove(int column)
		{
			lock (this)
			{
				ProposedMove = column;
				MoveSubmitEvent.Set();
			}
		}
	}
}
