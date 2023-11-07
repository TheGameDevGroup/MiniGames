namespace UI
{
	public partial class Board : UserControl
	{
		public Board() : this(6,7)
		{
		}
		public Board(int rows, int columns)
		{
			int tokenSize = 100;
			Random random = new();
			InitializeComponent();
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					TokenSpace newSpot = new()
					{
						Width = tokenSize,
						Height = tokenSize,
						Location = new(tokenSize * j, tokenSize * i),
					};
					this.Controls.Add(newSpot);
					newSpot.SetToken(Color.FromArgb(random.Next(256), random.Next(256), random.Next(256)));
					//newSpot.SetToken(Color.AliceBlue);
				}
			}
		}
	}
}
