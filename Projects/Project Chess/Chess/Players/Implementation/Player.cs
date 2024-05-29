using System;
using Chess.Enums;
using Chess.Players.Interface;

namespace Chess.Players.Implementation;

public class Player:IPlayer{
    public int playerID {get; set;}
    public string name {get; set;}
    public PlayerType playerType{get;set;}
    public Player(int id, string name, PlayerType playerType){
        this.playerID = id;
        this.name = name;
        this.playerType = playerType;
    }
    public string GetName(){
        return this.name;
    }
    public void SetName(string name){
        this.name = name;
    } 

}
