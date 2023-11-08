namespace UI
{
	public partial class Board : UserControl
	{
		public event EventHandler<int>? MoveClick;
		public int TokenSize { get; private set; } = 100;
		private List<TokenSpace> Tokens { get; set; } = new();
		public Dictionary<int, Color> ColorMap { get; set; } = new()
		{
			{ 0, Color.White },
		};

		public Board()
			: this(6, 7)
		{
		}
		public Board(int rows, int columns)
		{
			InitializeComponent();
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					TokenSpace newSpot = new(i, j, ColorMap[0])
					{
						Width = TokenSize,
						Height = TokenSize,
						Location = new(TokenSize * j, TokenSize * i),
					};
					Tokens.Add(newSpot);
					newSpot.MouseUp += Token_MouseUp;
				}
			}
			this.Controls.AddRange(Tokens.ToArray());
		}
		public void Update(int[,] state)
		{
			foreach (var token in Tokens)
			{
				token.SetToken(ColorMap[state[token.RowIndex, token.ColumnIndex]]);
			}
		}
		public void SetTokenSize(int size)
		{
			TokenSize = size;
			foreach (var token in Tokens)
			{
				token.Width = TokenSize;
				token.Height = TokenSize;
				Location = new(TokenSize * token.ColumnIndex, TokenSize * token.RowIndex);
			}
		}
		private void Token_MouseUp(object? sender, MouseEventArgs e)
		{
			if (sender != null)
			{
				MoveClick?.Invoke(this, ((TokenSpace)sender).ColumnIndex);
			}
		}
	}
}
