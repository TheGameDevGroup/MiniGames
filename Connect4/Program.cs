
using Connect4.Backend;
internal class Program
{   
    // driver code 
    private static void Main(string[] args)
    {
        GameState gameState = new GameState();
        gameState.drop(1, 0);
        gameState.drop(1, 0);
        gameState.drop(1, 0);
    }
}