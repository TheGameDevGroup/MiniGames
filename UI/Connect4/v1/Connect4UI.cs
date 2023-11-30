using Connect4Backend;

namespace UI.Connect4.v1
{
	public partial class Connect4UI : Form
	{
		List<IConnect4Player> Players { get; set; } = new();
		public Connect4UI(int rows, int columns)
		{
			InitializeComponent();
			board1.SetTokenSize(100);
			//AddPlayer(new HumanPlayer("Red", Color.Red));
			//AddPlayer(new HumanPlayer("Blue", Color.Blue));
			//AddPlayer(new HumanPlayer("Green", Color.Green));
			AddPlayer(new RandomBot("Random 1", Color.Orange, false));
			AddPlayer(new RandomBot("Random 2", Color.Purple, true));
			StartGame(rows, columns, true);
		}
		public void AddPlayer(IConnect4Player player)
		{
			Players.Add(player);
			board1.ColorMap.Add(player.Color);
			board1.MoveClick += (object? sender, int column) => { player.HandleClick(column); };
		}
		public void StartGame(int rows, int columns, bool infinite = false, int betweenGameDelay = 2000)
		{
			Task.Run(() =>
			{
				int result;
				do
				{
					Game game = new(rows, columns, Players)
					{
						WinningLength = 4,
					};
					game.OnMove += (object? sender, int[,] state) => { board1.Update(state); };
					game.OnWin += (object? sender, List<(int, int)> win) => { board1.HighlightPieces(win, Color.LawnGreen); };
					board1.Reset(rows, columns);
					result = game.Play(new CancellationToken());

					Thread.Sleep(betweenGameDelay);
				} while (infinite);
				if (result == -1)
				{
					MessageBox.Show("Stalemate");
				}
				else
				{
					MessageBox.Show($"{Players[result].Name} Wins.");
				}
			});
		}
	}
}
