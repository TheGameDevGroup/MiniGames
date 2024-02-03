using Connect4Backend;
using System.Diagnostics;
using UI.General;

namespace UI.Connect4.v2
{
	public partial class Connect4UI : GameUIBase
	{
		public int Rows = 6;
		public int Columns = 7;
		public bool Infinite = true;
		public bool ShiftFirstPlayer = true;
		public int BetweenGameDelay = 2000;
		public int WinningLength = 4;

		CancellationTokenSource CTS = new();

		List<Connect4PlayerBase> Players = new();
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
		public void AddPlayer(Connect4PlayerBase player)
		{
			Players.Add(player);
			board1.ColumnClick += (object? sender, int column) => { player.HandleClick(column); };
		}
		public void StartGame()
		{
			if (Players.Count == 0) { return; }
			CTS = new();
			var test = Task.Run(() =>
			{
				var token = CTS.Token;
				try
				{
					int result;
					do
					{
						Game game = new(Rows, Columns, Players)
						{
							WinningLength = this.WinningLength,
						};
						game.OnMove += (object? sender, int[,] state) => { board1.Update(state, Players.Select(p => p.Color).ToList()); };
						game.OnWin += (object? sender, List<(int, int)> win) => { board1.HighlightPieces(win, Color.LawnGreen); };
						board1.Reset(Rows, Columns);
						result = game.Play(token);
						if (token.IsCancellationRequested)
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
					} while (Infinite && !token.IsCancellationRequested);
					if (!token.IsCancellationRequested)
					{
						if (result == -1)
						{
							MessageBox.Show("Stalemate");
						}
						else
						{
							MessageBox.Show($"{Players[result].Name} Wins.");
						}
					}
				}
				catch (OperationCanceledException) { }
			});
		}

		protected override void MenuSettings_Click(object sender, EventArgs e)
		{
			Connect4Settings settings = new(Players, Rows, Columns, WinningLength);
			if (settings.ShowDialog() == DialogResult.OK)
			{
				CTS.Cancel();
				Players.Clear();
				settings.GetPlayers().ForEach(AddPlayer);
				Rows = settings.RowCount;
				Columns = settings.ColumnCount;
				WinningLength = settings.WinLength;
				StartGame();
			}
		}
	}
}
