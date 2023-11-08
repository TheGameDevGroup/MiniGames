namespace Connect4
{
	public class HumanPlayer : IConnect4Player
	{

		private ManualResetEventSlim MoveSubmitEvent = new(false);
		private int ProposedMove;
		public HumanPlayer()
		{
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
