using System;
using Chess.Boards;
using Chess.Enums;
using Chess.Pieces;
using Chess.PlayerDatas;

namespace Chess.GameControl;


public class NormalMove : Move{
    public override MovesType Type {get;}
    public override Coordinate FromPos {get;}
    public override Coordinate ToPos {get;}
    public NormalMove(Coordinate from, Coordinate to){
        FromPos = from;
        ToPos = to;
        Type = MovesType.Normal;
    }
    public override void Execute(GameController gc, PlayersData datas){
        // This Exceute method is a template for all the types of moves out there, Basically it takes the pieces information crucially
        // their types so 
        Piece piece = gc.GetPieceDataFromLocation(FromPos); // Get the piece in question from the location
        gc.UpdatePiecePosition(piece, ToPos); // Update the location?
    }
}