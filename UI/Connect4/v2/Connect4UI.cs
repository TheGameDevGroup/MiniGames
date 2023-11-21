using Connect4Backend;
using System.Diagnostics;

namespace UI.Connect4.v2
{
	public partial class Connect4UI : Form
	{
		List<IConnect4Player> Players = new();
		Dictionary<IConnect4Player, int> Wins = new();
		int Stalemates = 0;
		public Connect4UI() : this(6, 7) { }
		public Connect4UI(int rowCount, int columnCount)
		{
			InitializeComponent();
			//AddPlayer(new HumanPlayer("Red", Color.Red));
			//AddPlayer(new HumanPlayer("Blue", Color.Blue));
			AddPlayer(new HumanPlayer("Green", Color.Green));
			//AddPlayer(new RandomBot("Random 1", Color.Orange, false));
			AddPlayer(new RandomBot("Random 2", Color.Purple, true));
			StartGame(rowCount, columnCount, true, true);
		}
		public void AddPlayer(IConnect4Player player)
		{
			Players.Add(player);
			Wins[player] = 0;
			board1.ColumnClick += (object? sender, int column) => { player.HandleClick(column); };
		}
		public void StartGame(int rows, int columns, bool infinite = false, bool shiftFirstPlayer = false, int betweenGameDelay = 2000)
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
					game.OnMove += (object? sender, int[,] state) => { board1.Update(state, Players.Select(p => p.Color).ToList()); };
					game.OnWin += (object? sender, List<(int, int)> win) => { board1.HighlightPieces(win, Color.LawnGreen); };
					board1.Reset(rows, columns);
					result = game.Play();
					if (result == -1)
					{
						Stalemates++;
					}
					else
					{
						Wins[Players[result]]++;
					}
					string winString = $"Stalemates: {Stalemates}";
					for (int i = 0; i < Players.Count; i++)
					{
						var temp = Players.OrderBy(p => p.Name);
						winString += $"; {temp.ElementAt(i).Color.Name}: {Wins[temp.ElementAt(i)]}";
					}
					Debug.WriteLine(winString);
					if (shiftFirstPlayer)
					{
						var fp = Players.First();
						Players.Remove(fp);
						Players.Add(fp);
					}
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
