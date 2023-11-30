using Connect4Backend;

namespace UI.Connect4.v2
{
	public partial class Connect4PlayerSettings : General.GenericPlayerSettings
	{
		public string PlayerType => (string)(ComboType.SelectedItem ?? "");
		public Connect4PlayerSettings()
		{
			InitializeComponent();
		}
		public void SetTypes(IEnumerable<string> types)
		{
			ComboType.Items.AddRange(types.ToArray());
			if (types.Any())
			{
				ComboType.SelectedIndex = 0;
			}
		}
	}
}
