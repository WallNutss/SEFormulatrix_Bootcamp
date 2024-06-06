using System;
using Chess.Pieces;
using Chess.Enums;
using Chess.Boards;
using Chess.GameControl;

namespace Chess.Pieces;
public class King:Piece{

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

    public King(int id,ColorType color, Coordinate position){
        pieceID = id;
        isCaptured = false;
        pos = position;
        piecesType = PiecesType.King;
        pieceColor = color;
    }

    public override Piece Copy(){
        King copy = new King(pieceID, pieceColor,pos);
        return copy;
    }

    private IEnumerable<Coordinate> MovePossiblePositions(Coordinate from, GameController gc){
        foreach(Direction dir in baseDirs){
            Coordinate to = from + dir;
            if(!gc.UtilitiesIsInsideBoard(to)){
                continue;
            }
            if(gc.UtilitiesIsSquareEmpty(to) || gc.UtilitiesIsOccupiedByOpponent(to, this)){
                yield return to;
            }
        }
    }

    public override IEnumerable<Move> GetMoves(Coordinate from, GameController gc){
        foreach(Coordinate to in MovePossiblePositions(from, gc)){
            yield return new NormalMove(from,to);
        }
    } 
}
