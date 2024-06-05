using System;
using Chess.Pieces;
using Chess.Enums;
using Chess.Boards;
using Chess.GameControl;

namespace Chess.Pieces;
public class Rook:Piece{

    private static readonly Direction[] baseDirs = new Direction[]{
        Direction.moveDirection[DirectionMoveType.North],
        Direction.moveDirection[DirectionMoveType.South],
        Direction.moveDirection[DirectionMoveType.East],
        Direction.moveDirection[DirectionMoveType.West]
    };

    public Rook(int id, ColorType color,Coordinate position){
        pieceID = id;
        isCaptured = false;
        pos = position;
        piecesType = PiecesType.Rook;
        pieceColor = color;
    }

    public override Piece Copy(){
        Rook copy = new Rook(pieceID, pieceColor,pos);
        return copy;
    }

    public override IEnumerable<Move> GetMoves(Coordinate from, GameController gc){
        return MovePositionInDirs(from, gc, baseDirs).Select(to => new NormalMove(from, to));
    }  
}
