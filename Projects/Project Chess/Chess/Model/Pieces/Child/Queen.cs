using System;
using Chess.Pieces;
using Chess.Enums;
using Chess.Boards;

namespace Chess.Pieces;
public class Queen:Piece{

    private static readonly Direction[] baseDir = new Direction[]{
        Direction.moveDirection[DirectionMoveType.North],
        Direction.moveDirection[DirectionMoveType.South],
        Direction.moveDirection[DirectionMoveType.East],
        Direction.moveDirection[DirectionMoveType.West],
        Direction.moveDirection[DirectionMoveType.NorthEast],
        Direction.moveDirection[DirectionMoveType.SouthEast],
        Direction.moveDirection[DirectionMoveType.NorthWest],
        Direction.moveDirection[DirectionMoveType.SouthWest]
    };
    public Queen(int id, ColorType pieceColor,IPosition pos){
        this.pieceID = id;
        this.pos = pos;
        this.isCaptured = false;
        this.piecesType = PiecesType.Queen;
        this.pieceColor = pieceColor;
    }
}
