using Connect4Backend;

namespace UI.Connect4.v2
{
	public partial class Connect4Settings : Form
	{
		public Dictionary<string, Func<Connect4PlayerSettings, IConnect4Player>> PlayerTypes = new()
		{
			{"Human", (Connect4PlayerSettings ps) => new HumanPlayer(ps.PlayerName, ps.PlayerColor) },
			{"Random (Simple)", (Connect4PlayerSettings ps) => new RandomBot(ps.PlayerName, ps.PlayerColor, false) },
			{"Random (Weighted)", (Connect4PlayerSettings ps) => new RandomBot(ps.PlayerName, ps.PlayerColor, true) },
		};
		public Connect4Settings()
		{
			InitializeComponent();
			AddPlayer();
		}
		public List<IConnect4Player> GetPlayers()
		{
			return PanPlayers.Controls.Cast<Connect4PlayerSettings>().Select(ps =>
			{
				if (PlayerTypes.TryGetValue(ps.PlayerType, out var func))
				{
					return func(ps);
				}
				throw new ArgumentException("Bad player type.");
			}).ToList();
		}
		public void AddPlayer()
		{
			Connect4PlayerSettings newPlayer = new();
			newPlayer.SetTypes(PlayerTypes.Keys);
			newPlayer.OnRemoveMe += (object? sender, EventArgs e) =>
			{
				RemovePlayer((Connect4PlayerSettings)sender!);
			};
			PanPlayers.Controls.Add(newPlayer);
		}
		private void RemovePlayer(Connect4PlayerSettings player)
		{
			PanPlayers.Controls.Remove(player);
		}
		private void BtnAddPlayer_Click(object sender, EventArgs e)
		{
			AddPlayer();
		}
	}
}
