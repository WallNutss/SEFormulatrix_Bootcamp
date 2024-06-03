using System;
using Chess.Pieces;
using Chess.Enums;
using Chess.Boards;

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
    private Direction[] baseDir;
    public Pawn(int id, ColorType pieceColor,IPosition pos){
        this.pieceID = id;
        this.pos = pos;
        this.isCaptured = false;
        this.piecesType = PiecesType.Pawn;
        this.pieceColor = pieceColor;
        this.baseDir = directionMap[pieceColor];
    }

    // public override Piece Copy(){
    //     Pawn copy = new Pawn(pieceID, pieceColor,pos);
    //     return copy;
    // }
}

