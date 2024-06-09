using System;


public class PieceFactory:IPieceFactory{
    public Piece MakeConcretePawnWhite(int id, IPosition position){
        return new Pawn(id, position, ColorType.White);
    }
    public Piece MakeConcretePawnBlack(int id, IPosition position){
        return new Pawn(id, position, ColorType.Black);
    }
    public Piece MakeConcreteKnightWhite(int id, IPosition position){
        return new Knight(id, position, ColorType.White);
    }
    public Piece MakeConcreteKnightBlack(int id, IPosition position){
        return new Knight(id, position, ColorType.Black);
    }
    public List<Piece> MakePieces(ColorType colorPlayer){
        List<Piece> pieces = new List<Piece>();
        switch(colorPlayer){
            case ColorType.White:
                for(int i=1;i<=8;i++){
                    pieces.Add(MakeConcretePawnWhite(i, new Coordinate(7,i)));
                    if(i==2 || i==7){
                        pieces.Add(MakeConcreteKnightWhite(i, new Coordinate(8,i)));
                    }
                }
                break;
            case ColorType.Black:
                for(int i=1;i<=8;i++){
                    pieces.Add(MakeConcretePawnBlack(i, new Coordinate(2,i)));
                    if(i==2 || i==7){
                        pieces.Add(MakeConcreteKnightBlack(i, new Coordinate(1,i)));
                    }
                }
                break;
        }
        return pieces;
    }
}