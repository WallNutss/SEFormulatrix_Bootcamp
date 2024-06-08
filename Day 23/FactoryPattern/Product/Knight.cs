using System;


public class Knight:Piece{
    public Knight(int id, IPosition coordinate){
        pieceID = id;
        Position = coordinate;
        pieceType = PieceType.Knight;
    }
    public Piece GetInfoPiece(){
        return this;
    }
}