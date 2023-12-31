﻿namespace UI.Connect4.v1
{
	public partial class Connect4Board : UserControl
	{
		public event EventHandler<int>? MoveClick;
		public int TokenSize { get; private set; } = 100;
		private List<TokenSpace> Tokens { get; set; } = [];
		public List<Color> ColorMap { get; set; } =
        [
            Color.White,
		];

		public Connect4Board()
		{
			InitializeComponent();
		}
		public Connect4Board(int rows, int columns)
			: this()
		{
			Reset(rows, columns);
		}
		public void Reset(int rows, int columns)
		{
			if (this.InvokeRequired)
			{
				this.Invoke(Reset, rows, columns);
				return;
			}
			this.Controls.Clear();
			Tokens = [];
			for (int i = 0; i < rows; i++)
			{
				for (int j = 0; j < columns; j++)
				{
					TokenSpace newSpot = new(i, j, ColorMap[0])
					{
						Width = TokenSize,
						Height = TokenSize,
						Location = new(TokenSize * j, TokenSize * (rows - i - 1)),
					};
					Tokens.Add(newSpot);
					newSpot.Click += Token_MouseEvent;
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
			if (Tokens.Count == 0) { return; }
			int maxRowIndex = Tokens.Max(t => t.RowIndex);
			foreach (var token in Tokens)
			{
				token.Width = TokenSize;
				token.Height = TokenSize;
				Location = new(TokenSize * token.ColumnIndex, TokenSize * (maxRowIndex - token.RowIndex));
			}
		}
		public void HighlightPieces(List<(int,int)> positions, Color color)
		{
			foreach (var token in Tokens)
			{
				if (positions.Contains((token.RowIndex, token.ColumnIndex)))
				{
					token.SetBackGround(color);
				}
			}
		}
		private void Token_MouseEvent(object? sender, object e)
		{
			if (sender != null)
			{
				MoveClick?.Invoke(this, ((TokenSpace)sender).ColumnIndex);
			}
		}
	}
}
