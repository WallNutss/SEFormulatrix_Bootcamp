using System;
using Chess.Boards;
using Chess.Pieces;
using Chess.Enums;

namespace Chess.PiecesFactory;

public class PieceFactory: IPieceFactory{
    public Piece MakeConcretePawn(int pieceID, ColorType color, Coordinate position){
        return new Pawn(pieceID, color, position);
    }
    public Piece MakeConcreteRook(int pieceID, ColorType color, Coordinate position){
        return new Rook(pieceID, color, position);
    }
    public Piece MakeConcreteKnight(int pieceID, ColorType color, Coordinate position){
        return new Knight(pieceID, color, position);
    }
    public Piece MakeConcreteBishop(int pieceID, ColorType color, Coordinate position){
        return new Bishop(pieceID, color, position);
    }
    public Piece MakeConcreteQueen(int pieceID, ColorType color, Coordinate position){
        return new Queen(pieceID, color, position);
    }  
    public Piece MakeConcreteKing(int pieceID, ColorType color, Coordinate position){
        return new King(pieceID, color, position);
    }

    public List<Piece> MakePieces(ColorType colorPlayer){
        List<Piece> pieces = new List<Piece>();
        // Start assigning the color for each player Type, see dictionary at AddColor for more detail
        int pieceID = 1;
        switch(colorPlayer){
            case ColorType.White:
                // For each row of the board or y-coordinate
                for(int p=0;p<2;p++){
                    if(p==0){
                        for(int i=1;i<=8;i++){
                            if(i==1 || i==8){
                                pieces.Add(new Rook(pieceID,colorPlayer,new Coordinate(i,8)));
                            }
                            else if(i==2 || i==7){
                                pieces.Add(new Knight(pieceID,colorPlayer, new Coordinate(i,8)));
                            }
                            else if(i==3 || i==6){
                                pieces.Add(new Bishop(pieceID,colorPlayer, new Coordinate(i,8)));
                            }
                            else if(i==4){
                                pieces.Add(new King(pieceID,colorPlayer,new Coordinate(i,8)));
                            }
                            else if(i==5){
                                pieces.Add(new Queen(pieceID,colorPlayer,new Coordinate(i,8)));
                            }
                            pieceID++;
                        }
                    }else{
                        for(int i=1;i<=8;i++){
                            pieces.Add(new Pawn(pieceID, colorPlayer, new Coordinate(i,7)));
                            pieceID++;
                        }
                    }
                }
                break;
            case ColorType.Black:
                // For each row of the board or y-coordinate
                for(int p=0;p<2;p++){
                    if(p==0){
                        for(int i=1;i<=8;i++){
                            if(i==1 || i==8){
                                pieces.Add(new Rook(pieceID,colorPlayer,new Coordinate(i,1)));
                            }
                            else if(i==2 || i==7){
                                pieces.Add(new Knight(pieceID,colorPlayer, new Coordinate(i,1)));
                            }
                            else if(i==3 || i==6){
                                pieces.Add(new Bishop(pieceID,colorPlayer, new Coordinate(i,1)));
                            }
                            else if(i==4){
                                pieces.Add(new King(pieceID,colorPlayer,new Coordinate(i,1)));
                            }
                            else if(i==5){
                                pieces.Add(new Queen(pieceID,colorPlayer,new Coordinate(i,1)));
                            }
                            pieceID++;
                        }
                    }else{
                        for(int i=1;i<=8;i++){
                            pieces.Add(new Pawn(pieceID, colorPlayer, new Coordinate(i,2)));
                            pieceID++;
                        }
                    }
                }
                break;
        }
    return pieces;
    }
}