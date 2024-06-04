using System;
using System.Collections.Generic;

// Interface for grid information
public interface IGrid
{
    int X { get; }
    int Y { get; }
}

// Interface for board dimension information
public interface IBoard
{
    int Width { get; }
    int Height { get; }
}

// Implementation of the IGrid interface
public class Grid : IGrid
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public Grid(int x, int y)
    {
        X = x;
        Y = y;
    }
}

// Implementation of the IBoard interface and inheriting from List<IGrid>
public class Board : List<IGrid>, IBoard
{
    public int Width { get; private set; }
    public int Height { get; private set; }
    
    public Board(int width, int height)
    {
        Width = width;
        Height = height;
        InitializeBoard();
    }

    private void InitializeBoard()
    {
        // Example initialization, creating a board with grid coordinates
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                this.Add(new Grid(x, y));
            }
        }
    }

    public void PrintBoard()
    {
        foreach (var grid in this)
        {
            Console.WriteLine($"Grid at ({grid.X}, {grid.Y})");
        }
    }
}

// Example usage
class Program
{
    static void Main(string[] args)
    {
        Board board = new Board(8, 7);
        board.PrintBoard();
    }
}
