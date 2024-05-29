using System;
using System.Threading;

using Chess.Boards.Implementation;
using Chess.Boards.Interface;
using Chess.Enums;
using Chess.PlayerData;
using Chess.Players.Implementation;


class Program{
    static void Main(){
        // Constructing the board, starting with the coordinates
        PlayerData playerDatas = new();

        Board board = new Board(8, 8);

        // Constructing template player for the user to use
        Player playerA = new(1,"Player-A", PlayerType.PlayerA);
        Player playerB = new(2,"Player-B", PlayerType.PlayerB);

        // The data?

        // Print Grid Example
        foreach(var square in board.squares){
            Console.WriteLine($"Squares at ({square.x}, {square.y}) with color: {square.color}");
        }

        board.PrintBoard(playerDatas);
        foreach(var data in playerDatas.pieces){
            Console.WriteLine($"Piece of {data.playerType}, ID: {data.pieceID}, piece type is: {data.piecesType} with color of {data.color} where it default state is ({data.isCaptured})capture");
        }
        
    }
}
