using System;
using System.Threading;

using Chess.Boards;
using Chess.Enums;
using Chess.PlayerData;
using Chess.Prisons;
using Chess.Players;


class Program{
    static void Main(){
        // Constructing the player default data positions, starting with the coordinates
        PlayerData playerDatas = new();

        // Constructing the board suchs as it's length and it's own properties
        Board board = new Board(ref playerDatas);

        // Construct the prison house, default at the start game it's empty
        Prison prison = new();
        
        // Constructing template player for the user to use
        Player playerA = new(1,"Player-A", PlayerType.PlayerA);
        Player playerB = new(2,"Player-B", PlayerType.PlayerB);

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
       (playerDatas.pieces[index].Properties.x,playerDatas.pieces[index].Properties.y) = (location[0],location[1]); // Trial Modify
    }
}
