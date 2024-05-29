using System;
using Chess.Enums;

namespace Chess.Players.Interface;
public interface IPlayer{
    int playerID {get; set;}
    string name {get; set;}
    PlayerType playerType {get; set;}
    string GetName();
    void SetName(string name);
}
