namespace Chess.Boards;

using System;
using System.Text;

using Chess.Enums;
using Chess.Pieces;
using Chess.PlayerDatas;
using Chess.Players;
using Chess.Render;

/// <summary>
/// An Implementation of IBoard
/// </summary>
public class Board: IBoard{
    public int width { get; private set; }
    public int height { get; private set; }
    public List<IPosition> squares { get; set;}
    
    public Board(){
        squares = new List<IPosition>();
        width = 8;
        height = 8;
        InitializeCoordinate();
    }
    public void InitializeCoordinate(){
        for (int x = 1; x <= width; x++){
            for (int y = 1; y <= height; y++){
                squares.Add(new Square(_x:x, _y:y));
            }
        }
    }

    public void PrintBoard(Dictionary <IPlayer, List<Piece>> playerDatas){

        
        List<Piece> allPieces = playerDatas.Values.SelectMany(pieces => pieces).ToList();
        // foreach(var piece in allPieces){
        //     Console.WriteLine($"Piece type : {piece.piecesType}, ID : {piece.pieceID} with color is {piece.pieceColor} pos (xy) = {piece.pos.x},{piece.pos.y}");
        // }
        BoardRenderer.PrintBoard(allPieces);

    }
}