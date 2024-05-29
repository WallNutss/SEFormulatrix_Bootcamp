using System;
using System.Threading;

using Chess.Boards.Implementation;
using Chess.Boards.Interface;
using Chess.Enums;


class Program{
    static void Main(){
        Board board = new Board(8, 8);

        // Print Grid Example
        foreach(var square in board.squares){
            Console.WriteLine($"Squares at ({square.x}, {square.y}) with color: {square.color}");
        }

        board.PrintBoard();
        
    }
}
