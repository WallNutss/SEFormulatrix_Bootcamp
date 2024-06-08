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
        
        controller.PreGameStart();
        controller.StartGame();

        // AnimateLoading($"{controller.GetGameStatus().ToString().Replace('_',' ')}",10).Wait();

        while(controller.GetGameStatus() == GameStatus.GAME_START){
            // Console.Clear();
            GameMenuRenderer StartGameViews = new($"{controller.GetGameStatus().ToString().Replace('_',' ')}");
            StartGameViews.Invoke();

            controller.board.PrintBoard(controller.GetPlayerPieceCollection()); 
            Console.WriteLine($"{AddColor.Message($"{controller.GetCurrentPlayer().name}'s",controller.GetCurrentPlayer().playerType)} turn");

            // Demo just try move something
            bool isValidMove = false;
            while(!isValidMove){
                // Console.SetCursorPosition(0, 18);
                Console.WriteLine("Enter the ID pieces you want to move (e.g., 1):");
                // Console.SetCursorPosition(0, 19);
                var idRe = GameController.GetUserInput();
                int idRead = Convert.ToInt32(idRe);

                if(idRead == 4){
                    IEnumerable<Coordinate> kingMoveCheck = controller.UtilitiesKingPossibleCheckStatus(controller.GetCurrentPlayer());
                    foreach(var m in kingMoveCheck){
                        Console.WriteLine($"Possible Check at ({m.x},{m.y})");
                    }
                }

                // Try to calculate the possible Moves
                Piece currentPiece = controller.GetPieceData(controller.GetCurrentPlayer(), idRead);
                IEnumerable<Move> moves = currentPiece.GetMoves(currentPiece.pos, controller);
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
                        isValidPossibleMove = moves.Any(p => p.ToPos.x == move.x && p.ToPos.y == move.y);
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
                
                isValidMove = true;
            }
            // Check for Checkmate
            // Check for Check at the King, if its true, give warning
            IEnumerable<Coordinate> movesCheck = controller.UtilitiesKingCheckStatus(controller.GetCurrentOpponentPlayer(controller.GetCurrentPlayer()));
            foreach(var moveCheck in movesCheck){
                Console.WriteLine($"Check at : ({moveCheck.x},{moveCheck.y})");
            }
            IEnumerable<Coordinate> movesCheck2 = controller.UtilitiesKingCheckGeneralStatus();
            foreach(var moveCheck in movesCheck2){
                Console.WriteLine($"Check2 at : ({moveCheck.x},{moveCheck.y})");
            }
            // controller.UtilitiesKingPossibleCheckStatus(controller.GetCurrentOpponentPlayer(controller.GetCurrentPlayer()));
            // 
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
