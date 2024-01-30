using System.Drawing;

namespace Utilities
{
	public abstract class GenericPlayerBase
	{
		public string Name { get; set; } = "";
		public Color Color { get; set; }
		public int WinCount { get; set; }
		public string PlayerType { init; get; } = "";
		/// <summary>
		/// Use to indicate that the player should stop all execution
		/// </summary>
		public CancellationToken CancellationToken { get; set; }
	}
}
