using System;
using Chess.Enums;

namespace Chess.Boards.Interface;
public interface ISquare
{
    // Coordinates of the square
    int x { get; set; }
    int y { get; set; }
    ColorType color { get; set; }
    void IsValid();
    void GetAdjacent();

}
