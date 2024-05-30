using System;
using System.Threading;

using Chess.Boards.Implementation;
using Chess.Boards.Interface;
using Chess.Enums;
using Chess.PlayerData;
using Chess.Prisons;
using Chess.Players.Implementation;


class Program{
    static void Main(){
        // Constructing the player default data positions, starting with the coordinates
        PlayerData playerDatas = new();

        // Constructing the board suchs as it's length and it's own properties
        Board board = new Board(8, 8,ref playerDatas);

        // Construct the prison house, default at the start game it's empty
        Prison prison = new();
        
        // Constructing template player for the user to use
        Player playerA = new(1,"Player-A", PlayerType.PlayerA);
        Player playerB = new(2,"Player-B", PlayerType.PlayerB);

        // Print Grid Example
        foreach(var square in board.squares){
            Console.WriteLine($"Squares at ({square.x}, {square.y}) with color: {square.color}");
        }

        foreach(var data in playerDatas.pieces){
            Console.WriteLine($"Piece of {data.playerType}, ID: {data.pieceID}, piece type is: {data.piecesType} with color of {data.color} where it default state is ({data.isCaptured})capture, position: ({data.x},{data.y})");
        }
        board.PrintBoard(playerDatas);
        
        Console.WriteLine("===================================");
        // Make an example of changing pieces locaation\
        MovePieces(ref playerDatas, PlayerType.PlayerA,16,[4,5]);
        board.PrintBoard(playerDatas);

        Console.WriteLine("===================================");
        // Make an example of changing pieces locaation\
        MovePieces(ref playerDatas, PlayerType.PlayerB,3,[3,5]);
        board.PrintBoard(playerDatas);
        
    }
    public static void MovePieces(ref PlayerData playerDatas, PlayerType playerType, int ID, int[] location){
       int index =  playerDatas.pieces.FindIndex(p => p.pieceID == ID && p.playerType == playerType);
       (playerDatas.pieces[index].x,playerDatas.pieces[index].y) = (location[0],location[1]); // Trial Modify
    }
}
