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
using Chess.GameControl.GameMechanism;
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
    public CheckmateManager checkmateManager;
    public GameController(){
        board = new Board();
        _playersData = new PlayersData();
        prison = new Prison();
        gameStatus = GameStatus.NOT_STARTED;
        checkmateManager = new CheckmateManager();
        stopSignal = new ManualResetEvent(false);
    }

    // GameController -  Game State
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
    public GameStatus GetGameStatus(){
        return gameStatus;
    }
    public void SetGameStatus(GameStatus status){
        // Console.WriteLine($"Game has been change into {status}");
        gameStatus = status;
    }

    // Function helper for making it easir, like IO System, Input Console Handler, and 
    // 
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
    // GameController - Player Function
    public IPlayer GetPlayer(PlayerType playerType){
        return _playersData.GetAllPlayerFromPlayersList().Where(p => p.playerType == playerType).First<IPlayer>();
    }
    public void SwitchPlayerTurn(IPlayer player){
        if(player.playerType == PlayerType.PlayerA){
            currentPlayer =  GetPlayer(PlayerType.PlayerB);
        }
        else if(player.playerType == PlayerType.PlayerB){
            currentPlayer =  GetPlayer(PlayerType.PlayerA);
        }
    }
    public IPlayer SwapPlayer(IPlayer player){
        if(player.playerType == PlayerType.PlayerA){
            return GetPlayer(PlayerType.PlayerB);
        }
        else if(player.playerType == PlayerType.PlayerB){
            return GetPlayer(PlayerType.PlayerA);
        }
        else{
            return null;
        }
    }
    public IPlayer GetCurrentPlayer(){
        return currentPlayer;
    }
    public IPlayer GetCurrentOpponentPlayer(){
        return currentPlayer.playerType switch{
            PlayerType.PlayerA => GetPlayer(PlayerType.PlayerB),
            PlayerType.PlayerB => GetPlayer(PlayerType.PlayerA),
            _ => null!
        };
    }
    public void SetUserNamePlayer(IPlayer player){
        GetPlayersFromList().Where(p => p.playerType == player.playerType).First<IPlayer>().SetName(player.name);
    }


    // GameController - Pieces Function
    public void MovePiece(Piece piece, Coordinate toPos){
        UpdatePiecePosition(piece, toPos);
    }
    public IEnumerable<Move> GetPossibleMoves(IPlayer player, int pieceID){
        // return the possible move based on those criteria
        Piece currentPiece = GetPieceData(player,pieceID);
        return currentPiece.GetMoves(currentPiece.pos, this);
    }
    public bool IsThisValidPossibleMove(IEnumerable<Move> moves, Coordinate choice){
        return moves.Any(p => p.ToPos.x == choice.x && p.ToPos.y == choice.y);
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
    public void CheckmateManagerSytemAssesor(){
        // Check is the opponnet king is in check?
        if (!checkmateManager.UtilitiesIsItCheck(this)){
            Console.WriteLine($"Not a Checkmate for {GetCurrentOpponentPlayer().name}");
            return;
        }

        // If statements above get continued, then it is true that the opponent player is in check because current player action then
        // Also get the source of the check
        Coordinate sourceCoordinateMakeKingCheck = checkmateManager.UtilitiesGetCheckCausingMoves(this);
        if (!checkmateManager.UtilitiesDoesKingHavePossibleMove(this) && sourceCoordinateMakeKingCheck == null){
            Console.WriteLine($"This is still not a checkmate {GetCurrentOpponentPlayer().name}, please move your king while you can");
            return;
        }

        // Get the piece responsible for the check
        Piece pieceResponsible = GetPieceDataFromLocation(sourceCoordinateMakeKingCheck);

        // Check if the king has possible moves
        if (checkmateManager.UtilitiesDoesKingHavePossibleMove(this)){
            Console.WriteLine($"This is still not a checkmate {GetCurrentOpponentPlayer().name}, please move your king while you can");
            return;
        }

        // Check if any piece can block the check
        if (checkmateManager.UtilitiesCanOpponentPlayerPiecesMoveToKingDangerSquares(this, pieceResponsible)){
            Console.WriteLine($"{GetCurrentOpponentPlayer().name} king is in check and cannot move other than moving your own pieces to block the check!");
            List<Piece> piecesToBlockCheck = checkmateManager.UtilitiesGetOwnPiecesToBlockCheck(this, pieceResponsible);
            // Move these pieces
            foreach(var piece in piecesToBlockCheck){
                Console.WriteLine($"Piece to block -- Piece : {piece.piecesType}, ID : {piece.pieceID} from ({piece.pos.x},{piece.pos.y})");
            }
            return;
        }
        // Check if any piece can remove the threat
        if (checkmateManager.UtilitiesCanOpponentPlayerPieceRemoveThePieceResponsible(this, pieceResponsible)){
            Console.WriteLine($"{GetCurrentOpponentPlayer().name} king is in check and cannot move other than moving your own pieces to remove the threat!");
            List<Piece> piecesToRemoveThreat = checkmateManager.UtilitiesGetOpponentPlayerPiecesToRemoveThePieceResponsible(this, pieceResponsible);
            // Move these pieces
            foreach(var piece in piecesToRemoveThreat){
                Console.WriteLine($"Piece to remove the threat -- Piece : {piece.piecesType}, ID : {piece.pieceID} from ({piece.pos.x},{piece.pos.y}");
            }
            return;
        }

        // And if all of those above condition still failed, then there is only one conclusion
        // If no pieces can block or remove the threat, it's checkmate
        Console.WriteLine($"{GetCurrentOpponentPlayer().name}, it's a checkmate!");
    }

    public IEnumerable<Move> UtilitiesGetMovesNotInCoordinates(IEnumerable<Move> moves, List<Coordinate> coordinates){
        // Filter moves whose ToPos is not in the given list of coordinates
        var result = moves.Where(move => !coordinates.Contains(move.ToPos)).ToList();
        return result;
    }

    public IEnumerable<Coordinate> UtilitiesKingPossibleCheckStatus(IPlayer player){
        return checkmateManager.UtilitiesGetKingDangerSquares(player, this);
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
    public void AddPieceToPrison(Piece capturedPiece){
        prison.AddPiece(capturedPiece);
        RemovePieceFromData(capturedPiece);
    }
    public List<Piece> GetListPieceFromPrison(){
        return prison.GetCapturedPieces();
    }

    // Piece Functionality
    public void PieceCapture(Piece capturingPiece, Piece capturedPiece){
        MovePiece(capturingPiece, capturedPiece.pos);
        AddPieceToPrison(capturedPiece);
    }
}