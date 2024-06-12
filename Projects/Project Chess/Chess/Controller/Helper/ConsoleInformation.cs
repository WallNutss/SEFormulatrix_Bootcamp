using System;
using Chess.Boards;

namespace Chess.GameControl.Helper;


public static class ConsoleInformation{
    public static string GetUserInput(string message){
        Console.WriteLine(message);
        return Console.ReadLine() ?? string.Empty;
    }
    public static void ConsoleOutput(string message){
        Console.WriteLine(message);
    }

    // Extend the functionality of string
    // There are two things I want to extend
    // First is to have them convert from string to Coordinate types
    // Second is to have them convert to int for Piece ID
    public static Coordinate ConvertStringToCoordinate(this string input){
        int[] xy = input.Split(',').Select(int.Parse).ToArray();
        return new Coordinate(xy[0],xy[1]);
    }
    public static int ConvertStringToInt(this string input){
        return Convert.ToInt32(input);
    }
}