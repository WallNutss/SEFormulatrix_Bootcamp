using System;
using Chess.Pieces;
using Chess.Enums;
using Chess.Boards;


namespace Chess.PlayerData;

public class PlayerData{
    public int numOfPiecesPerPlayer;
    public List<Piece> pieces {get;set;}
    public PlayerData(){
        this.numOfPiecesPerPlayer = 16;
        this.pieces = new List<Piece>();
        _InitializePieces();
    }
    private void _InitializePieces(){
        for(int p=1;p<3;p++){
            ColorType pieceColor = p==1 ? ColorType.Black : ColorType.White;
            PlayerType playerType = p==1 ? PlayerType.PlayerB : PlayerType.PlayerA;
            for(int i=1;i<=numOfPiecesPerPlayer;i++){
                IPosition position = new Coordinate(0,0);   
                if(i==1 || i==8){
                    this.pieces.Add(new Rook(i,playerType,pieceColor,position));
                }
                else if(i==2 || i==7){
                    this.pieces.Add(new Knight(i,playerType,pieceColor, position));
                }
                else if(i==3 || i==6){
                    this.pieces.Add(new Bishop(i,playerType,pieceColor, position));
                }
                else if(i==4){
                    this.pieces.Add(new King(i,playerType,pieceColor,position));
                }
                else if(i==5){
                    this.pieces.Add(new Queen(i,playerType,pieceColor,position));
                }
                else{
                    this.pieces.Add(new Pawn(i,playerType, pieceColor,position));
                }
            }
        }

    } 
}
