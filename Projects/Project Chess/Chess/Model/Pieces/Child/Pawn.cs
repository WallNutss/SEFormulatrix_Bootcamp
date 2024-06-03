using System;
using Chess.Pieces;
using Chess.Enums;
using Chess.Boards;

namespace Chess.Pieces;
public class Pawn:Piece{
    
    private Direction baseDir {get;set;}
    public Pawn(int id, ColorType pieceColor,IPosition pos){
        this.pieceID = id;
        this.pos = pos;
        this.isCaptured = false;
        this.piecesType = PiecesType.Pawn;
        this.pieceColor = pieceColor;
        this.baseDir = pieceColor == ColorType.White ? Direction.moveDirection[DirectionMoveType.North] : Direction.moveDirection[DirectionMoveType.South];
    }
    // public override Piece Copy(){
    //     Pawn copy = new Pawn(pieceID, pieceColor,pos);
    //     return copy;
    // }
}

