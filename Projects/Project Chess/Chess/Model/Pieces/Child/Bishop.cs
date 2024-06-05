using System;
using Chess.Pieces;
using Chess.Enums;
using Chess.Boards;
using Chess.GameControl;

namespace Chess.Pieces;

public class Bishop:Piece{
    private static readonly Direction[] baseDirs = new Direction[]{
        Direction.moveDirection[DirectionMoveType.NorthEast],
        Direction.moveDirection[DirectionMoveType.SouthEast],
        Direction.moveDirection[DirectionMoveType.NorthWest],
        Direction.moveDirection[DirectionMoveType.SouthWest]
    };
    public Bishop(int id, ColorType color, Coordinate position){
        pieceID = id;
        isCaptured = false;
        pos = position;
        piecesType = PiecesType.Bishop;
        pieceColor= color;
    }

    public override Piece Copy(){
        Bishop copy = new Bishop(pieceID, pieceColor,pos);
        return copy;
    }
    // }
    // public override 
    public override IEnumerable<Move> GetMoves(Coordinate from, GameController gc){
        return MovePositionInDirs(from, gc, baseDirs).Select(to => new NormalMove(from, to));
    }  
}
