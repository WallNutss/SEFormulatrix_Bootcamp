using System;
using Chess.Enums;

namespace Chess.Pieces;
public interface IPiece{
    int pieceID { get; set; }
    bool isCaptured { get; set; }
    PiecesType piecesType { get; set; }
    PlayerType playerType { get; set; }
    void Move();
    void Capture();
    void IsValidMove();
    void PossibleMoves();

}
