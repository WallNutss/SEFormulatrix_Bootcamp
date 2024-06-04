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
        this.squares = new List<IPosition>();
        this.width = 8;
        this.height = 8;
        InitializeCoordinate();
    }
    public void InitializeCoordinate(){
        List<IPosition> squares  = new List<IPosition>();
        for (int x = 1; x <= this.width; x++){
            for (int y = 1; y <= this.height; y++){
                squares.Add(new Square(_x:x, _y:y));
            }
        }
        this.squares = squares;
    }

    public void PrintBoard(Dictionary <IPlayer, List<Piece>> playerDatas){

        
        List<Piece> allPieces = playerDatas.Values.SelectMany(pieces => pieces).ToList();
        // foreach(var piece in allPieces){
        //     Console.WriteLine($"Piece type : {piece.piecesType}, ID : {piece.pieceID} with color is {piece.pieceColor} pos (xy) = {piece.pos.x},{piece.pos.y}");
        // }
        BoardRenderer.PrintBoard(allPieces);

    }
}