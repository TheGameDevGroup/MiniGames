using System.Drawing;

namespace Connect4Backend
{
	public class RandomBot : IConnect4Player
	{
		private readonly Random random = new();
		public string Name { get; set; }
		public Color Color { get; set; }
		public RandomBot(string name, Color color)
		{
			this.Name = name;
			this.Color = color;
		}
		public int MakeMove(in int[,] gameState, int playerToken)
		{
			int columnCount = gameState.GetLength(1);
			return random.Next(columnCount);
		}
	}
}
