namespace Chess.Boards.Interface;
using Chess.Boards.Implementation;

public interface IBoard{
    int width { get; }
    int height { get; }
    void SetupBoard();
    void MovePiece();
    void GetPieceAt();
    void IsOccupied();
    void IsOccupiedByOpponent();
    void InitializeCoordinate();
    void PrintBoard();
    void PrintEachRowBoard(List<ISquare> square);
}
