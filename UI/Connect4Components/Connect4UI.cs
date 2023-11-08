using Connect4;

namespace UI
{
	public partial class Connect4UI : Form
	{
		List<IConnect4Player> players = new();
		public Connect4UI()
		{
			InitializeComponent();
			HumanPlayer player1 = new();
			HumanPlayer player2 = new();
			board1.MoveClick += (object? sender, int column) =>
			{
				player1.SubmitMove(column);
				player2.SubmitMove(column);
			};
			board1.ColorMap[1] = Color.Red;
			board1.ColorMap[2] = Color.Blue;
			players.Add(player1);
			players.Add(player2);
			Game game = new(6, 7, players);
			game.OnMove += (object? sender, int[,] state) => { board1.Update(state); };
			Task.Run(() =>
			{
				int result = game.Play();
				MessageBox.Show($"Player {result} Wins.");
			});
		}
	}
}
