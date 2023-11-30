using System.Drawing;

namespace Utilities
{
	public class GenericPlayer : IGenericPlayer
	{
		public string Name { get; set; }
		public Color Color { get; set; }
		public int WinCount { get; set; }
        public CancellationToken CancellationToken { get; set; }
        public GenericPlayer(string name, Color color)
		{
			Name = name;
			Color = color;
		}
	}
}
