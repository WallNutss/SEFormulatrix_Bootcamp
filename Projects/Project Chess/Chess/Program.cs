using System;
using System.Threading;

using Chess.Boards;
using Chess.Enums;
using Chess.PlayerDatas;
using Chess.Prisons;
using Chess.Players;
using Chess.GameController;
using Chess.Render;
using Chess.Views;


class Program{
    static void Main(){
        // Constructing the player default data positions, starting with the coordinates
        GameController controller = new();
        
        controller.PreGameStart();
        controller.StartGame();

        AnimateLoading($"{controller.GetGameStatus().ToString().Replace('_',' ')}",10).Wait();

        while(controller.GetGameStatus() == GameStatus.GAME_START){
            Console.Clear();
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
