using System;
using Chess.Pieces;
using Chess.Enums;
using Chess.Boards;

namespace Chess.Pieces;
public class Knight:Piece{

    private static readonly Direction[] baseDir = new Direction[]{
        3*Direction.moveDirection[DirectionMoveType.North] + Direction.moveDirection[DirectionMoveType.East],
        3*Direction.moveDirection[DirectionMoveType.North] + Direction.moveDirection[DirectionMoveType.West],
        3*Direction.moveDirection[DirectionMoveType.South] + Direction.moveDirection[DirectionMoveType.East],
        3*Direction.moveDirection[DirectionMoveType.South] + Direction.moveDirection[DirectionMoveType.West],
    };

    public Knight(int id, ColorType pieceColor, IPosition pos){
        this.pieceID = id;
        this.pos = pos;
        this.isCaptured = false;
        this.piecesType = PiecesType.Knight;
        this.pieceColor = pieceColor;
    }
}
