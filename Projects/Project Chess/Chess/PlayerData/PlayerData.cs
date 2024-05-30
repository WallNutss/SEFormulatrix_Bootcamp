using System;
using Chess.Pieces.Interface;
using Chess.Pieces.Implementation;
using Chess.Pieces.Child;
using Chess.Enums;
using Chess.Boards.Interface;
using Chess.Boards.Implementation;
using System.Security.Cryptography.X509Certificates;


namespace Chess.PlayerData;

public class PlayerData{
    public int numOfPiecesPerPlayer;
    public List<Piece> pieces {get;set;}
    public PlayerData(){
        this.numOfPiecesPerPlayer = 16;
        this.pieces = new List<Piece>();
        InitializePieces();
    }
    public void InitializePieces(){
        for(int p=1;p<3;p++){
            ColorType pieceColor = p==1 ? ColorType.White : ColorType.Black;
            PlayerType playerType = p==1 ? PlayerType.PlayerA : PlayerType.PlayerB;
            for(int i=1;i<numOfPiecesPerPlayer+1;i++){
                if(i==1 || i==8){
                    ICoordinate properties = new Coordinate(_x:0, _y:0,color:pieceColor);
                    this.pieces.Add(new Rook(i,playerType,properties));
                }
                else if(i==2 || i==7){
                    ICoordinate properties = new Coordinate(_x:0, _y:0,color:pieceColor);
                    this.pieces.Add(new Knight(i,playerType, properties));
                }
                else if(i==3 || i==6){
                    ICoordinate properties = new Coordinate(_x:0, _y:0,color:pieceColor);
                    this.pieces.Add(new Bishop(i,playerType, properties));
                }
                else if(i==4){
                    ICoordinate properties = new Coordinate(_x:0, _y:0,color:pieceColor);
                    this.pieces.Add(new King(i,playerType,properties));
                }
                else if(i==5){
                    ICoordinate properties = new Coordinate(_x:0, _y:0,color:pieceColor);
                    this.pieces.Add(new Queen(i,playerType,properties));
                }
                else{
                    ICoordinate properties = new Coordinate(_x:0, _y:0,color:pieceColor);
                    this.pieces.Add(new Pawn(i,playerType, properties));
                }
            }
        }

    } 
}
