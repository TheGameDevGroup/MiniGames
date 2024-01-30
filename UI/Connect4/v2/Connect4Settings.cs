using Connect4Backend;

namespace UI.Connect4.v2
{
	public partial class Connect4Settings : Form
	{
		Dictionary<IConnect4Player.PlayerTypes, Func<Connect4PlayerSettings, IConnect4Player>> PlayerTypesMap = new()
		{
			{ IConnect4Player.PlayerTypes.Human, (Connect4PlayerSettings ps) => new HumanPlayer(ps.PlayerName, ps.PlayerColor) },
			{ IConnect4Player.PlayerTypes.RandomSimple, (Connect4PlayerSettings ps) => new RandomBot(ps.PlayerName, ps.PlayerColor, false) },
			{ IConnect4Player.PlayerTypes.RandomWeighted, (Connect4PlayerSettings ps) => new RandomBot(ps.PlayerName, ps.PlayerColor, true) },
		};
		List<IConnect4Player.PlayerTypes> PlayerTypes;
		public Connect4Settings()
			: this(new List<IConnect4Player>() { new HumanPlayer() }, 6, 7, 4)
		{ }
		public Connect4Settings(IEnumerable<IConnect4Player> players, int rows, int columns, int winLength)
		{
			PlayerTypes = PlayerTypesMap.Keys.ToList();
			InitializeComponent();
			boardSizeSettings.Rows = rows;
			boardSizeSettings.Columns = columns;
			NumWinLength.Value = winLength;
			foreach (var player in players)
			{
				AddPlayer(player);
			}
		}
		public int RowCount => boardSizeSettings.Rows;
		public int ColumnCount => boardSizeSettings.Columns;
		public int WinLength => (int)NumWinLength.Value;
		public List<IConnect4Player> GetPlayers()
		{
			return PanPlayers.Controls.Cast<Connect4PlayerSettings>().Select(ps =>
			{
				if (PlayerTypesMap.TryGetValue(PlayerTypes[ps.PlayerType], out var func))
				{
					return func(ps);
				}
				throw new ArgumentException("Bad player type.");
			}).ToList();
		}
		public void AddPlayer(IConnect4Player? player = null)
		{
			Connect4PlayerSettings newPlayer = new();
			newPlayer.SetTypes(PlayerTypes);
			newPlayer.OnRemoveMe += (object? sender, EventArgs e) =>
			{
				RemovePlayer((Connect4PlayerSettings)sender!);
			};
			if (player != null)
			{
				newPlayer.SetPlayer(player, PlayerTypes.IndexOf(player.PlayerType));
			}
			PanPlayers.Controls.Add(newPlayer);
			newPlayer.FitWidth(PanPlayers);
			PanPlayers.Resize += newPlayer.FitWidth;
		}
		private void RemovePlayer(Connect4PlayerSettings player)
		{
			PanPlayers.Controls.Remove(player);
		}
		private void BtnAddPlayer_Click(object sender, EventArgs e)
		{
			AddPlayer();
		}

		private void BtnOk_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
