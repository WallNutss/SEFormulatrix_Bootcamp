using System;
using System.Threading;
using Chess.Boards;
using Chess.PlayerDatas;
using Chess.Players;
using Chess.Enums;
using Chess.Pieces;
using Chess.Views;
using Chess.GameController.Helper;
using Chess.Prisons;

namespace Chess.GameController;


public class GameController{
    // Inisialization of all the model in the game
    private Board _board {get;}
    private PlayersData _playersData;
    public IPlayer? currentPlayer;
    // Construct the prison house, default at the start game it's empty
    public Prison prison;
    public int numOfPiecesPerPlayer = 16;
    public GameStatus gameStatus {get;private set;}
    public ManualResetEvent stopSignal {get;set;}
    public GameController(){
        _board = new Board();
        _playersData = new PlayersData();
        prison = new Prison();
        gameStatus = GameStatus.NOT_STARTED;
        stopSignal = new ManualResetEvent(false);
    }

    public void PreGameStart(){
        PreGameStartView views = new("Pre Game");
        views.Invoke();
        // _board.PrintBoard(this.playersData.GetPlayersData());
        // User choose player
        InputHelper.InputPlayers().ForEach((IPlayer player)=> SetUserNamePlayer(player));
        PlayerListView view = new(GetPlayersFromList());
        view.Invoke();        
    }

    public void StartGame(){
        //MovePiece(this.currentPlayer);
        currentPlayer = GetPlayersFromList().Where(p => p.playerType == PlayerType.PlayerA).First<IPlayer>(); // White always start first
        // var printBoardTask = Task.Run(()=>RefreshBoardAsync(stopSignal));
        // _board.PrintBoard(this.playersData.GetPlayersData());
        //Console.Clear();
        _board.PrintBoard(GetPlayerPieceCollection());
        // while(gameStatus == GameStatus.GAME_START){

        //     // Console.SetCursorPosition(0, 17);
        //     Console.WriteLine($"{currentPlayer.name}'s turn");

        //     // Demo just try move something
        //     bool isValidMove = false;
        //     while(!isValidMove){
        //         // Console.SetCursorPosition(0, 18);
        //         Console.WriteLine("Enter the ID pieces you want to move (e.g., 1):");
        //         // Console.SetCursorPosition(0, 19);
        //         var idRe = GetUserInput();
        //         int idRead = Convert.ToInt32(idRe);

        //         // Try to calculate the possible Moves
        //         // Piece currentPiece = this.playersData.GetPieceData(idRead, this.currentPlayer);
        //         // PossibbleMoves(currentPiece) // Console this output
                
        //         // Console.SetCursorPosition(0, 20);
        //         Console.WriteLine("Enter your move (e.g., 2,4):");
        //         // Console.SetCursorPosition(0, 21);
        //         var moveString = GetUserInput();
        //         Coordinate move = ConvertStringToIntArrayCoordinate(moveString);

                
        //         MovePiece(currentPlayer, move, idRead);
        //         isValidMove = true;
        //     }
        //     SwitchPlayerTurn(currentPlayer);
            
        // }
        // // stopSignal.Set();
        // // printBoardTask.Wait();
        // Console.WriteLine("Game over!");
        
        // Coordinate coordinate = new(2,2);
        // Coordinate coordinate2 = new(3,5);
        // Coordinate coordinate3 = new(2,1);
        // players[0] is PlayerB
        // players[1] is PlayerA
        // Console.WriteLine(UtilitiesIsSquareEmpty(coordinate));
        // Console.WriteLine(this.playersData.GetPlayer()[0].playerType);
        // Console.WriteLine(UtilitiesIsOccupiedByOpponent(coordinate2, this.playersData.GetPlayer()[0]));
    }
   
    public void StopGame(){}
    public void EndTurn(){}

    static Coordinate ConvertStringToIntArrayCoordinate(string input)
    {
        int[] xy = input.Split(',').Select(int.Parse).ToArray();
        return new Coordinate(xy[0],xy[1]);
    }

    public static string GetUserInput(){
            return Console.ReadLine() ?? string.Empty;
    }
    public async Task RefreshBoardAsync(ManualResetEvent stopSignal){
        while (!stopSignal.WaitOne(0)){
        // Console.WriteLine("Run");
        _board.PrintBoard(GetPlayerPieceCollection());
        await Task.Delay(500);
        }
    }
    public void MovePiece(IPlayer player, Coordinate toPos, int pieceID){
        Piece piece = GetPieceData(player,pieceID);
        UpdatePiecePosition(piece, toPos);
    }
    public void MakeTurn(){}

    // GameController - Player Function
    public void SwitchPlayerTurn(IPlayer player){
        if(player.playerType == PlayerType.PlayerA){
            this.currentPlayer =  GetPlayersFromList().Where(p => p.playerType != PlayerType.PlayerA).First<IPlayer>();
        }
        else if(player.playerType == PlayerType.PlayerB){
            this.currentPlayer =  GetPlayersFromList().Where(p => p.playerType != PlayerType.PlayerB).First<IPlayer>();
        }
    }
    public void PossibleMoves(IPlayer player, Piece piece){
        // return the possible move based on those criteria
        // piece.PieceType? return directions
        //  var PossibeMovesPossible move based on those direction ? Return list of Coordinate it can takee
        Direction one = Direction.moveDirection[DirectionMoveType.North];
    }
    
    public void SetUserNamePlayer(IPlayer player){
        GetPlayersFromList().Where(p => p.playerType == player.playerType).First<IPlayer>().SetName(player.name);
    }

    public IPlayer GetPlayer(IPlayer player){
        return _playersData.GetAllPlayerFromPlayersList().Where(p => p.playerID == player.playerID).First<IPlayer>();
    }

    // GameController -  Game State
    public GameStatus GetGameStatus(){
        return this.gameStatus;
    }
    public void SetGameStatus(GameStatus status){
        Console.WriteLine($"Game has been change into {status}");
        this.gameStatus = status;
    }


    // Method to access the Player Data
    public Dictionary<IPlayer,List<Piece>> GetPlayerPieceCollection(){
        return _playersData.GetPlayerPieceCollectionData();
    }
    public void AddPlayerPieceCollection(IPlayer player, List<Piece> data){
        _playersData.AddPlayerPieceCollectionData(player,data);
    }
    public List<Piece> GetPiecesList(){
        return _playersData.GetPiecesListData();
    }

    public List<IPlayer> GetPlayersFromList(){
        return _playersData.GetAllPlayerFromPlayersList();
    }
    public void UpdatePiecePosition(Piece piece, Coordinate toPos){
        _playersData.UpdatePiecePosition(piece,toPos);
    }
    public Piece GetPieceData(IPlayer player, int ID){
        return GetPlayerPieceCollection()[player].Where(p => p.pieceID == ID).First<Piece>();
    }


    public bool UtilitiesIsSquareEmpty(Coordinate location){
        int index =  GetPiecesList().FindIndex(p => p.pos.x == location.x && p.pos.y == location.y);
        return index > 0 ? false : true; // if index > 0, then the square is occupied by some pieces, so if its true that Square is not empty
        // So it should return (false) because square is (not) empty
    } 
    public bool UtilitiesIsOccupiedByOpponent(Coordinate location, IPlayer requester){
        try{
            Piece piece = GetPiecesList().Where(p => p.pos.x == location.x && p.pos.y == location.y).First<Piece>();
            Console.WriteLine(piece.pieceColor.ToString() + "," + piece.piecesType.ToString() + "," + piece.pieceID.ToString());
            PlayerType playertype = (piece.pieceColor == ColorType.Black) ? PlayerType.PlayerB : PlayerType.PlayerA;
            Console.WriteLine(playertype);
            // int index =  this.playersData.GetListPiece().FindIndex(p => p.pos.x == location.x && p.pos.y == location.y);//  &&  != requester.playerType);
            return requester.playerType == playertype ? false : true;
        }catch(Exception){
            return false;
        }
    }
    public bool UtilitiesIsInsideBoard(Coordinate coordinate){
        return coordinate.x >= 1 && coordinate.x <= 8 && coordinate.y >= 1 && coordinate.y <=8;
    }
    public bool UtilitiesCanCapture(Coordinate toCoordinate, IPlayer requester){
        if(!UtilitiesIsInsideBoard(toCoordinate)){
            return false;
        }else{
            if(UtilitiesIsOccupiedByOpponent(toCoordinate,requester)){
                return true;
            }else{
                return false;
            }
        }
    }
    public bool UtilitiesCanMoveTo(Coordinate toPos){
        return UtilitiesIsSquareEmpty(toPos) && UtilitiesIsInsideBoard(toPos);
    }

}