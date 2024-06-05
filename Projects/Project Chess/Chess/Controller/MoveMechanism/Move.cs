using System;
using Chess.Boards;
using Chess.Enums;
using Chess.PlayerDatas;

namespace Chess.GameControl;


public abstract class Move{
    public abstract MovesType Type {get;}
    public abstract Coordinate FromPos {get;}
    public abstract Coordinate ToPos {get;}
    public abstract void Execute(GameController gc, PlayersData datas);
}