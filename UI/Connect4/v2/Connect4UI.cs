using Connect4Backend;
using System.Diagnostics;

namespace UI.Connect4.v2
{
	public partial class Connect4UI : Form
	{
		public int Rows = 6;
		public int Columns = 7;
		public bool Infinite = true;
		public bool ShiftFirstPlayer = true;
		public int BetweenGameDelay = 2000;

		CancellationTokenSource CTS = new();

		List<IConnect4Player> Players = new();
		int Stalemates = 0;
		public Connect4UI()
		{
			InitializeComponent();
			AddPlayer(new HumanPlayer("Player 1", Color.Blue));
			AddPlayer(new RandomBot("Player 2", Color.Red, true));
			StartGame();
		}
		public void ClearPlayers()
		{
			Players.Clear();
		}
		public void AddPlayer(IConnect4Player player)
		{
			Players.Add(player);
			board1.ColumnClick += (object? sender, int column) => { player.HandleClick(column); };
		}
		public void StartGame()
		{
			CTS = new();
			var test = Task.Run(() =>
			{
				int result;
				do
				{
					Game game = new(Rows, Columns, Players)
					{
						WinningLength = 4,
					};
					game.OnMove += (object? sender, int[,] state) => { board1.Update(state, Players.Select(p => p.Color).ToList()); };
					game.OnWin += (object? sender, List<(int, int)> win) => { board1.HighlightPieces(win, Color.LawnGreen); };
					board1.Reset(Rows, Columns);
					result = game.Play(CTS.Token);
					if (CTS.IsCancellationRequested)
					{
						return;
					}
					if (result == -1)
					{
						Stalemates++;
					}
					else
					{
						Players[result].WinCount++;
					}
					string winString = $"Stalemates: {Stalemates}";
					for (int i = 0; i < Players.Count; i++)
					{
						var temp = Players.OrderBy(p => p.Name);
						winString += $"; {temp.ElementAt(i).Color.Name}: {temp.ElementAt(i).WinCount}";
					}
					Debug.WriteLine(winString);
					if (ShiftFirstPlayer)
					{
						var fp = Players.First();
						Players.Remove(fp);
						Players.Add(fp);
					}
					Thread.Sleep(BetweenGameDelay);
				} while (Infinite && !CTS.IsCancellationRequested);
				if (result == -1)
				{
					MessageBox.Show("Stalemate");
				}
				else
				{
					MessageBox.Show($"{Players[result].Name} Wins.");
				}
			}, CTS.Token);
		}
	}
}
