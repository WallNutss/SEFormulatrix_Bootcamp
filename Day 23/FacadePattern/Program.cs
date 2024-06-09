using System;


class Program{
    static void Main(){
        // Here out facade, now mechanics will be controller by here
        GameControl gameFacade = new GameControl();

        // Let say I want to get list of pieces for each player
        // Instead go the the factory, we can use the method aavailable
        // in the GameControl
        List<Piece> BlackPieces = gameFacade.SetPiecesForEachPlayer(ColorType.Black);
        List<Piece> WhitePieces = gameFacade.SetPiecesForEachPlayer(ColorType.White);

        // Now I want to store those in my own data, we can also
        // use the facade to connect us to the database
        gameFacade.SaveWhitePlayerPieces(WhitePieces);
        gameFacade.SaveBlackPlayerPieces(BlackPieces);

        // So does our data store properly? We can call the data back
        // and lets print it, start with white, then black
        List<Piece> WhitePiecesFromData = gameFacade.GetPieceInformation(ColorType.White);
        foreach(var p in WhitePiecesFromData){
            Console.WriteLine($"[{p.colorType}] Piece with type: {p.pieceType} id : {p.pieceID} with pos xy : ({p.Position.X},{p.Position.Y})");
        }       
        Console.WriteLine("==========================");
        List<Piece> BlackPiecesFromData = gameFacade.GetPieceInformation(ColorType.Black);
        foreach(var p in BlackPiecesFromData){
            Console.WriteLine($"[{p.colorType}] Piece with type: {p.pieceType} id : {p.pieceID} with pos xy : ({p.Position.X},{p.Position.Y})");
        }
        Console.WriteLine("****************************");


        // What if we want to send to prison? Easy just do this,
        // No need to interact with the Prison, just do via facade
        // I want to remove id 6 from piece white
        Piece getWhitePiece = gameFacade.GetWhitePieceInformation(6);
        gameFacade.RemovePieceFromPrison(getWhitePiece);

        // Let see if its truly deleted from the data
        List<Piece> WhitePiecesFromData2 = gameFacade.GetPieceInformation(ColorType.White);
        foreach(var p in WhitePiecesFromData2){
            Console.WriteLine($"[{p.colorType}] Piece with type: {p.pieceType} id : {p.pieceID} with pos xy : ({p.Position.X},{p.Position.Y})");
        }    
    }
}