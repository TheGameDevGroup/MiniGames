using Connect4Backend;
using Utilities;

namespace UI.Connect4.v2
{
	public partial class Connect4Settings : Form
	{
		Dictionary<string, Func<GenericPlayerBase, Connect4PlayerBase>> PlayerTypesMap = new()
		{
			{ "Human", (GenericPlayerBase p) => new HumanPlayer(p.Name, p.Color) },
			{ "Random (simple)", (GenericPlayerBase p) => new RandomBot(p.Name, p.Color, false) },
			{ "Random (weighted)", (GenericPlayerBase p) => new RandomBot(p.Name, p.Color, true) },
		};
		public Connect4Settings()
			: this(new List<Connect4PlayerBase>() { new HumanPlayer() }, 6, 7, 4)
		{ }
		public Connect4Settings(IEnumerable<Connect4PlayerBase> players, int rows, int columns, int winLength)
		{
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
        public void AddPlayer(Connect4PlayerBase? player = null)
        {
            Connect4PlayerSettings newPlayer = new();
            newPlayer.SetTypes(PlayerTypesMap.Keys);
            newPlayer.OnRemoveMe += (object? sender, EventArgs e) =>
            {
                RemovePlayer((Connect4PlayerSettings)sender!);
            };
            if (player != null)
            {
                newPlayer.SetPlayer(player);
            }
            PanPlayers.Controls.Add(newPlayer);
            newPlayer.FitWidth(PanPlayers);
            PanPlayers.Resize += newPlayer.FitWidth;
        }
        public List<Connect4PlayerBase> GetPlayers()
		{
			List<Connect4PlayerBase> toReturn = new();
			foreach (var ps in PanPlayers.Controls.Cast<Connect4PlayerSettings>())
			{
				toReturn.Add(ps.GetPlayer(PlayerTypesMap));
            }
			return toReturn;
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
