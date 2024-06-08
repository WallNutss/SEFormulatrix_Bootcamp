using System;


public interface IPieceFactory{
    Piece MakeConcretePawn(int id, IPosition position);
    Piece MakeConcreteKnight(int id, IPosition position);
    List<Piece> MakePieces(ColorType color);
}