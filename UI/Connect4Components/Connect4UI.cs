using Connect4;

namespace UI
{
	public partial class Connect4UI : Form
	{
		List<IConnect4Player> Players = new();
		public Connect4UI(int rows, int columns)
		{
			InitializeComponent();
			board1.SetTokenSize(100);
			AddPlayer(new HumanPlayer("Red", Color.Red));
			AddPlayer(new HumanPlayer("Blue", Color.Blue));
			//AddPlayer(new HumanPlayer("Green", Color.Green));
			StartGame(rows, columns);
		}
		public void AddPlayer(IConnect4Player player)
		{
			Players.Add(player);
			board1.ColorMap.Add(player.Color);
			board1.MoveClick += (object? sender, int column) => { player.HandleClick(column); };
		}
		public void StartGame(int rows, int columns)
		{
			board1.Reset(rows, columns);
			Game game = new(rows, columns, Players);
			game.OnMove += (object? sender, int[,] state) => { board1.Update(state); };
			game.OnWin += (object? sender, List<(int, int)> win) => { board1.HighlightPieces(win, Color.LawnGreen); };
			Task.Run(() =>
			{
				int result = game.Play();
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
