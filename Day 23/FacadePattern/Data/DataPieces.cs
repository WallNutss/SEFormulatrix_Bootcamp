using System;

public class DataPieces{
    private List<Piece> _playerWhitePieces;
    private List<Piece> _playerBlackPieces;
    public DataPieces(){
        _playerWhitePieces = new List<Piece>();
        _playerBlackPieces = new List<Piece>();
    }
    public void RemovePieceBlack(Piece piece){
        _playerBlackPieces.Remove(piece);
        // Remove Captured Pieces from prison when they are regained
    }
    public void AddPieceBlack(Piece piece){
        _playerBlackPieces.Add(piece);
        // Add Captured Pieces to the prison communities
    }
    public Piece GetBlackPieces(int id){
        return _playerBlackPieces.Where(p=>p.pieceID==id).First<Piece>();
    }
    public void RemovePieceWhite(Piece piece){
        _playerWhitePieces.Remove(piece);
        // Remove Captured Pieces from prison when they are regained
    }
    public void AddPieceWhite(Piece piece){
        _playerWhitePieces.Add(piece);
        // Add Captured Pieces to the prison communities
    }
    public Piece GetWhitePieces(int id){
        return _playerWhitePieces.Where(p=>p.pieceID==id).First<Piece>();
    }
    public List<Piece> GetAllPiecesFromEachPlayer(ColorType color){
        return color switch{
            ColorType.White => _playerWhitePieces,
            ColorType.Black => _playerBlackPieces,
        };
    }
}