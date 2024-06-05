using System;
using Chess.Enums;

/// <summary>
/// Defines the types of players in the game.
/// </summary>
namespace Chess.Boards;
public interface IPosition
{
    // Coordinates of the square
    int x { get; set; }
    int y { get; set; }
}
