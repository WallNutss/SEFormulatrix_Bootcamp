namespace Chess.Boards;

using Chess.PlayerData;
using Chess.Pieces;


/// <summary>
/// An Interface of Board
/// </summary>
public interface IBoard{
    List<IPosition> squares {get; set;}
    int width { get; }
    int height { get; }
    void SetupBoard(ref PlayerData playerData);
    void MovePiece();
    void GetPieceAt();
    void IsOccupied();
    void IsOccupiedByOpponent();
    void InitializeCoordinate();
    void PrintBoard(PlayerData playerData);
    void PrintEachRowBoard(List<Piece> pieceWithData, int x);
}
