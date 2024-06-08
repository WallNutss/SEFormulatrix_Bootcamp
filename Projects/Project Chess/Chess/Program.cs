using System;
using System.Threading;

using Chess.Boards;
using Chess.Enums;
using Chess.PlayerDatas;
using Chess.GameControl;
using Chess.Render;
using Chess.Views;
using Chess.Pieces;


class Program{
    static void Main(){
        // Constructing the player default data positions, starting with the coordinates
        GameController controller = new();
        GameMenuRenderer GameMenuViews = new();
        
        controller.PreGameStart();
        GameMenuViews.Invoke($"{controller.GetGameStatus().ToString().Replace('_',' ')}");

        controller.StartGame();

        // AnimateLoading($"{controller.GetGameStatus().ToString().Replace('_',' ')}",2).Wait();

        while(controller.GetGameStatus() == GameStatus.GAME_START){
            // Console.Clear();
            GameMenuViews.Invoke($"{controller.GetGameStatus().ToString().Replace('_',' ')}");

            controller.board.PrintBoard(controller.GetPlayerPieceCollection()); 
            Console.WriteLine($"{AddColor.Message($"{controller.GetCurrentPlayer().name}'s",controller.GetCurrentPlayer().playerType)} turn");

            // Demo just try move something
            List<Coordinate> kingMoveCheck = null!;
            IEnumerable<Move> moves = null!;

            bool isValidMove = false;
            while(!isValidMove){
                var idRe = GameController.GetUserInput("Enter the ID pieces you want to move (e.g., 1):");
                int idRead = Convert.ToInt32(idRe);
                
                if(idRead == 4){
                    kingMoveCheck = controller.UtilitiesKingPossibleCheckStatus(controller.GetCurrentPlayer()).Distinct().ToList();
                    foreach(var m in kingMoveCheck){
                        Console.WriteLine($"{controller.GetCurrentPlayer().name} King if move will be a Possible Check at ({m.x},{m.y})");
                    }
                }

                // Try to calculate the possible Moves
                Piece currentPiece = controller.GetPieceData(controller.GetCurrentPlayer(), idRead);
                moves = currentPiece.GetMoves(currentPiece.pos, controller);
                int iterationCount = 0;
                foreach(var s in moves){
                    Console.WriteLine($"Move {iterationCount}: Pos=({s.ToPos.x},{s.ToPos.y})");
                    iterationCount++;
                }
                
                // PossibbleMoves(currentPiece) // Console this output
                bool isValidPossibleMove = false;
                Coordinate move = null!;
                while(!isValidPossibleMove){
                    try{
                        //Console.SetCursorPosition(0, 20);
                        Console.WriteLine("Enter your move (e.g., 2,4):");
                        // Console.SetCursorPosition(0, 21);
                        var moveString = GameController.GetUserInput();

                        if(moveString == "q"){
                            goto REPEATOUTERLOOP;
                        }
                        move = GameController.ConvertStringToIntArrayCoordinate(moveString);

                        isValidPossibleMove = controller.IsThisValidPossibleMove(moves, move);
                        if(!isValidPossibleMove){
                            Console.WriteLine("Invalid Move!");
                        }
                    }catch(Exception e){
                        Console.WriteLine(e.Message);
                    }
                }

                if(controller.UtilitiesIsOccupiedByOpponent(move, currentPiece)){
                    Piece pieceOvertaked = controller.GetPieceDataFromLocation(move);
                    controller.AddPiece2Prison(pieceOvertaked);
                    controller.RemovePieceFromData(pieceOvertaked);
                    controller.MovePiece(controller.GetCurrentPlayer(), move, idRead);
                }
                else{
                    controller.MovePiece(controller.GetCurrentPlayer(), move, idRead);
                }
                isValidMove = isValidPossibleMove;
            }
            // Check for Checkmate
            
            // Check for Check at the King, if its true, give warning
            IEnumerable<Coordinate> movesCheck2 = controller.UtilitiesKingCheckGeneralStatus();
            foreach(var moveCheck in movesCheck2){
                Console.WriteLine($"Check at : ({moveCheck.x},{moveCheck.y})");
            }
            // controller.UtilitiesKingPossibleCheckStatus(controller.GetCurrentOpponentPlayer(controller.GetCurrentPlayer()));
            // This section will be ideal to check wheter the King is unable to run or not
            
            List<Coordinate> kingMoveChecks = controller.UtilitiesKingPossibleCheckStatus(controller.GetCurrentOpponentPlayer(controller.GetCurrentPlayer())).Distinct().ToList();

            Piece KingOpponentPiece = controller.GetPieceData(controller.GetCurrentOpponentPlayer(controller.GetCurrentPlayer()), 4);
            IEnumerable<Move> kingMoves = KingOpponentPiece.GetMoves(KingOpponentPiece.pos, controller);

            bool checkmate = controller.UtilitiesCheckCheckmateStatus(kingMoves,kingMoveChecks);
            Console.WriteLine($"Checkmate? {checkmate}");

            // So before I switch current Player, I need to check the current game status
            controller.SwitchPlayerTurn(controller.GetCurrentPlayer());
            foreach(Piece pie in controller.GetPiecesFromPrison()){
                Console.WriteLine($"Piece : {pie.piecesType}, ID : {pie.pieceID}");
            }
        REPEATOUTERLOOP : continue;
        }
    }

    private static async Task AnimateLoading(string message, int durationSeconds){
        Console.Write($"{message} [");
        int totalWidth = 20; // Lebar total dari loading bar
        int animationSteps = durationSeconds * 2; // Jumlah langkah animasi (hitungan setengah detik)
        int delay = durationSeconds * 1000 / animationSteps; // Delay untuk setiap langkah animasi
        int stepWidth = totalWidth / animationSteps; // Lebar yang harus ditambahkan setiap langkah

        for (int i = 0; i <= animationSteps; i++)
        {
            int barWidth = i * stepWidth; // Lebar loading bar saat ini
            Console.Write($"{new string('\u2588', barWidth)}{new string(' ', totalWidth - barWidth)}] {i * 100 / animationSteps}%");
            Console.SetCursorPosition(Console.CursorLeft - (totalWidth + 5), Console.CursorTop); // Kembali ke awal baris
            await Task.Delay(delay); // Menunggu sebelum langkah berikutnya
        }
        Console.WriteLine();
    }
}
