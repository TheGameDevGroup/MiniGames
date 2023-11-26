using MinesweeperBackend;

namespace UI.Minesweeper
{
	public partial class MinesweeperUI : Form
	{
		IMineSweeperPlayer Player = new HumanPlayer();
		public MinesweeperUI() : this(30, 30) { }
		public MinesweeperUI(int rows, int columns)
		{
			InitializeComponent();
			minesweeperBoard1.MoveClick += (object? sender, (int, int) move) => { Player.HandleClick(move.Item1, move.Item2); };
			StartGame(rows, columns, 10);
		}
		public void StartGame(int rows, int columns, int bombs)
		{
			minesweeperBoard1.Reset(rows, columns);
			Player.OnUpdateUI += (object? sender, byte?[,] state) => { minesweeperBoard1.Invoke(() => { minesweeperBoard1.UpdateUI(state); }); };
			Game game = new(rows, columns, bombs, Player);
			game.OnEnd += (object? sender, bool[,] bombs) => { minesweeperBoard1.HandleEnd(bombs); };
			Task.Run(() => {
				while (!this.IsHandleCreated) { } // Wait for UI
				game.Play();
			});
		}
	}
}
