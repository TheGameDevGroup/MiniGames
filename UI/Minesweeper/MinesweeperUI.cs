using MinesweeperBackend;
using System.Diagnostics;
using UI.Connect4.v2;
using UI.General;

namespace UI.Minesweeper
{
	public partial class MinesweeperUI : GameUIBase
	{
		public int Rows = 30;
		public int Columns = 30;
		public int BombCount = 20;
		public bool Infinite = true;
		public int BetweenGameDelay = 2000;

		public MinesweeperPlayerBase Player { get; private set; } = new HumanPlayer();
		int GameCount = 0;
		int WinCount = 0;

		CancellationTokenSource CTS = new();
		public MinesweeperUI()
		{
			InitializeComponent();
			minesweeperBoard1.MoveClick += BoardClick;
			SetPlayer(new HumanPlayer());
			StartGame();
		}
		public void Reset()
		{
			CTS.Cancel();
			GameCount = 0;
			WinCount = 0;
		}
		public void SetPlayer(MinesweeperPlayerBase player)
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
		protected override void MenuSettings_Click(object sender, EventArgs e)
		{
			MinesweeperSettings settings = new(
				Rows,
				Columns,
				BombCount,
				minesweeperBoard1.CheckeredStyle,
				minesweeperBoard1.TileColorsCovered,
				minesweeperBoard1.TileColorsUncovered
			) { };
			if (settings.ShowDialog() == DialogResult.OK)
			{
				Rows = settings.Rows;
				Columns = settings.Columns;
				BombCount = settings.BombCount;
				minesweeperBoard1.CheckeredStyle = settings.CheckeredStyle;
				minesweeperBoard1.TileColorsCovered = settings.CoveredColors;
				minesweeperBoard1.TileColorsUncovered = settings.UncoveredColors;
				StartGame();
			}
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
