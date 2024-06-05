using System;
using Chess.Enums;

namespace Chess.Boards;

public class Direction{
    // Readony enums
    public static readonly Dictionary<DirectionMoveType, Direction> moveDirection = new()
    {
        { DirectionMoveType.North, new Direction(0, -1) },
        { DirectionMoveType.South, new Direction(0, 1) },
        { DirectionMoveType.East, new Direction(1, 0) },
        { DirectionMoveType.West, new Direction(-1, 0) },
        { DirectionMoveType.NorthEast, new Direction(0, -1) + new Direction(1, 0) },
        { DirectionMoveType.NorthWest, new Direction(0, -1) + new Direction(-1, 0) },
        { DirectionMoveType.SouthEast, new Direction(0, 1) + new Direction(1, 0) },
        { DirectionMoveType.SouthWest, new Direction(0, 1) + new Direction(-1, 0) }
    };
    // Add compound directions after the dictionary is initialized
    public int x { get;}
    public int y { get;}

    public Direction(int x, int y){
        this.x = x;
        this.y = y;
    }
    // Implementing Class Operator Override
    public static Direction operator +(Direction dir1, Direction dir2){
        return new Direction(dir1.x + dir2.x,  dir1.y + dir2.y);
    }
    public static Direction operator *(int scalar, Direction dir2){
        return new Direction(scalar*dir2.x,  scalar*dir2.y);
    }

}