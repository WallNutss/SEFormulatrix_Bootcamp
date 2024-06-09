using System;

public class GameControl{
    public Prison prison=null!;
    public DataPieces dataPieces=null!;
    public PieceFactory pieceFactory=null!;
    
    public GameControl(){
        prison = new Prison();
        dataPieces = new DataPieces();
        pieceFactory = new PieceFactory();
    }

    public List<Piece> SetPiecesForEachPlayer(ColorType color){
        return pieceFactory.MakePieces(color);
    }
    public void SaveWhitePlayerPieces(List<Piece> pieces){
        foreach(Piece p in pieces){
            dataPieces.AddPieceWhite(p);
        }
    }
    public void SaveBlackPlayerPieces(List<Piece> pieces){
        foreach(Piece p in pieces){
            dataPieces.AddPieceBlack(p);
        }
    }
    public void RemoveWhitePieceFromData(Piece piece){
        try{
            dataPieces.RemovePieceWhite(piece);
        }catch(Exception e){
            Console.WriteLine(e.Message);
        }
    }
    public void RemoveBlackPieceFromData(Piece piece){
        try{
            dataPieces.RemovePieceBlack(piece);
        }catch(Exception e){
            Console.WriteLine(e.Message);
        }
    }
    public List<Piece> GetPieceInformation(ColorType piece){
        return dataPieces.GetAllPiecesFromEachPlayer(piece);
    }
    public Piece GetWhitePieceInformation(int id){
        return dataPieces.GetWhitePieces(id);
    }
    public void AddPieceToPrison(Piece piece){
        prison.AddPiece(piece);
    }
    public void RemovePieceFromPrison(Piece piece){
        prison.AddPiece(piece);
        if(piece.colorType == ColorType.White){
            dataPieces.RemovePieceWhite(piece);
        }
        else if(piece.colorType == ColorType.Black){
            dataPieces.RemovePieceBlack(piece);
        }
    }

    
}