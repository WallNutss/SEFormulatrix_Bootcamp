using System;


public class PieceFactory:IPieceFactory{
    public Piece MakeConcretePawn(int id, IPosition position){
        return new Pawn(id, position);
    }
    public Piece MakeConcreteKnight(int id, IPosition position){
        return new Knight(id, position);
    }
    public List<Piece> MakePieces(ColorType colorPlayer){
        List<Piece> pieces = new List<Piece>();
        switch(colorPlayer){
            case ColorType.White:
                for(int i=1;i<=8;i++){
                    pieces.Add(MakeConcretePawn(i, new Coordinate(7,i)));
                    if(i==2 || i==7){
                        pieces.Add(MakeConcreteKnight(i, new Coordinate(8,i)));
                    }
                }
                break;
            case ColorType.Black:
                for(int i=1;i<=8;i++){
                    pieces.Add(MakeConcretePawn(i, new Coordinate(2,i)));
                    if(i==2 || i==7){
                        pieces.Add(MakeConcreteKnight(i, new Coordinate(1,i)));
                    }
                }
                break;
        }
        return pieces;
    }
}