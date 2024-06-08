using System;


class Program{
    static void Main(){
        // Let say that we want to make a class/instantiate a class like this
        // Below will be all comments

        /*
        // Let say I want to build pieces where it varies
        // based on those position
        Pawn pawn1 = new Pawn(1, PiececType.Pawn, pos);
        Pawn pawn2 = new Pawn(2, PiececType.Pawn, pos);

        // OK thats good, but what happen if class Pawn is refabricated?
        // What if that we really dont want our blueprint of pieces just bare around like that?
        // What if there are multiple pices(Which in this case it does)
        // And to do does logic when instantating something?
        
        // Another way we can aproach for this class creation is using Factory Design Pattern
        // We encapsulate the class creation/instantiate in another program
        // And in nutshell not dirtying the entire codebase
        
        PieceFactory pieceFactory = new();
        pieceFactory.makePawn(); --> Will return Pawn

        // And that sit 
        For Simplity sake, lets make an example with two piece only
        // Pawn for black side need to be there in (2,1) to (2,8)
        // Where pawn for white side need to be there in (7,1) to (7,8)
        */
        Console.WriteLine("Hello World, lets start building each pieces for player to each player");

        // Building Factory
        PieceFactory pieceFactory = new();

        List<Piece> playerWhitePieces = pieceFactory.MakePieces(ColorType.White);
        List<Piece> playerBlackPieces = pieceFactory.MakePieces(ColorType.Black);

        // Printing each one
        Console.WriteLine("Player white pieces");
        foreach(var p in playerWhitePieces){
            Console.WriteLine($"Piece with type: {p.pieceType} id : {p.pieceID} with pos xy : ({p.Position.X},{p.Position.Y})");
        }
        Console.WriteLine("===================");
        Console.WriteLine("Player black pieces");
        foreach(var p in playerBlackPieces){
            Console.WriteLine($"Piece with type: {p.pieceType} id : {p.pieceID} with pos xy : ({p.Position.X},{p.Position.Y})");
        }

        // We success building the pieces with lot of logic under the Factory, so program wuill be
        // clean and the dirtier code will be place in the Factory only
        // So if there is another let say Player with color Green, we can just pass the argument
        // And the factory will print out the pieces for us, No new() constructor in the main program

    }
}