using System;



public abstract class Piece{
    public int pieceID { get; set; }
    public PieceType pieceType {get;set;} // Read only, will not change, will only construct once in constructor
    public ColorType colorType {get;set;} // Read only, will not change, will only construct once in constructor
    public IPosition Position {get;set;}
    
}