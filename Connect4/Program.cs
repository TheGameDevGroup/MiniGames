
using Connect4.Backend;
internal class Program
{   
    // driver code 
    private static void Main(string[] args)
    {
        GameState gameState = new GameState();
        gameState.Drop(0, 1);
        gameState.Drop(0, 1);
        gameState.Drop(0, 1);
        gameState.Drop(0, 1);
        gameState.Drop(1, 1);
        gameState.Drop(2, 1);
        gameState.Drop(3, 1);
        gameState.Drop(2, 1);
        gameState.Drop(3, 1);
        gameState.Drop(3, 1);
    }
}