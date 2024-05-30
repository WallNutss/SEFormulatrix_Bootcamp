using System;
using Chess.Pieces.Implementation;


namespace Chess.Prisons;

public class Prison{
    private List<Piece>? _capturedPieces { get; set;}
    void RemovePiece(Piece piece){
        // Remove Captured Pieces from prison when they are regained
    }
    void AddPiece(Piece piece){
        // Add Captured Pieces to the prison communities
    }
}