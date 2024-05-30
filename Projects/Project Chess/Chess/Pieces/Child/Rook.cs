using System;
using Chess.Pieces.Implementation;
using Chess.Pieces.Interface;
using Chess.Enums;
using Chess.Boards.Interface;

namespace Chess.Pieces.Child;
public class Rook:Piece{
    
    public Rook(int id, PlayerType playerType, ICoordinate properties){
        this.pieceID = id;
        this.Properties = properties;
        this.isCaptured = false;
        this.piecesType = PiecesType.Rook;
        this.playerType = playerType;
    }
}
