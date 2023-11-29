using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Minesweeper
{
	public partial class MinesweeperSettings : Form
	{
		public MinesweeperSettings()
		{
			InitializeComponent();
		}

		private void numericUpDown1_ValueChanged(object sender, EventArgs e)
		{
			NumBombs.Maximum = Rows.Value * Columns.Value - 1;
		}
	}
}
