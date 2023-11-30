using Connect4Backend;

namespace UI.Connect4.v2
{
	public partial class Connect4PlayerSettings : General.GenericPlayerSettings<IConnect4Player.PlayerTypes>
	{
		List<IConnect4Player.PlayerTypes> Types = new();
		public IConnect4Player.PlayerTypes PlayerType => Types.ElementAtOrDefault(ComboType.SelectedIndex);
		public Connect4PlayerSettings()
		{
			InitializeComponent();
		}
		public void SetTypes(IEnumerable<IConnect4Player.PlayerTypes> types)
		{
			Types = types;
			ComboType.Items.AddRange(types.Select(t => t.ToString()).ToArray());
			if (types.Any())
			{
				ComboType.SelectedIndex = 0;
			}
		}
		public void SetPlayer(IConnect4Player player, int type)
		{
			ComboType.SelectedIndex = type;
			base.SetPlayer(player);
		}
	}
}
