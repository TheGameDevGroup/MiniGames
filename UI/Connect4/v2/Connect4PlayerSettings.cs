using Connect4Backend;
using Utilities;

namespace UI.Connect4.v2
{
	public partial class Connect4PlayerSettings : General.GenericPlayerSettings
	{
		public Connect4PlayerSettings()
		{
			InitializeComponent();
		}
		public void SetTypes(IEnumerable<string> types)
		{
			ComboType.Items.AddRange(types.Select(t => t.ToString()).ToArray());
			if (types.Any())
			{
				ComboType.SelectedIndex = 0;
			}
		}
		public void SetPlayer(Connect4PlayerBase player)
		{
			ComboType.SelectedIndex = ComboType.Items.IndexOf(player.PlayerType);
			base.SetPlayer(player);
		}
		public Connect4PlayerBase GetPlayer(IDictionary<string, Func<GenericPlayerBase, Connect4PlayerBase>> playerTypeMap)
		{
			if (playerTypeMap.TryGetValue((string)ComboType.SelectedItem!, out var func))
			{
				return func(base.GetPlayer());
			}
			throw new ArgumentException("Bad player type.");
		}
		public void FitWidth(object? control, EventArgs? e = null)
		{
			Size = new(((Control)control!).Size.Width - Margin.Horizontal * 2, Size.Height);
		}
	}
}
