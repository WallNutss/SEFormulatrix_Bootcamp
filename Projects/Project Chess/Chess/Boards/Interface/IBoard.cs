namespace Chess.Boards.Interface;
using Chess.Boards.Implementation;
using Chess.PlayerData;
using Chess.Pieces.Implementation;


/// <summary>
/// An Interface of Board
/// </summary>
public interface IBoard{
    List<ISquare> squares {get; set;}
    int width { get; }
    int height { get; }
    void SetupBoard(ref PlayerData playerData);
    void MovePiece();
    void GetPieceAt();
    void IsOccupied();
    void IsOccupiedByOpponent();
    void InitializeCoordinate();
    void PrintBoard(PlayerData playerData);
    void PrintEachRowBoard(List<ISquare> square, List<Piece> pieceWithData);
}
