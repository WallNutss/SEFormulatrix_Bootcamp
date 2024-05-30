using System;
using Chess.Pieces;
using Chess.Enums;
using Chess.Boards;

namespace Chess.Pieces;
public class King:Piece{
    public King(int id, PlayerType playerType, ColorType pieceColor, IPosition pos){
        this.pieceID = id;
        this.isCaptured = false;
        this.pos = pos;
        this.piecesType = PiecesType.King;
        this.playerType = playerType;
        this.pieceColor = pieceColor;
    }
}
