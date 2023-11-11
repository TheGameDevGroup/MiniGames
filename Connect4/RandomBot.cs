using System.Drawing;

namespace Connect4
{
	public class RandomBot : IConnect4Player
	{
		private Random random = new Random();
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
