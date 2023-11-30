using System.Drawing;

namespace Utilities
{
	public interface IGenericPlayer
	{
		public string Name { get; set; }
		public Color Color { get; set; }
		public int WinCount { get; set; }
		/// <summary>
		/// Use to indicate that the player should stop all execution
		/// </summary>
		public CancellationToken CancellationToken { get; set; }
	}
}
