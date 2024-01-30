using System.Drawing;

namespace Utilities
{
	public interface IGenericPlayer<TEnum> where TEnum : Enum
	{
		public string Name { get; set; }
		public Color Color { get; set; }
		public int WinCount { get; set; }
		public TEnum PlayerType { get; }
		/// <summary>
		/// Use to indicate that the player should stop all execution
		/// </summary>
		public CancellationToken CancellationToken { get; set; }
		public enum PlayerTypes
		{
			Generic
		}
	}
}
