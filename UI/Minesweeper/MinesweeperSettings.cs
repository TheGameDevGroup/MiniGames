namespace UI.Minesweeper
{
	public partial class MinesweeperSettings : Form
	{
		public int Rows => boardSizeSettings.Rows;
		public int Columns => boardSizeSettings.Columns;
		public int BombCount => (int)NumBombs.Value;
		public int TileSize => (int)NumTileSize.Value;
		public bool CheckeredStyle => radioBtnColor.Checked;
		public (Color light, Color dark) CoveredColors => (colorPicker1.SelectedColor, colorPicker2.SelectedColor);
		public (Color light, Color dark) UncoveredColors => (colorPicker3.SelectedColor, colorPicker4.SelectedColor);
		public Color FlagColor => colorPicker5.SelectedColor;
		public Color BombColor => colorPicker6.SelectedColor;
		public MinesweeperSettings() : this(
			20,
			20,
			10,
			20,
			Color.Red,
			Color.Black,
			true,
			(Color.Black, Color.Gray),
			(Color.LightGray, Color.White)
		)
		{ }
		public MinesweeperSettings(
			int rows,
			int columns,
			int bombCount,
			int tileSize,
			Color flagColor,
			Color bombColor,
			bool checkered,
			(Color, Color) coveredColors,
			(Color, Color) uncoveredColors)
		{
			InitializeComponent();
			boardSizeSettings.Rows = rows;
			boardSizeSettings.Columns = columns;
			boardSizeSettings.RowsMinimum = 4;
			boardSizeSettings.ColumnsMinimum = 4;
			NumBombs.Value = bombCount;
			NumTileSize.Value = tileSize;
			radioBtnColor.Checked = checkered;
			radioBtnImage.Checked = !checkered;
			colorPicker1.Reset(coveredColors.Item1);
			colorPicker2.Reset(coveredColors.Item2);
			colorPicker3.Reset(uncoveredColors.Item1);
			colorPicker4.Reset(uncoveredColors.Item2);
			colorPicker5.Reset(flagColor);
			colorPicker6.Reset(bombColor);
		}

		private void BoardSize_ValueChanged(object sender, EventArgs e)
		{
			NumBombs.Maximum = boardSizeSettings.Rows * boardSizeSettings.Columns - 9;
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
			colorPicker1.Reset(Color.GreenYellow);
			colorPicker2.Reset(Color.YellowGreen);
			colorPicker3.Reset(Color.AntiqueWhite);
			colorPicker4.Reset(Color.NavajoWhite);
			colorPicker5.Reset(Color.Red);
			colorPicker6.Reset(Color.Black);
		}

		private void radioBtnColor_CheckedChanged(object sender, EventArgs e)
		{
			splitColors.Enabled = btnColorReset.Enabled = radioBtnColor.Checked;
		}

		private void BtnEasy_Click(object sender, EventArgs e)
		{
			boardSizeSettings.Rows = 8;
			boardSizeSettings.Columns = 10;
			NumBombs.Value = 10;
		}

		private void BtnNormal_Click(object sender, EventArgs e)
		{
			boardSizeSettings.Rows = 14;
			boardSizeSettings.Columns = 18;
			NumBombs.Value = 40;
		}

		private void BtnHard_Click(object sender, EventArgs e)
		{
			boardSizeSettings.Rows = 20;
			boardSizeSettings.Columns = 24;
			NumBombs.Value = 99;
		}

		private void NumBombs_ValueChanged(object? sender, EventArgs e)
		{
			NumDensity.ValueChanged -= NumDensity_ValueChanged; // Prevent recursive call
			var temp = NumBombs.Value / (boardSizeSettings.Rows * boardSizeSettings.Columns - 9);
			if (temp < NumDensity.Minimum)
			{
				NumDensity.Value = NumDensity.Minimum;
			}
			else if (temp > NumDensity.Maximum)
			{
				NumDensity.Value = NumDensity.Maximum;
			}
			else
			{
				NumDensity.Value = temp;
			}
			NumDensity.ValueChanged += NumDensity_ValueChanged; // Re-enable event
		}

		private void NumDensity_ValueChanged(object? sender, EventArgs e)
		{
			NumBombs.ValueChanged -= NumBombs_ValueChanged; // Prevent recursive call
			var temp = (int)(NumDensity.Value * (boardSizeSettings.Rows * boardSizeSettings.Columns - 9));
			if (temp < NumBombs.Minimum)
			{
				NumBombs.Value = NumBombs.Minimum;
			}
			else if (temp > NumBombs.Maximum)
			{
				NumBombs.Value = NumBombs.Maximum;
			}
			else
			{
				NumBombs.Value = temp;
			}
			NumBombs.ValueChanged += NumBombs_ValueChanged; // Re-enable event
		}
	}
}
