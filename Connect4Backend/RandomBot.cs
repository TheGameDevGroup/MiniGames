using System.Data;
using System.Drawing;

namespace Connect4Backend
{
	public class RandomBot : IConnect4Player
	{
		private readonly Random random = new();
		private readonly bool IsWeighted;
		private int[,]? PreviousState;
		public string Name { get; set; }
		public Color Color { get; set; }
		public RandomBot(string name, Color color, bool isWeighted)
		{
			this.Name = name;
			this.Color = color;
			this.IsWeighted = isWeighted;
		}
		public int MakeMove(in int[,] gameState, int playerToken)
		{
			if (IsWeighted)
			{
				return WeightedReandomMove(gameState, playerToken);
			}
			else
			{
				return RandomMove(gameState, playerToken);
			}
		}
		private int WeightedReandomMove(in int[,] gameState, int playerToken)
		{
			var columns = GetMoves(gameState, playerToken);
			PreviousState = gameState;
			return columns.Count > 0 ? columns.ElementAt(random.Next(columns.Count)) : RandomMove(gameState, playerToken);

		}

		private HashSet<int> GetMoves(in int[,] gameState, int playerToken)
		{
			HashSet<int> movesMade = new();
			if (PreviousState == null)
			{
				PreviousState = new int[gameState.GetLength(0), gameState.GetLength(1)];
			}
			for (int column = 0; column < gameState.GetLength(1); column++)
			{
				for (int row = gameState.GetLength(0) - 1; row >= 0 ; row--)
				{
					if (gameState[row, column] == 0) { continue; }
					if (PreviousState[row, column] == 0 && gameState[row, column] != playerToken)
					{
						// An opponent has made a move in this column
						movesMade.Add(column);
						// Add the adjacent columns
						if (column > 0) { movesMade.Add(column - 1); }
						if (column < gameState.GetLength(1) - 1) { movesMade.Add(column + 1); }
						break;
					}
				}
			}
			return movesMade;
		}

		private int RandomMove(in int[,] gameState, int playerToken)
		{
			int columnCount = gameState.GetLength(1);
			return random.Next(columnCount);
		}
	}
}
