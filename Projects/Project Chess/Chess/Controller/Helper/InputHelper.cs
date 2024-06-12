using System;
using Chess.Enums;
using Chess.Players;

namespace Chess.GameControl.Helper;

public static class InputHelper{
    public static List<IPlayer> InputPlayers(){
        Console.WriteLine("Hello, welcome to Chess Console Program!");
        Console.WriteLine($"This side is for {ColorType.White}. Enter your name!");
        string? player1 = Console.ReadLine();
        if (string.IsNullOrEmpty(player1))
        {
            player1 = "Player1"; // Default name if input is null or empty
        }
        IPlayer Player1 = new Player(0, player1, PlayerType.PlayerA);

        Console.WriteLine($"This side is for {ColorType.Black}. Enter your name!");
        string? player2 = Console.ReadLine();
        if (string.IsNullOrEmpty(player2))
        {
            player2 = "Player2"; // Default name if input is null or empty
        }
        IPlayer Player2 = new Player(0, player2, PlayerType.PlayerB);


        return new List<IPlayer> { Player1, Player2 };
    }   
}