using Connect4Backend;

namespace UI.Connect4.v2
{
	public partial class Connect4PlayerSettings : General.GenericPlayerSettings<IConnect4Player.PlayerTypes>
	{
		public int PlayerType => ComboType.SelectedIndex;
		public Connect4PlayerSettings()
		{
			InitializeComponent();
		}
		public void SetTypes(IEnumerable<IConnect4Player.PlayerTypes> types)
		{
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
		public void FitWidth(object? control, EventArgs? e = null)
		{
			Size = new(((Control)control!).Size.Width - Margin.Horizontal * 2, Size.Height);
		}
	}
}
