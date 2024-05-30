using Chess.Pieces.Interface;
using Chess.Enums;
using Chess.Boards.Interface;
using Chess.Boards.Implementation;
using Chess.Players.Implementation;
namespace Chess.Pieces.Implementation;


abstract public class Piece:IPiece{
    public ICoordinate Properties {get; set;} = null!;
    public int pieceID { get; set; }
    public bool isCaptured { get; set; }
    public PiecesType piecesType { get; set; }
    public PlayerType playerType { get; set; }
    public void Move(){}
    public void Capture(){}
    public void IsValidMove(){}
    public void PossibleMoves(){}
    public bool IsValid(){return true;}
    public void GetAdjacent(){}
}