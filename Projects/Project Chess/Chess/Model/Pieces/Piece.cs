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
    public abstract IEnumerable<Move> GetMoves(Coordinate FromPos, PlayerData PositionData);
    protected IEnumerable<Coordinate> MovePositionsInDir(Coordinate from, PlayerData BoardPositionData, Direction dir){
        for(Coordinate pos = from + dir; pos.x >= 0 && pos.x < 8 && pos.y >= 0 && pos.y < 8; pos+=dir){
            if(BoardPositionData.)
        }
    }
    public void Move(){}
    public void Capture(){}
    public void IsValidMove(){}
    public void PossibleMoves(){}
    public bool IsValid(){return true;}
    public void GetAdjacent(){}
}