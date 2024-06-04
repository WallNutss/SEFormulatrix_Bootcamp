using System;
using Chess.Enums;

namespace Chess.Players;
public interface IPlayer{
    int playerID {get;}
    string name {get; set;}
    PlayerType playerType {get; set;}
    string GetName();
    void SetName(string name);
}
