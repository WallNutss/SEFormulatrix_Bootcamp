using Chess.Pieces.Interface;
using Chess.Enums;
using Chess.Boards.Interface;
namespace Chess.Pieces.Implementation;


abstract public class Piece:IPiece,ISquare{
    public int x{ get; set; }
    public int y{ get; set; }
    public ColorType color{ get; set; }
    public int pieceID { get; set; }
    public bool isCaptured { get; set; }
    public PiecesType piecesType { get; set; }
    public PlayerType playerType { get; set; }
    public void Move(){}
    public void Capture(){}
    public void IsValidMove(){}
    public void PossibleMoves(){}
    public void IsValid(){}
    public void GetAdjacent(){}
}