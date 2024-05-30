using System;
using Chess.Pieces.Implementation;
using Chess.Pieces.Interface;
using Chess.Enums;
using Chess.Boards.Interface;

namespace Chess.Pieces.Child;
public class Knight:Piece{
    public Knight(int id, PlayerType playerType, ICoordinate properties){
        this.pieceID = id;
        this.Properties = properties;
        this.isCaptured = false;
        this.piecesType = PiecesType.Knight;
        this.playerType = playerType;
    }
}
