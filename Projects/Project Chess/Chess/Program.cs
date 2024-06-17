using System;
using System.Threading;

using Chess.Boards;
using Chess.Enums;
using Chess.PlayerDatas;
using Chess.GameControl;
using Chess.Render;
using Chess.Views;
using Chess.Pieces;
using Chess.GameControl.Helper;


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
                int pieceID = ConsoleInformation.GetUserInput("Enter the ID pieces you want to move (e.g., 1):").ConvertStringToInt();

                Piece currentPiece = controller.GetPieceData(controller.GetCurrentPlayer(), pieceID);
                // Special treatment to King to restrict it moves when it is in Danger
                if(pieceID == 4){
                    kingMoveCheck = controller.UtilitiesKingPossibleCheckStatus(controller.GetCurrentPlayer()).Distinct().ToList();
                    foreach(var m in kingMoveCheck){
                        Console.WriteLine($"{controller.GetCurrentPlayer().name} King if move will be a Possible Check at ({m.x},{m.y})");
                    }
                    // Try to restrict or move out any possible move that makes king in Check out of global moves
                    IEnumerable<Move> kingMoves = currentPiece.GetMoves(currentPiece.pos, controller);
                    moves = controller.UtilitiesGetMovesNotInCoordinates(kingMoves, kingMoveCheck);
                }else{
                    // Try to calculate the possible Moves of any other pieces beside king
                    moves = currentPiece.GetMoves(currentPiece.pos, controller);
                }

                // Print out the moves available of possible move it can reach, if king Add restriction to it!
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
                        var moveInput = ConsoleInformation.GetUserInput("Enter your move (e.g., 2,4):\nType'q' to escape and pick new piece!");
                        if(moveInput == "q"){
                            goto REPEATOUTERLOOP;
                        }
                        move = moveInput.ConvertStringToCoordinate();

                        isValidPossibleMove = controller.IsThisValidPossibleMove(moves, move);
                        if(!isValidPossibleMove){
                            Console.WriteLine("Invalid Move!");
                        }
                    }catch(Exception e){
                        Console.WriteLine(e.Message);
                    }
                }

                if(controller.UtilitiesIsOccupiedByOpponent(move, currentPiece)){
                    Piece capturedPiece = controller.GetPieceDataFromLocation(move);
                    controller.PieceCapture(currentPiece, capturedPiece);
                }
                else{
                    controller.MovePiece(currentPiece, move);
                }
                isValidMove = isValidPossibleMove;
            }
            // Check for Checkmate
            controller.CheckmateManagerSytemAssesor();

            // Keyboard pause so player can see for a minute how been checks and who is in danger
            Console.ReadKey();

            // So before I switch current Player, I need to check the current game status
            controller.SwitchPlayerTurn(controller.GetCurrentPlayer());
            foreach(Piece pie in controller.GetListPieceFromPrison()){
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
