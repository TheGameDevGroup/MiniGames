using Utilities;

namespace MinesweeperBackend
{
	public interface IMineSweeperPlayer : IGenericPlayer
	{
		public (int, int) MakeMove(int?[,] boardState);
	}
}
