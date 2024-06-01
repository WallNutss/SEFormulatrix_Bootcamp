using System;
using Chess.Pieces;
using Chess.Enums;
using Chess.Boards;
using Chess.Players;
using System.Dynamic;

namespace Chess.PlayerDatas;

public class PlayerData{
    public Dictionary<IPlayer, List<Piece>> playersData;
    public List<Piece> pieces {get;set;}
    public List<IPlayer> players;
    public int numOfPiecesPerPlayer;
    public PlayerData(){
        this.numOfPiecesPerPlayer = 16;
        this.players = new List<IPlayer>();
        this.playersData = new Dictionary<IPlayer, List<Piece>>();
        this.pieces = new List<Piece>();
    }

    // Method for rw the Dictionary
    public Dictionary<IPlayer, List<Piece>> GetPlayersData(){
        return playersData;
    }
    // Update Piece Position
    public void UpdatePiecePosition(IPlayer player, int pieceID, Coordinate newCoordinate){
        if(this.playersData.TryGetValue(player, out var pieces)){
             var Piece = pieces.FirstOrDefault(p => p.pieceID == pieceID);
             if (Piece != null){
                Piece.pos.x = newCoordinate.x;
                Piece.pos.y = newCoordinate.y;
                Console.WriteLine($"Piece {Piece.pieceID} for player {player.name} has been moved to ({newCoordinate.x}, {newCoordinate.y}).");
                UpdateListPiecesFromDict();
            }
            else{
            Console.WriteLine($"Piece not found for player {AddColor.Message(player.name.ToString(), ConsoleColor.Green)}.");
            }
        }
    }
    
    public void SetInitialPlayersData(List<IPlayer> players){
        foreach(IPlayer player in players){
            if(player.playerType == PlayerType.PlayerB){
                List<Piece> piecesBlack = this.pieces.Where(p => p.pieceColor == ColorType.Black).ToList();
                this.playersData.Add(player, piecesBlack);  
            }else if(player.playerType == PlayerType.PlayerA){
                List<Piece> piecesWhite = this.pieces.Where(p => p.pieceColor == ColorType.White).ToList();
                this.playersData.Add(player, piecesWhite);  
            }
        }
    }

    // Method rw for the Piece data from List of Pieces
    public List<Piece> GetPieceData(Player playerType){
        return this.playersData[playerType].ToList();
    }
    public Piece GetPieceData(int ID, Player playerType){
        return this.playersData[playerType].Where(p => p.pieceID == ID).First<Piece>();
    }
    public List<Piece> GetListPiece(){
        return this.pieces;
    }
    public void SetPieceData(List<Piece> pieces){
        this.pieces = pieces;
    }
    public void UpdateListPiecesFromDict(){ // Method on hold, what is the purpose?
        SetPieceData(this.playersData.Values.SelectMany(pieces => pieces).ToList());
        //SetPlayersData(this.pieces);
    }

    // method for rw of the player information
    public void SetPlayer(List<IPlayer> players){
        this.players = players;
    }
    public List<IPlayer> GetPlayer(){
        return this.players;
    }
}