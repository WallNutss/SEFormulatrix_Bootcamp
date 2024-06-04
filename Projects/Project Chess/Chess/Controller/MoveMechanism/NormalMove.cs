using System;
using Chess.Boards;
using Chess.Enums;
using Chess.Pieces;
using Chess.PlayerDatas;

namespace Chess.GameController;


public abstract class NormalMove:Move{
    public override MovesType Type {get;}
    public override Coordinate FromPos {get;}
    public override Coordinate ToPos {get;}
    public NormalMove(Coordinate from, Coordinate to){
        this.FromPos = from;
        this.ToPos = to;
        this.Type = MovesType.Normal;
    }
    // public override void Execute(ref PlayersData datas){
    //     // This Exceute method is a template for all the types of moves out there, Basically it takes the pieces information crucially
    //     // their types so 
    //     Piece piece = datas.GetPieceData(this.FromPos); // Get the piece in question from the location
    //     datas.UpdatePiecePosition(piece, ToPos);
    // }
}