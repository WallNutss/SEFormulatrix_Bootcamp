using System;
using Chess.Pieces;
using Chess.Enums;
using Chess.Boards;
using Chess.GameControl;

namespace Chess.Pieces;
public class Pawn:Piece{
    

    private static readonly Dictionary<ColorType, Direction[]> directionMapForward = new Dictionary<ColorType, Direction[]>{
            { ColorType.White, new Direction[]
                {
                    Direction.moveDirection[DirectionMoveType.North],
                }
            },
            { ColorType.Black, new Direction[]
                {
                    Direction.moveDirection[DirectionMoveType.South],
                }
            }
    };

     private static readonly Dictionary<ColorType, Direction[]> directionMapForwardOvertake = new Dictionary<ColorType, Direction[]>{
            { ColorType.White, new Direction[]
                {
                    Direction.moveDirection[DirectionMoveType.NorthEast],
                    Direction.moveDirection[DirectionMoveType.NorthWest]
                }
            },
            { ColorType.Black, new Direction[]
                {
                    Direction.moveDirection[DirectionMoveType.SouthEast],
                    Direction.moveDirection[DirectionMoveType.SouthWest]
                }
            }
    };

    private Direction[] baseDirForward;
    private Direction[] baseDirDiagonal;
    public Pawn(int id, ColorType color,Coordinate position){
        pieceID = id;
        pos = position;
        isCaptured = false;
        piecesType = PiecesType.Pawn;
        pieceColor = color;
        baseDirForward = directionMapForward[pieceColor];
        baseDirDiagonal = directionMapForwardOvertake[pieceColor];
    }

    public override Piece Copy(){
        Pawn copy = new Pawn(pieceID, pieceColor,pos);
        return copy;
    }
    private IEnumerable<Coordinate> MoveForward(Coordinate from, GameController gc){
        foreach(Direction dir in baseDirForward){
            Coordinate to = from + dir;
            if(!gc.UtilitiesIsInsideBoard(to)){
                continue;
            }
            if(gc.UtilitiesIsSquareEmpty(to)){
                yield return to;
            }
        }
    }

    private IEnumerable<Coordinate> MoveDiagonalWhenOvertake(Coordinate from, GameController gc){
        foreach(Direction dir in baseDirDiagonal){
            Coordinate to = from + dir;
            if(!gc.UtilitiesIsInsideBoard(to)){
                continue;
            }
            if(gc.UtilitiesIsOccupiedByOpponent(to, this)){
                yield return to;
            }
        }
    }

    private IEnumerable<Coordinate> MovePossiblePositions(Coordinate from, GameController gc){
        return MoveForward(from, gc).Concat(MoveDiagonalWhenOvertake(from, gc));
    }

    public override IEnumerable<Move> GetMoves(Coordinate from, GameController gc){
        foreach(Coordinate to in MovePossiblePositions(from, gc)){
            yield return new NormalMove(from,to);
        }
    } 
}

