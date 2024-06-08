using System;
using System.Threading;
using Chess.Boards;
using Chess.PlayerDatas;
using Chess.Players;
using Chess.Enums;
using Chess.Pieces;
using Chess.Views;
using Chess.GameControl.Helper;
using Chess.Prisons;
using System.IO.Compression;

namespace Chess.GameControl;


public class GameController{
    // Inisialization of all the model in the game
    public Board board {get;}
    private PlayersData _playersData;
    public IPlayer currentPlayer = null!;
    // Construct the prison house, default at the start game it's empty
    public Prison prison;
    public int numOfPiecesPerPlayer = 16;
    public GameStatus gameStatus {get;private set;}
    public ManualResetEvent stopSignal {get;set;}
    public GameController(){
        board = new Board();
        _playersData = new PlayersData();
        prison = new Prison();
        gameStatus = GameStatus.NOT_STARTED;
        stopSignal = new ManualResetEvent(false);
    }

    public void PreGameStart(){
        SetGameStatus(GameStatus.NOT_STARTED);
        InputHelper.InputPlayers().ForEach((IPlayer player)=> SetUserNamePlayer(player));
        PlayerListView PlayerListView = new();
        PlayerListView.Invoke(GetPlayersFromList());        
    }

    public void StartGame(){
        currentPlayer = GetPlayersFromList().Where(p => p.playerType == PlayerType.PlayerA).First<IPlayer>(); // White always start first
        SetGameStatus(GameStatus.GAME_START);
    }
   
    public void StopGame(){
        SetGameStatus(GameStatus.GAME_FINISHED);
    }
    public static Coordinate ConvertStringToIntArrayCoordinate(string input)
    {
        int[] xy = input.Split(',').Select(int.Parse).ToArray();
        return new Coordinate(xy[0],xy[1]);
    }

    public static string GetUserInput(string message){
            Console.WriteLine(message);
            return Console.ReadLine() ?? string.Empty;
    }
    public async Task RefreshBoardAsync(ManualResetEvent stopSignal){
        while (!stopSignal.WaitOne(0)){
        // Console.WriteLine("Run");
        board.PrintBoard(GetPlayerPieceCollection());
        await Task.Delay(500);
        }
    }

    public void MovePiece(IPlayer player, Coordinate toPos, int pieceID){
        Piece piece = GetPieceData(player,pieceID);
        UpdatePiecePosition(piece, toPos);
    }
    
    // GameController - Player Function
    public void SwitchPlayerTurn(IPlayer player){
        if(player.playerType == PlayerType.PlayerA){
            currentPlayer =  GetPlayersFromList().Where(p => p.playerType != PlayerType.PlayerA).First<IPlayer>();
        }
        else if(player.playerType == PlayerType.PlayerB){
            currentPlayer =  GetPlayersFromList().Where(p => p.playerType != PlayerType.PlayerB).First<IPlayer>();
        }
    }
    public IEnumerable<Move> GetPossibleMoves(IPlayer player, int pieceID){
        // return the possible move based on those criteria
        Piece currentPiece = GetPieceData(player,pieceID);
        return currentPiece.GetMoves(currentPiece.pos, this);
        // piece.PieceType? return directions
        //  var PossibeMovesPossible move based on those direction ? Return list of Coordinate it can takee
        
    }
    public bool IsThisValidPossibleMove(IEnumerable<Move> moves, Coordinate choice){
        return moves.Any(p => p.ToPos.x == choice.x && p.ToPos.y == choice.y);
    }
    
    public void SetUserNamePlayer(IPlayer player){
        GetPlayersFromList().Where(p => p.playerType == player.playerType).First<IPlayer>().SetName(player.name);
    }

    public IPlayer GetPlayer(IPlayer player){
        return _playersData.GetAllPlayerFromPlayersList().Where(p => p.playerID == player.playerID).First<IPlayer>();
    }
    public IPlayer GetPlayer(PlayerType playerType){
        return _playersData.GetAllPlayerFromPlayersList().Where(p => p.playerType == playerType).First<IPlayer>();
    }

    // GameController -  Game State
    public GameStatus GetGameStatus(){
        return gameStatus;
    }
    public void SetGameStatus(GameStatus status){
        // Console.WriteLine($"Game has been change into {status}");
        gameStatus = status;
    }
    public IPlayer GetCurrentPlayer(){
        return currentPlayer;
    }
    public IPlayer GetCurrentOpponentPlayer(IPlayer current){
        return current.playerType switch{
            PlayerType.PlayerA => GetPlayer(PlayerType.PlayerB),
            PlayerType.PlayerB => GetPlayer(PlayerType.PlayerA),
            _ => null!
        };
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
    public Piece GetPieceDataFromLocation(Coordinate location){
        return GetPiecesList().Where(p => p.pos.x == location.x && p.pos.y == location.y).First<Piece>();
    }
    public void RemovePieceFromData(Piece piece){
        _playersData.RemovePiece(piece);
    }

    /** THIS IS UTILITIES FOR BOARD STATE CHECKING EXCLUSING FOR KING**/
    // This is for general status check, will iterate each king in each player side
    public IEnumerable<Coordinate> UtilitiesKingCheckGeneralStatus(){
        foreach (var player in GetPlayersFromList()){
            foreach (var coordinate in UtilitiesKingCheckStatus(player)){
                yield return coordinate;
            }
        }
    }

    // This is for checking if one side of player requesting check status on its own side
    public IEnumerable<Coordinate> UtilitiesKingCheckStatus(IPlayer currentInCheck){
        Piece currentInCheckKing = GetPieceData(currentInCheck, 4);
        IPlayer opponentPlayer = GetCurrentOpponentPlayer(currentInCheck);
        foreach(Piece piece in GetPlayerPieceCollection()[opponentPlayer]){
            IEnumerable<Move> eachPieceCurrentPossibleMove = piece.GetMoves(piece.pos, this);
            foreach(var mov in eachPieceCurrentPossibleMove){
                if(mov.ToPos.x == currentInCheckKing.pos.x && mov.ToPos.y == currentInCheckKing.pos.y){
                    Console.WriteLine($"{currentInCheck.name} King is in Check!");
                    yield return mov.ToPos;
                }
            }
        }

    }

    // This is for checking if king possible move will chain another check status
    public List<Coordinate> UtilitiesKingPossibleCheckStatus(IPlayer currentInCheck){
        Piece currentInCheckKing = GetPieceData(currentInCheck, 4);
        IPlayer opponentPlayer = GetCurrentOpponentPlayer(currentInCheck);
        IEnumerable<Move> kingPossibleMoves = currentInCheckKing.GetMoves(currentInCheckKing.pos, this);
        List<Coordinate> kingInDangerMoves = new List<Coordinate>();
        foreach(var kingmove in kingPossibleMoves){
            foreach(Piece piece in GetPlayerPieceCollection()[opponentPlayer]){
                IEnumerable<Move> eachPieceCurrentPossibleMove = piece.GetMoves(piece.pos, this);
                foreach(var mov in eachPieceCurrentPossibleMove){
                    if(mov.ToPos.x == kingmove.ToPos.x && mov.ToPos.y == kingmove.ToPos.y){
                        // Console.WriteLine($"{currentInCheck.name} King if move to ({kingmove.ToPos.x},{kingmove.ToPos.y})possible move will result in Check!");
                        // yield return kingmove.ToPos;
                        kingInDangerMoves.Add(kingmove.ToPos);
                    }
                }
            }
        }
        return kingInDangerMoves;
    }
    public bool UtilitiesCheckCheckmateStatus(IEnumerable<Move> kingMoves, List<Coordinate> kingMoveCheck){
        List<Coordinate> kingMovesList =  new List<Coordinate>();
        foreach(var km in kingMoves){
            kingMovesList.Add(km.ToPos);
        }

        return kingMovesList.SequenceEqual(kingMoveCheck);

    }

    /** THIS IS UTILITIES FOR BOARD STATE CHECKING**/
    public bool UtilitiesIsSquareEmpty(Coordinate location){
        int index =  GetPiecesList().FindIndex(p => p.pos.x == location.x && p.pos.y == location.y);
        return index > 0 ? false : true; // if index > 0, then the square is occupied by some pieces, so if its true that Square is not empty
        // So it should return (false) because square is (not) empty
    } 
    public bool UtilitiesIsOccupiedByOpponent(Coordinate location, Piece pieceRequester){
        try{
            Piece pieceAtLocation = GetPiecesList().Where(p => p.pos.x == location.x && p.pos.y == location.y).First<Piece>();
            // Console.WriteLine(pieceAtLocation.pieceColor.ToString() + "," + pieceAtLocation.piecesType.ToString() + "," + pieceAtLocation.pieceID.ToString());
            // PlayerType playertype = (piece.pieceColor == ColorType.Black) ? PlayerType.PlayerB : PlayerType.PlayerA;
            // Console.WriteLine(playertype);
            // int index =  this.playersData.GetListPiece().FindIndex(p => p.pos.x == location.x && p.pos.y == location.y);//  &&  != requester.playerType);
            return pieceRequester.pieceColor != pieceAtLocation.pieceColor ? true : false;
        }catch(Exception){
            return false;
        }
    }
    public bool UtilitiesIsInsideBoard(Coordinate coordinate){
        return coordinate.x >= 1 && coordinate.x <= 8 && coordinate.y >= 1 && coordinate.y <=8;
    }
    public bool UtilitiesCanCapture(Coordinate toCoordinate, Piece requester){
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
    public bool UtiliesAreThereNoPossibleMoves(IEnumerable<Move> moves){
        return !moves.Any();
    }
    public bool UtilitiesCanMoveTo(Coordinate toPos){
        return UtilitiesIsSquareEmpty(toPos) && UtilitiesIsInsideBoard(toPos);
    }

    // Prison
    public void AddPiece2Prison(Piece pieceTaken){
        prison.AddPiece(pieceTaken);
    }
    public List<Piece> GetPiecesFromPrison(){
        return prison.GetCapturedPieces();
    }

}