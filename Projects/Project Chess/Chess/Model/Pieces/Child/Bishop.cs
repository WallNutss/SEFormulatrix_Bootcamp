using System;
using Chess.Pieces;
using Chess.Enums;
using Chess.Boards;

namespace Chess.Pieces;

public class Bishop:Piece{
    private static readonly Direction[] baseDir = new Direction[]{
        Direction.moveDirection[DirectionMoveType.NorthEast],
        Direction.moveDirection[DirectionMoveType.SouthEast],
        Direction.moveDirection[DirectionMoveType.NorthWest],
        Direction.moveDirection[DirectionMoveType.SouthWest]
    };
    public Bishop(int id, ColorType pieceColor, IPosition pos){
        this.pieceID = id;
        this.isCaptured = false;
        this.pos = pos;
        this.piecesType = PiecesType.Bishop;
        this.pieceColor= pieceColor;
    }
}
