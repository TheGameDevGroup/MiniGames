namespace UI.Minesweeper
{
	public partial class MinesweeperSettings : Form
	{
		public int Rows => boardSizeSettings.Rows;
		public int Columns => boardSizeSettings.Columns;
		public int BombCount => (int)NumBombs.Value;
		public bool CheckeredStyle => radioBtnColor.Checked;
		public (Color light, Color dark) CoveredColors => (colorPicker1.SelectedColor, colorPicker2.SelectedColor);
		public (Color light, Color dark) UncoveredColors => (colorPicker3.SelectedColor, colorPicker4.SelectedColor);
		public MinesweeperSettings() : this(
			20,
			20,
			10,
			true,
			(Color.Black, Color.Gray),
			(Color.LightGray, Color.White)
		) { }
		public MinesweeperSettings(
			int rows,
			int columns,
			int bombCount,
			bool checkered,
			(Color, Color) coveredColors,
			(Color, Color) uncoveredColors)
		{
			InitializeComponent();
			boardSizeSettings.Rows = rows;
			boardSizeSettings.Columns = columns;
			NumBombs.Value = bombCount;
			radioBtnColor.Checked = checkered;
			colorPicker1.Reset(coveredColors.Item1);
			colorPicker2.Reset(coveredColors.Item2);
			colorPicker3.Reset(uncoveredColors.Item1);
			colorPicker4.Reset(uncoveredColors.Item2);
		}

		private void numericUpDown_ValueChanged(object sender, EventArgs e)
		{
			NumBombs.Maximum = boardSizeSettings.Rows * boardSizeSettings.Columns - 1;
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		private void btnColorReset_Click(object sender, EventArgs e)
		{
			colorPicker1.Reset();
			colorPicker2.Reset();
			colorPicker3.Reset();
			colorPicker4.Reset();
		}

		private void radioBtnColor_CheckedChanged(object sender, EventArgs e)
		{
			splitColors.Enabled = btnColorReset.Enabled = radioBtnColor.Checked;
		}
	}
}
