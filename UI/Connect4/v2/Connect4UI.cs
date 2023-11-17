using Connect4Backend;
using System.Diagnostics;

namespace UI.Connect4.v2
{
	public partial class Connect4UI : Form
	{
		List<IConnect4Player> Players = new();
		Dictionary<int, int> Wins = new();
		public Connect4UI() : this(6, 7) { }
		public Connect4UI(int rowCount, int columnCount)
		{
			InitializeComponent();
			//AddPlayer(new HumanPlayer("Red", Color.Red));
			//AddPlayer(new HumanPlayer("Blue", Color.Blue));
			//AddPlayer(new HumanPlayer("Green", Color.Green));
			AddPlayer(new RandomBot("Random 1", Color.Orange, false));
			AddPlayer(new RandomBot("Random 2", Color.Purple, true));
			Wins[-1] = 0;
			StartGame(rowCount, columnCount, true);
		}
		public void AddPlayer(IConnect4Player player)
		{
			Players.Add(player);
			Wins[Players.Count - 1] = 0;
			board1.ColorMap.Add(player.Color);
			board1.ColumnClick += (object? sender, int column) => { player.HandleClick(column); };
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
					result = game.Play();
					Wins[result]++;
					string winString = $"Stalemates: {Wins[-1]}";
					for (int i = 0; i < Players.Count; i++)
					{
						winString += $"; {i}: {Wins[i]}";
					}
					Debug.WriteLine(winString);
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
