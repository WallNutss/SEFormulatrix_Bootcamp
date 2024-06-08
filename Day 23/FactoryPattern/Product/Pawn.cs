using System;


public class Pawn:Piece{
    public Pawn(int id, IPosition coordinate){
        pieceID = id;
        Position = coordinate;
        pieceType = PieceType.Pawn;
    }
    public Piece GetInfoPiece(){
        return this;
    }
}