using System;
using Chess.Pieces.Implementation;
using Chess.Pieces.Interface;
using Chess.Enums;

namespace Chess.Pieces.Child;
public class Rook:Piece{
    
    public Rook(int id, ColorType color, PlayerType playerType){
        this.pieceID = id;
        this.color = color;
        this.isCaptured = false;
        this.piecesType = PiecesType.Rook;
        this.playerType = playerType;
    }
}
