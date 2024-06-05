using System;
using Chess.Pieces;
using Chess.Enums;
using Chess.Boards;
using Chess.GameControl;

namespace Chess.Pieces;
public class Pawn:Piece{
    

    private static readonly Dictionary<ColorType, Direction[]> directionMap = new Dictionary<ColorType, Direction[]>{
            { ColorType.White, new Direction[]
                {
                    Direction.moveDirection[DirectionMoveType.North],
                    Direction.moveDirection[DirectionMoveType.NorthEast],
                    Direction.moveDirection[DirectionMoveType.NorthWest]
                }
            },
            { ColorType.Black, new Direction[]
                {
                    Direction.moveDirection[DirectionMoveType.South],
                    Direction.moveDirection[DirectionMoveType.SouthEast],
                    Direction.moveDirection[DirectionMoveType.SouthWest]
                }
            }
    };
    private Direction[] baseDirs;
    public Pawn(int id, ColorType color,Coordinate position){
        pieceID = id;
        pos = position;
        isCaptured = false;
        piecesType = PiecesType.Pawn;
        pieceColor = color;
        baseDirs = directionMap[pieceColor];
    }

    public override Piece Copy(){
        Pawn copy = new Pawn(pieceID, pieceColor,pos);
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

