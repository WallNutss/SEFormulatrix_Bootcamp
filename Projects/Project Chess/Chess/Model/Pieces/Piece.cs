using Chess.Enums;
using Chess.Boards;
using Chess.GameControl;
using Chess.PlayerDatas;


namespace Chess.Pieces;

public abstract class Piece:IPiece{
    public Coordinate pos {get; set;} = null!;
    public int pieceID { get; set; }
    public bool isCaptured { get; set; }
    public PiecesType piecesType { get; set; }
    public ColorType pieceColor { get; set; }

    public abstract Piece Copy();
    public abstract IEnumerable<Move> GetMoves(Coordinate from, GameController gc);
    protected IEnumerable<Coordinate> MovePositionInDir(Coordinate from, GameController gc, Direction dir){
        for(Coordinate pos = from+dir; gc.UtilitiesIsInsideBoard(pos); pos+=dir){
            if(gc.UtilitiesIsSquareEmpty(pos)){
                yield return pos;
                continue;
            }
            if(gc.UtilitiesIsOccupiedByOpponent(pos, this)){
                yield return pos;
            }
            yield break;
        }
    }
    protected IEnumerable<Coordinate> MovePositionInDirs(Coordinate from, GameController gc, Direction[] dirs){
        return dirs.SelectMany(dir => MovePositionInDir(from, gc, dir));
    }
    public void Move(){}
}