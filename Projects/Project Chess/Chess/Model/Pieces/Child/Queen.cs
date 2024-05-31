using System;
using Chess.Pieces;
using Chess.Enums;
using Chess.Boards;

namespace Chess.Pieces;
public class Queen:Piece{
    public Queen(int id, ColorType pieceColor,IPosition pos){
        this.pieceID = id;
        this.pos = pos;
        this.isCaptured = false;
        this.piecesType = PiecesType.Queen;
        this.pieceColor = pieceColor;
    }
}
