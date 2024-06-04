using System;


public class Player : IPlayer{
    public string PlayerName {get; private set;}
    public int PlayerID {get;}
    public Player(string name, int ID){
        PlayerName = name;
        PlayerID = ID;
    }

    // public void SetPlayerName(string name){
    //     PlayerName = name;
    // }
    public void GetInfo(){
        Console.WriteLine($"Player name : {PlayerName}");
        Console.WriteLine($"Player id : {PlayerID}\n");
    }
}