using MinesweeperBackend;
using System.Diagnostics;

namespace UI.Minesweeper
{
	public partial class MinesweeperUI : Form
	{
		IMinesweeperPlayer Player;
		int GameCount = 0;
		int WinCount = 0;
		public MinesweeperUI() : this(30, 30, 20, new HumanPlayer(), false) { }
		public MinesweeperUI(int rows, int columns, int bombCount, IMinesweeperPlayer player, bool infinite, int betweenGameDelay = 2000)
		{
			InitializeComponent();
			Player = player;
			Player.OnUpdateState += (object? sender, ((int, int), byte) moveState) => { minesweeperBoard1.Invoke(() => { minesweeperBoard1.UpdateState(moveState); }); };
			Player.OnUpdateUI += (object? sender, EventArgs e) => { minesweeperBoard1.Invoke(() => { minesweeperBoard1.UpdateUI(); }); };
			minesweeperBoard1.MoveClick += (object? sender, (int, int) move) => { Player.HandleClick(move.Item1, move.Item2); };
			Task.Run(() =>
			{
				while (!this.IsHandleCreated) { } // Wait for UI
				do
				{
					StartGame(rows, columns, bombCount);
					Thread.Sleep(betweenGameDelay);
					Player.NewGame();
				} while (infinite);
			});
		}
		public void StartGame(int rows, int columns, int bombs)
		{
			minesweeperBoard1.Reset(rows, columns);
			Game game = new(rows, columns, bombs, Player);
			game.OnEnd += (object? sender, bool[,] bombs) => { minesweeperBoard1.HandleEnd(bombs); };
			if (game.Play())
			{
				WinCount++;
			}
			GameCount++;
			Debug.WriteLine($"Game Count: {GameCount}, WinCount: {WinCount}");
		}
	}
}
