namespace UI.General
{
	public partial class ColorPicker : UserControl
	{
		static Random random = new();
		public Color SelectedColor
		{
			get { return BtnColor.BackColor; }
			set
			{
				BtnColor.BackColor = DiaColor.Color = value;
			}
		}
		public ColorPicker() : this(Color.FromArgb(255, random.Next(256), random.Next(256), random.Next(256)))
		{ }
		public ColorPicker(Color color)
		{
			InitializeComponent();
			SelectedColor = color;
		}
		private void BtnColor_Click(object sender, EventArgs e)
		{
			if (DiaColor.ShowDialog() == DialogResult.OK)
			{
				SelectedColor = DiaColor.Color;
			}
		}
	}
}
