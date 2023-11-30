using System.Drawing;

namespace Utilities
{
	public class GenericPlayer : IGenericPlayer<IGenericPlayer<Enum>.PlayerTypes>
	{
		public string Name { get; set; }
		public Color Color { get; set; }
		public int WinCount { get; set; }
		public IGenericPlayer<Enum>.PlayerTypes PlayerType => IGenericPlayer<Enum>.PlayerTypes.Generic;
		public CancellationToken CancellationToken { get; set; }
		public GenericPlayer(string name, Color color)
		{
			Name = name;
			Color = color;
		}
	}
}
