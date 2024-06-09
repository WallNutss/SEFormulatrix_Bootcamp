using System;


public class Pawn:Piece{
    public Pawn(int id, IPosition coordinate, ColorType color){
        pieceID = id;
        Position = coordinate;
        pieceType = PieceType.Pawn;
        colorType = color;
    }
    public Piece GetInfoPiece(){
        return this;
    }
}