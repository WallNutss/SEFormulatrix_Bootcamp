using System;
using Chess.Boards;
using Chess.Pieces;
using Chess.Enums;

namespace Chess.PiecesFactory;

public interface IPieceFactory{
    Piece MakeConcretePawn(int id, ColorType color, Coordinate position);
    Piece MakeConcreteRook(int id, ColorType color, Coordinate position);
    Piece MakeConcreteKnight(int id, ColorType color, Coordinate position);
    Piece MakeConcreteBishop(int id, ColorType color, Coordinate position);
    Piece MakeConcreteQueen(int id, ColorType color, Coordinate position);
    Piece MakeConcreteKing(int id, ColorType color, Coordinate position);
    List<Piece> MakePieces(ColorType color); 
}