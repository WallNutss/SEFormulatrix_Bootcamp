using System;
using Chess.Pieces.Interface;
using Chess.Pieces.Implementation;
using Chess.Pieces.Child;
using Chess.Enums;


namespace Chess.PlayerData;

public class PlayerData{
    public int numOfPiecesPerPlayer;
    public List<IPiece> pieces {get;set;}
    public PlayerData(){
        this.numOfPiecesPerPlayer = 16;
        this.pieces = new List<IPiece>();
        InitializePieces();
    }
    public void InitializePieces(){
        for(int p=1;p<3;p++){
            ColorType pieceColor = p==1 ? ColorType.White : ColorType.Black;
            PlayerType playerType = p==1 ? PlayerType.PlayerA : PlayerType.PlayerB;
            for(int i=1;i<numOfPiecesPerPlayer+1;i++){
                if(i==1 || i==8){
                    this.pieces.Add(new Rook(i,pieceColor,playerType));
                }
                else if(i==2 || i==7){
                    this.pieces.Add(new Knight(i,pieceColor,playerType));
                }
                else if(i==3 || i==6){
                    this.pieces.Add(new Bishop(i,pieceColor,playerType));
                }
                else if(i==4){
                    this.pieces.Add(new King(i,pieceColor,playerType));
                }
                else if(i==6){
                    this.pieces.Add(new Queen(i,pieceColor,playerType));
                }
                else{
                    this.pieces.Add(new Pawn(i,pieceColor,playerType));
                }
        }
        }

    } 
}
