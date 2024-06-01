namespace Chess.Boards;

using Chess.PlayerDatas;
using Chess.Pieces;
using Chess.Players;



/// <summary>
/// An Interface of Board
/// </summary>
public interface IBoard{
    List<IPosition> squares {get; set;}
    int width { get; }
    int height { get; }
    void MovePiece();
    void GetPieceAt();
    void IsOccupied();
    void IsOccupiedByOpponent();
    void InitializeCoordinate();
    void PrintBoard(Dictionary <IPlayer, List<Piece>> playerData);
    string PrintEachRowBoard(List<Piece> pieceWithData, int x);
}
