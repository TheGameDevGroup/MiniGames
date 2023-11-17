using System.Drawing;

namespace Connect4Backend
{
    internal class TestPlayer : IConnect4Player
    {
        public string Name { get; set; } = "test";
        public Color Color { get; set; } = Color.Cyan;

        public int MakeMove(in int[,] gameState, int playerToken)
        {
            throw new NotImplementedException();
        }
    }
}
