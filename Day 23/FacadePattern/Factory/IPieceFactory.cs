using System;


public interface IPieceFactory{
    Piece MakeConcretePawnWhite(int id, IPosition position);
    Piece MakeConcretePawnBlack(int id, IPosition position);
    Piece MakeConcreteKnightWhite(int id, IPosition position);
    Piece MakeConcreteKnightBlack(int id, IPosition position);
    List<Piece> MakePieces(ColorType color);
}