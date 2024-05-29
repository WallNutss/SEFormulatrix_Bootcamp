using System;
using Chess.Enums;

namespace Chess.Pieces.Interface;
public interface IPiece{
    int pieceID { get; set; }
    bool isCaptured { get; set; }
    ColorType color{ get; set; }
    PiecesType piecesType { get; set; }
    PlayerType playerType { get; set; }
    void Move();
    void Capture();
    void IsValidMove();
    void PossibleMoves();

}
