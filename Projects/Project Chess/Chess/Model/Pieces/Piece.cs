using Chess.Enums;
using Chess.Boards;
using Chess.GameController;
using Chess.PlayerDatas;


namespace Chess.Pieces;

public abstract class Piece:IPiece{
    public IPosition pos {get; set;} = null!;
    public int pieceID { get; set; }
    public bool isCaptured { get; set; }
    public PiecesType piecesType { get; set; }
    public ColorType pieceColor { get; set; }

    // public abstract Piece Copy();
    public void Move(){}
    public void Capture(){}
    public void IsValidMove(){}
    public void PossibleMoves(){}
    public bool IsValid(){return true;}
    public void GetAdjacent(){}
}