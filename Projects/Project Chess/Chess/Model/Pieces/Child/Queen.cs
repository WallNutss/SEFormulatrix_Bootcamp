using System;
using Chess.Pieces;
using Chess.Enums;
using Chess.Boards;
using Chess.GameControl;

namespace Chess.Pieces;
public class Queen:Piece{

    private static readonly Direction[] baseDirs = new Direction[]{
        Direction.moveDirection[DirectionMoveType.North],
        Direction.moveDirection[DirectionMoveType.South],
        Direction.moveDirection[DirectionMoveType.East],
        Direction.moveDirection[DirectionMoveType.West],
        Direction.moveDirection[DirectionMoveType.NorthEast],
        Direction.moveDirection[DirectionMoveType.SouthEast],
        Direction.moveDirection[DirectionMoveType.NorthWest],
        Direction.moveDirection[DirectionMoveType.SouthWest]
    };
    public Queen(int id, ColorType color,Coordinate position){
        pieceID = id;
        pos = position;
        isCaptured = false;
        piecesType = PiecesType.Queen;
        pieceColor = color;
    }
    public override Piece Copy(){
        Queen copy = new Queen(pieceID, pieceColor,pos);
        return copy;
    }
    public override IEnumerable<Move> GetMoves(Coordinate from, GameController gc){
        return MovePositionInDirs(from, gc, baseDirs).Select(to => new NormalMove(from, to));
    }  
}
