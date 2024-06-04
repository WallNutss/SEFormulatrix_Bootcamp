using System;
using System.Threading;

using Chess.Boards;
using Chess.Enums;
using Chess.PlayerDatas;
using Chess.Prisons;
using Chess.Players;
using Chess.GameController;
using Chess.Render;


class Program{
    static void Main(){
        // Constructing the player default data positions, starting with the coordinates
        GameController controller = new();
        
        controller.PreGameStart();
        
        controller.StartGame();

        while(controller.GetGameStatus() == GameStatus.GAME_START){
            Console.Clear();
            controller.board.PrintBoard(controller.GetPlayerPieceCollection()); 
             
            // Console.SetCursorPosition(0, 17);
            Console.WriteLine($"{controller.GetCurrentPlayer().name}'s turn");

            // Demo just try move something
            bool isValidMove = false;
            while(!isValidMove){
                // Console.SetCursorPosition(0, 18);
                Console.WriteLine("Enter the ID pieces you want to move (e.g., 1):");
                // Console.SetCursorPosition(0, 19);
                var idRe = GameController.GetUserInput();
                int idRead = Convert.ToInt32(idRe);

                // Try to calculate the possible Moves
                // Piece currentPiece = this.playersData.GetPieceData(idRead, this.currentPlayer);
                // PossibbleMoves(currentPiece) // Console this output
                
                // Console.SetCursorPosition(0, 20);
                Console.WriteLine("Enter your move (e.g., 2,4):");
                // Console.SetCursorPosition(0, 21);
                var moveString = GameController.GetUserInput();
                Coordinate move = GameController.ConvertStringToIntArrayCoordinate(moveString);

                
                controller.MovePiece(controller.GetCurrentPlayer(), move, idRead);
                isValidMove = true;
            }
            controller.SwitchPlayerTurn(controller.GetCurrentPlayer());
        }

    }
}
