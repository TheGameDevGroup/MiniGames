using MinesweeperBackend;
using System.Diagnostics;
using Utilities;

namespace UI.Minesweeper
{
	public partial class MinesweeperUI : Form
	{
		public int Rows = 30;
		public int Columns = 30;
		public int BombCount = 20;
		public bool Infinite = true;
		public int BetweenGameDelay = 2000;

		public IMinesweeperPlayer Player { get; private set; } = new HumanPlayer();
		int GameCount = 0;
		int WinCount = 0;

		CancellationTokenSource CTS = new();
		public MinesweeperUI()
		{
			InitializeComponent();
			minesweeperBoard1.MoveClick += BoardClick;
			SetPlayer(new HumanPlayer());
		}
		public void Reset()
		{
			CTS.Cancel();
			GameCount = 0;
			WinCount = 0;
		}
		public void SetPlayer(IMinesweeperPlayer player)
		{
			Player = player;
			Player.OnUpdateState += PlayerUpdateState;
			Player.OnUpdateUI += PlayerUpdateUI;
		}
		public void StartGame()
		{
			CTS = new();
			Task.Run(() =>
			{
				try
				{
					while (!this.IsHandleCreated) { } // Wait for UI
					do
					{
						minesweeperBoard1.Reset(Rows, Columns);
						Game game = new(Rows, Columns, BombCount, Player);
						game.OnEnd += (object? sender, bool[,] bombs) => { minesweeperBoard1.HandleEnd(bombs); };
						if (game.Play(CTS.Token))
						{
							WinCount++;
						}
						GameCount++;
						Debug.WriteLine($"Game Count: {GameCount}, WinCount: {WinCount}");
						Thread.Sleep(BetweenGameDelay);
					} while (Infinite && !CTS.IsCancellationRequested);
				}
				catch (OperationCanceledException)
				{
					// do nothing
				}
			});
		}
		private void PlayerUpdateState(object? sender, ((int, int), byte) moveState)
		{
			minesweeperBoard1.Invoke(minesweeperBoard1.UpdateState, moveState);
		}
		private void PlayerUpdateUI(object? sender, EventArgs e)
		{
			minesweeperBoard1.Invoke(minesweeperBoard1.UpdateUI);
		}
		private void BoardClick(object? sender, (int, int) move)
		{
			this.Player.HandleClick(move.Item1, move.Item2);
		}
	}
}
