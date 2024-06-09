using System;


public class Knight:Piece{
    public Knight(int id, IPosition coordinate, ColorType color){
        pieceID = id;
        Position = coordinate;
        pieceType = PieceType.Knight;
        colorType = color;
    }
    public Piece GetInfoPiece(){
        return this;
    }
}