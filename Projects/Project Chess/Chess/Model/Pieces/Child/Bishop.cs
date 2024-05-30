using System;
using Chess.Pieces;
using Chess.Enums;
using Chess.Boards;

namespace Chess.Pieces;

public class Bishop:Piece{
    public Bishop(int id, PlayerType playerType, ColorType pieceColor, IPosition pos){
        this.pieceID = id;
        this.isCaptured = false;
        this.pos = pos;
        this.piecesType = PiecesType.Bishop;
        this.playerType = playerType;
        this.pieceColor= pieceColor;
    }
}
