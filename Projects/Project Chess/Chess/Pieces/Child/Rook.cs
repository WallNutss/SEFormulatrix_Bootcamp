using System;
using Chess.Pieces;
using Chess.Enums;
using Chess.Boards;

namespace Chess.Pieces;
public class Rook:Piece{
    
    public Rook(int id, PlayerType playerType, ICoordinate properties){
        this.pieceID = id;
        this.Properties = properties;
        this.isCaptured = false;
        this.piecesType = PiecesType.Rook;
        this.playerType = playerType;
    }
}
