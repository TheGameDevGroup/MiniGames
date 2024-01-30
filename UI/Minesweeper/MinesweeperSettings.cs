namespace UI.Minesweeper
{
    public partial class MinesweeperSettings : Form
	{
		public MinesweeperSettings()
		{
			InitializeComponent();
		}

		private void numericUpDown_ValueChanged(object sender, EventArgs e)
		{
			NumBombs.Maximum = boardSizeSettings.Rows * boardSizeSettings.Columns - 1;
		}
	}
}
