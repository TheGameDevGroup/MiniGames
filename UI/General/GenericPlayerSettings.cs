using Utilities;

namespace UI.General
{
    public partial class GenericPlayerSettings : UserControl
    {
        static Random random = new();
        public Color PlayerColor => colorPicker.SelectedColor;
        public string PlayerName => TxtName.Text;
        public event EventHandler? OnRemoveMe;
        public GenericPlayerSettings() : this(
            $"Player {random.Next(int.MaxValue)}",
            Color.FromArgb(255, random.Next(256), random.Next(256), random.Next(256))
        )
        { }

        public GenericPlayerSettings(string name, Color color)
        {
            InitializeComponent();
            colorPicker.SelectedColor = color;
            TxtName.Text = name;
        }
        protected void SetPlayer(GenericPlayerBase player)
        {
            TxtName.Text = player.Name;
            colorPicker.SelectedColor = player.Color;
        }
        protected GenericPlayerBase GetPlayer()
        {
            return new GenericPlayer(PlayerName, PlayerColor);
        }
        private void BtnRemove_MouseUp(object sender, MouseEventArgs e)
        {
            OnRemoveMe?.Invoke(this, new());
        }
    }
}
