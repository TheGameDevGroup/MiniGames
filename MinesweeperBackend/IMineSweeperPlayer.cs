using Utilities;

namespace MinesweeperBackend
{
	public interface IMineSweeperPlayer : IGenericPlayer
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="boardState">Null if not uncovered, otherwise the number of surrounding bombs.</param>
		/// <returns></returns>
		public (int, int) MakeMove(byte?[,] boardState);
	}
}
