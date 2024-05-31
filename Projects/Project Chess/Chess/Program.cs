using System;
using System.Threading;

using Chess.Boards;
using Chess.Enums;
using Chess.PlayerDatas;
using Chess.Prisons;
using Chess.Players;
using Chess.GameController;


class Program{
    static void Main(){
        // Constructing the player default data positions, starting with the coordinates
        GameController controller = new();
        
        controller.PreGameStart();
        controller.StartGame();

        //m Console.WriteLine(board);
        

        // foreach(var data in playerDatas.pieces){
        //     Console.WriteLine($"Piece {data.pieceColor} type of {data.piecesType} with ID: {data.pieceID} it is {data.isCaptured}(captured) where it location is ({data.pos.x}, {data.pos.y})");
        // }
        
        // Console.WriteLine("===================================");
        // // Make an example of changing pieces locaation\
        // MovePieces(ref playerDatas, PlayerType.PlayerA,16,[4,5]);
        // board.PrintBoard(playerDatas);

        // Console.WriteLine("===================================");
        // // Make an example of changing pieces locaation\
        // MovePieces(ref playerDatas, PlayerType.PlayerB,3,[3,5]);
        // board.PrintBoard(playerDatas);
        
        // Console.WriteLine(playerDatas.IsEmpty(new Coordinate(6,5)));
        // Console.WriteLine(playerDatas.IsOccupiedByOpponent(new Coordinate(3,5), playerB));
        // Console.WriteLine(playerDatas.GetPieceAt(new Coordinate(2,7)).pieceID);
        // foreach(var data in playerDatas.pieces){
        //      Console.WriteLine($"Piece type of {data.piecesType} with ID: {data.pieceID} it is {data.isCaptured}(captured) where it location is ({data.pos.x}, {data.pos.y})");
        // }

    }
    // public static void MovePieces(ref PlayerData playerDatas, PlayerType playerType, int ID, int[] location){
    //    int index =  playerDatas.pieces.FindIndex(p => p.pieceID == ID && p.playerType == playerType);
    //    (playerDatas.pieces[index].pos.x,playerDatas.pieces[index].pos.y) = (location[0],location[1]); // Trial Modify
    // }
}
