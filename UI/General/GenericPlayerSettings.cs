using Utilities;

namespace UI.General
{
	public partial class GenericPlayerSettings<TEnum> : UserControl where TEnum : Enum
	{
		static Random random = new();
		public Color PlayerColor => BtnColor.BackColor;
		public string PlayerName => TxtName.Text;
		public EventHandler? OnRemoveMe;
		public GenericPlayerSettings() : this(
			$"Player {random.Next(int.MaxValue)}",
			Color.FromArgb(255, random.Next(256), random.Next(256), random.Next(256))
		)
		{ }

		public GenericPlayerSettings(string name, Color color)
		{
			InitializeComponent();
			BtnColor.BackColor = color;
			TxtName.Text = name;
		}
		public void SetPlayer(IGenericPlayer<TEnum> player)
		{
			TxtName.Text = player.Name;
			BtnColor.BackColor = player.Color;
		}
		public virtual IGenericPlayer<IGenericPlayer<Enum>.PlayerTypes> GetPlayer()
		{
			return new GenericPlayer(PlayerName, PlayerColor); 
		}
		private void BtnColor_Click(object sender, EventArgs e)
		{
			if (DiaColor.ShowDialog() == DialogResult.OK)
			{
				BtnColor.BackColor = DiaColor.Color;
			}
		}
		private void BtnRemove_MouseUp(object sender, MouseEventArgs e)
		{
			OnRemoveMe?.Invoke(this, new());
		}
	}
}
