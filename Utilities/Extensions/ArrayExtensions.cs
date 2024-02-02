namespace Utilities.Extensions
{
	public static class ArrayExtensions
	{
		public static IEnumerable<T> GetArea<T>(this T[,] board, int minRow, int minColumn, int maxRow, int maxColumn)
		{
			for (int i = minRow; i <= maxRow; i++)
			{
				for (int j = minColumn; j <= maxColumn; j++)
				{
					if (i >= 0 && j >= 0 && i < board.GetLength(0) && j < board.GetLength(1))
					{
						yield return board[i, j];
					}
				}
			}
		}
	}
}
