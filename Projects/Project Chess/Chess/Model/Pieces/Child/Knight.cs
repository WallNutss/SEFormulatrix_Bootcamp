using System;
using Chess.Pieces;
using Chess.Enums;
using Chess.Boards;
using Chess.GameControl;

namespace Chess.Pieces;
public class Knight:Piece{

    private static readonly Direction[] baseDirs = new Direction[]{
        2*Direction.moveDirection[DirectionMoveType.North] + Direction.moveDirection[DirectionMoveType.East],
        2*Direction.moveDirection[DirectionMoveType.North] + Direction.moveDirection[DirectionMoveType.West],
        2*Direction.moveDirection[DirectionMoveType.South] + Direction.moveDirection[DirectionMoveType.East],
        2*Direction.moveDirection[DirectionMoveType.South] + Direction.moveDirection[DirectionMoveType.West],
        2*Direction.moveDirection[DirectionMoveType.East]  + Direction.moveDirection[DirectionMoveType.North],
        2*Direction.moveDirection[DirectionMoveType.East]  + Direction.moveDirection[DirectionMoveType.South],
        2*Direction.moveDirection[DirectionMoveType.West]  + Direction.moveDirection[DirectionMoveType.North],
        2*Direction.moveDirection[DirectionMoveType.West]  + Direction.moveDirection[DirectionMoveType.South],
    };

    public Knight(int id, ColorType color, Coordinate position){
        pieceID = id;
        pos = position;
        isCaptured = false;
        piecesType = PiecesType.Knight;
        pieceColor = color;
    }
    public override Piece Copy(){
        Knight copy = new Knight(pieceID, pieceColor,pos);
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
