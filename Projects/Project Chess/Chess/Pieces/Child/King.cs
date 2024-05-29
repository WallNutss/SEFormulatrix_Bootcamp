using System;
using Chess.Pieces.Implementation;
using Chess.Pieces.Interface;
using Chess.Enums;

namespace Chess.Pieces.Child;
public class King:Piece{
    public King(int id, ColorType color, PlayerType playerType){
        this.pieceID = id;
        this.color = color;
        this.isCaptured = false;
        this.piecesType = PiecesType.King;
        this.playerType = playerType;
    }
}
