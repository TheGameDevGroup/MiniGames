﻿
using Connect4;
internal class Program
{   
    // driver code 
    private static void Main(string[] args)
    {
        GameState gameState = new GameState();
        gameState.Drop(3, 1);
        gameState.Drop(4, 2);
        gameState.Drop(4, 1);
        gameState.Drop(5, 2);
        gameState.Drop(3, 1);
        gameState.Drop(5, 2);
        gameState.Drop(5, 1);
        gameState.Drop(4, 2);
        gameState.Drop(6, 1);
        gameState.Drop(3, 2);
        gameState.Drop(6, 1);
        gameState.Drop(3, 2);
        gameState.Drop(3, 1);
        gameState.Drop(4, 2);
        gameState.Drop(2, 1);
        gameState.Drop(2, 2);
        gameState.Drop(1, 1);
        gameState.Drop(0, 2);
        gameState.Drop(3, 1);
        gameState.Drop(1, 2);
        gameState.Drop(2, 1);
        gameState.Drop(0, 2);
        gameState.Drop(4, 1);
        gameState.Drop(1, 2);
        gameState.Drop(6, 1);
        gameState.Drop(6, 2);
        gameState.Drop(5, 1);

        gameState = new GameState();
        gameState.Drop(0, 2);
        gameState.Drop(0, 2);
        gameState.Drop(0, 2);
        gameState.Drop(0, 2);

        gameState = new GameState();
        gameState.Drop(0, 1);
        gameState.Drop(1, 1);
        gameState.Drop(2, 1);
        gameState.Drop(3, 1);

        gameState.Drop(1, 1);
        gameState.Drop(2, 1);
        gameState.Drop(3, 1);
        gameState.Drop(2, 1);
        gameState.Drop(3, 1);
        gameState.Drop(3, 1);

        gameState = new GameState();
        gameState.Drop(0, 1);
        gameState.Drop(1, 1);
        gameState.Drop(2, 1);
        gameState.Drop(3, 1);

        gameState.Drop(0, 1);
        gameState.Drop(1, 1);
        gameState.Drop(2, 1);
        gameState.Drop(1, 1);
        gameState.Drop(0, 1);
        gameState.Drop(0, 1);
    }
}