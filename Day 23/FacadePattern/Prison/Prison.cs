using System;

public class Prison{
    private List<Piece> _capturedPieces=null!;
    public Prison(){
        _capturedPieces = new List<Piece>();
    }
    public void RemovePiece(Piece piece){
        _capturedPieces.Remove(piece);
        // Remove Captured Pieces from prison when they are regained
    }
    public void AddPiece(Piece piece){
        _capturedPieces.Add(piece);
        // Add Captured Pieces to the prison communities
    }
    public Piece GetPieceInformation(int id){
        return _capturedPieces.Where(p=>p.pieceID==id).First<Piece>();
    }
    
}