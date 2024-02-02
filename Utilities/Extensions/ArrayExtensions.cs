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
		/// <summary>
		/// Simplifies the checks for the bounds of the array.
		/// Does the action with the only indices that are within the bounds of the array.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="board"></param>
		/// <param name="minRow"></param>
		/// <param name="minColumn"></param>
		/// <param name="maxRow"></param>
		/// <param name="maxColumn"></param>
		/// <param name="action"></param>
		public static void DoAtEach<T>(this T[,] board, int minRow, int minColumn, int maxRow, int maxColumn, Action<int, int> action)
		{
			for (int i = minRow; i <= maxRow; i++)
			{
				for (int j = minColumn; j <= maxColumn; j++)
				{
					if (i >= 0 && j >= 0 && i < board.GetLength(0) && j < board.GetLength(1))
					{
						action(i, j);
					}
				}
			}
		}
	}
}
