using System;
using Chess.Pieces;
using Chess.Enums;
using Chess.Boards;

namespace Chess.Pieces;
public class Pawn:Piece{
    public Pawn(int id, ColorType pieceColor,IPosition pos){
        this.pieceID = id;
        this.pos = pos;
        this.isCaptured = false;
        this.piecesType = PiecesType.Pawn;
        this.pieceColor = pieceColor;
    }
}
