using MinesweeperBackend;
using System.Diagnostics;
using UI.General;

namespace UI.Minesweeper
{
	public partial class MinesweeperUI : GameUIBase
	{
		public int Rows = 16;
		public int Columns = 30;
		public int BombCount = 99;

		public MinesweeperPlayerBase Player { get; private set; } = new HumanPlayer();
		int GameCount = 0;
		int WinCount = 0;

		CancellationTokenSource CTS = new();
		DateTime? startTime = null;
		public MinesweeperUI()
		{
			InitializeComponent();
			minesweeperBoard1.MoveClick += BoardClick;
			minesweeperBoard1.MassMoveClick += BoardMassClick;
			minesweeperBoard1.TileSize = 35;
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
			CTS.Cancel();
			CTS = new();
			LblBombCount.Text = $"{BombCount}";
			Task.Run(() =>
			{
				try
				{
					while (!this.IsHandleCreated) { } // Wait for UI
					minesweeperBoard1.Reset(Rows, Columns);
					Game game = new(Rows, Columns, BombCount, Player);
					game.OnEnd += (object? sender, bool[,] bombs) => { minesweeperBoard1.HandleEnd(bombs); };
					game.OnLose += (object? sender, (int, int) bomb) => { minesweeperBoard1.HighlightTiles([bomb]); };
					if (game.Play(CTS.Token))
					{
						WinCount++;
					}
					GameCount++;
					Debug.WriteLine($"Game Count: {GameCount}, WinCount: {WinCount}");
					CTS.Cancel();
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
				minesweeperBoard1.TileSize,
				minesweeperBoard1.CheckeredStyle,
				minesweeperBoard1.TileColorsCovered,
				minesweeperBoard1.TileColorsUncovered
			) { };
			if (settings.ShowDialog() == DialogResult.OK)
			{
				if (settings.Rows != Rows || settings.Columns != Columns || settings.BombCount != BombCount)
				{
					CTS.Cancel();
					Rows = settings.Rows;
					Columns = settings.Columns;
					BombCount = settings.BombCount;
				}
				minesweeperBoard1.TileSize = settings.TileSize;
				minesweeperBoard1.CheckeredStyle = settings.CheckeredStyle;
				minesweeperBoard1.TileColorsCovered = settings.CoveredColors;
				minesweeperBoard1.TileColorsUncovered = settings.UncoveredColors;
				if (CTS.IsCancellationRequested)
				{
					StartGame();
				}
				else
				{
					minesweeperBoard1.UpdateUI();
				}
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
		private void BoardMassClick(object? sender, IEnumerable<(int row, int column)> e)
		{
			this.Player.HandleMassClick(e);
		}
		private void BoardClick(object? sender, (int row, int column, bool ignoreClick) move)
		{
            LblBombCount.Text = $"{BombCount - minesweeperBoard1.FlagCount}";
            if (CTS.IsCancellationRequested)
			{
				StartGame();
			}
			else if (!move.ignoreClick)
			{
				StartTimer(CTS.Token);
				this.Player.HandleClick(move.row, move.column);
			}
		}
		private void StartTimer(CancellationToken token)
		{
			if (startTime != null) return; // timer already started
			startTime = DateTime.Now;
			Task.Run(() =>
			{
				while (!token.IsCancellationRequested)
				{
					LblTimePassed.Invoke(() =>
					{
						LblTimePassed.Text = $"{(DateTime.Now - startTime).Value.ToString("mm\\:ss")}";
					});
				}
				startTime = null;
			});
		}
	}
}
