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
    public PlayerData playersData;
    public IPlayer? currentPlayer;
    // Construct the prison house, default at the start game it's empty
    public Prison prison;
    public int numOfPiecesPerPlayer = 16;
    public GameStatus gameStatus {get;private set;}
    public ManualResetEvent stopSignal {get;set;}
    public GameController(){
        this._board = new Board();
        this.playersData = new PlayerData();
        this.prison = new Prison();
        this.gameStatus = GameStatus.NOT_STARTED;
        stopSignal = new ManualResetEvent(false);
        InitializeAllData();
    }

    private void InitializeAllData(){
        // Default Game Players Starters
        IPlayer player1 = new Player(1, "Player-A", PlayerType.PlayerA);
        IPlayer player2 = new Player(2, "Player-B", PlayerType.PlayerB);
        // Adding the Player to the List of Players
        AddPlayers2List(new List<IPlayer>(){player2,player1});

        // Initialize the data of pieces from _InitializePieces() to List Pieces Data from playersData
        this.playersData.SetPieceListData(SetupPiecesInitialPosition(_InitializePieces()));
        // Send the list pieces data at playersData to Dictionary according to the player
        this.playersData.SetInitialPlayersData(this.playersData.players);
    }

    private List<Piece> SetupPiecesInitialPosition(List<Piece> pieces){
        List<Piece> Pieces = pieces;
        int i = 1;
        int swapper = 8;
        for(int y=1;y<=8;y++){
            for(int x=1;x<=8;x++){
                if(y==1){
                    (pieces[i-1].pos.x,pieces[i-1].pos.y) = (x,y);
                    i++;
                }
                else if(y==2){
                    (pieces[i-1].pos.x,pieces[i-1].pos.y) = (x,y);
                    i++;
                }
                else if(y==7){
                    (pieces[i+swapper-1].pos.x,pieces[i+swapper-1].pos.y) = (x,y);
                    i++;
                }
                else if(y==8){
                    (pieces[i-swapper-1].pos.x,pieces[i-swapper-1].pos.y) = (x,y);
                    i++;
                }
            }
        }
        return Pieces;
    }
    private List<Piece> _InitializePieces(){
        List<Piece> pieces = new();
        for(int p=1;p<3;p++){
            ColorType pieceColor = p==1 ? ColorType.Black : ColorType.White;
            for(int i=1;i<=numOfPiecesPerPlayer;i++){
                IPosition position = new Coordinate(0,0);   
                if(i==1 || i==8){
                    pieces.Add(new Rook(i,pieceColor,position));
                }
                else if(i==2 || i==7){
                    pieces.Add(new Knight(i,pieceColor, position));
                }
                else if(i==3 || i==6){
                    pieces.Add(new Bishop(i,pieceColor, position));
                }
                else if(i==4){
                    pieces.Add(new King(i,pieceColor,position));
                }
                else if(i==5){
                    pieces.Add(new Queen(i,pieceColor,position));
                }
                else{
                    pieces.Add(new Pawn(i, pieceColor,position));
                }
            }
        }
        return pieces;
    }
    private void AddPlayers2List(List<IPlayer> players){
        this.playersData.SetPlayer(players);
    }
    
    public void PreGameStart(){
        PreGameStartView views = new("Pre Game");
        views.Invoke();
        // _board.PrintBoard(this.playersData.GetPlayersData());
        // User choose player
        InputHelper.InputPlayers().ForEach((IPlayer player)=> SetUserNamePlayer(player));
        PlayerListView view = new(this.playersData.players);
        view.Invoke();        
    }

    public void StartGame(){
        //MovePiece(this.currentPlayer);
        this.currentPlayer = this.playersData.GetPlayer().Where(p => p.playerType == PlayerType.PlayerA).First<IPlayer>(); // White always start first
        var printBoardTask = Task.Run(()=>RefreshBoardAsync(stopSignal));
        // _board.PrintBoard(this.playersData.GetPlayersData());
        Console.Clear();
        while(this.gameStatus == GameStatus.GAME_START){

            Console.SetCursorPosition(0, 17);
            Console.WriteLine($"{currentPlayer.name}'s turn");

            // Demo just try move something
            bool isValidMove = false;
            while(!isValidMove){
                Console.SetCursorPosition(0, 18);
                Console.WriteLine("Enter the ID pieces you want to move (e.g., 1):");
                Console.SetCursorPosition(0, 19);
                var idRe = GetUserInput();
                int idRead = Convert.ToInt32(idRe);

                // Try to calculate the possible Moves
                // Piece currentPiece = this.playersData.GetPieceData(idRead, this.currentPlayer);
                // PossibbleMoves(currentPiece) // Console this output
                
                Console.SetCursorPosition(0, 20);
                Console.WriteLine("Enter your move (e.g., 2,4):");
                Console.SetCursorPosition(0, 21);
                var moveString = GetUserInput();
                Coordinate move = ConvertStringToIntArrayCoordinate(moveString);

                
                MovePiece(this.currentPlayer, move, idRead);
                isValidMove = true;
            }
            SwitchPlayerTurn(this.currentPlayer);
            
        }
        this.stopSignal.Set();
        printBoardTask.Wait();
        Console.WriteLine("Game over!");
        
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
        _board.PrintBoard(this.playersData.GetPlayersData());
        await Task.Delay(500);
        }
    }
    public void MovePiece(IPlayer player, Coordinate toPos, int pieceID){
        Piece piece = playersData.GetPieceData(pieceID,player);
        playersData.UpdatePiecePosition(piece, toPos);
    }
    public void MakeTurn(){}

    // GameController - Player Function
    public void SwitchPlayerTurn(IPlayer player){
        if(player.playerType == PlayerType.PlayerA){
            this.currentPlayer =  this.playersData.GetPlayer().Where(p => p.playerType != PlayerType.PlayerA).First<IPlayer>();
        }
        else if(player.playerType == PlayerType.PlayerB){
            this.currentPlayer =  this.playersData.GetPlayer().Where(p => p.playerType != PlayerType.PlayerB).First<IPlayer>();
        }
    }

    public void PlayerTurn(){}
    public void PossibleMoves(IPlayer player, Piece piece){
        // return the possible move based on those criteria
        // piece.PieceType? return directions
        // Possible move based on those direction ? Return list of Coordinate it can takee
        Direction one = Direction.moveDirection[DirectionMoveType.North];
    }
    public void Occupancy(){}
    public void SetUserNamePlayer(IPlayer player){
        this.playersData.players.Where(p => p.playerType == player.playerType).First<IPlayer>().SetName(player.name);
    }
    public IPlayer GetPlayer(IPlayer player){
        return this.playersData.players.Where(p => p.playerID == player.playerID).First<IPlayer>();
    }

    // GameController -  Game State
    public GameStatus GetGameStatus(){
        return this.gameStatus;
    }
    public void SetGameStatus(GameStatus status){
        Console.WriteLine($"Game has been change into {status}");
        this.gameStatus = status;
    }

    public bool UtilitiesIsSquareEmpty(Coordinate location){
        int index =  this.playersData.GetListPiece().FindIndex(p => p.pos.x == location.x && p.pos.y == location.y);
        return index > 0 ? false : true; // if index > 0, then the square is occupied by some pieces, so if its true that Square is not empty
        // So it should return (false) because square is (not) empty
    } 
    public bool UtilitiesIsOccupiedByOpponent(Coordinate location, IPlayer requester){
        try{
            Piece piece = this.playersData.GetListPiece().Where(p => p.pos.x == location.x && p.pos.y == location.y).First<Piece>();
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