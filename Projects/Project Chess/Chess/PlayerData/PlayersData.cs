using System;
using Chess.Pieces;
using Chess.Enums;
using Chess.Boards;
using Chess.Players;
using Chess.PiecesFactory;

namespace Chess.PlayerDatas;

public class PlayersData{
    private List<IPlayer> _players;
    private PieceFactory _pieceFactory;
    private Dictionary<IPlayer, List<Piece>> _playersPieceData;
    public int numOfPiecesPerPlayer;
    private static readonly Dictionary<PlayerType, ColorType> _playerPieceColor = new(){
        {PlayerType.PlayerA, ColorType.White},          
        {PlayerType.PlayerB, ColorType.Black},          
    };

    public PlayersData(){
        numOfPiecesPerPlayer = 16;
        _players = new List<IPlayer>();
        _pieceFactory = new PieceFactory();
        _playersPieceData = new Dictionary<IPlayer, List<Piece>>();
        InitializeData();
    }
    // Set Initial data
    private void InitializeData(){
        // Default Game Players Starters
        IPlayer player1 = new Player(1, "Player-A", PlayerType.PlayerA);
        IPlayer player2 = new Player(2, "Player-B", PlayerType.PlayerB);

        // Adding the Player to the List of Players
        SetPlayersListData(new List<IPlayer>(){player2,player1});
        _InitializePieces();
    }

    private void _InitializePieces(){
        foreach(IPlayer player in _players){
            List<Piece> pieces = _pieceFactory.MakePieces(_playerPieceColor[player.playerType]);
            AddPlayerPieceCollectionData(player, pieces);
        }   
    }

    // Method read and write for the _player list
    private void SetPlayersListData(List<IPlayer> players){ // I'm just using this for the initial data
        _players = players;
    }
    public void AddPlayerToPlayersList(IPlayer player){
        _players.Add(player);
    }
    public List<IPlayer> GetAllPlayerFromPlayersList(){
        return _players;
    }


    // Method for read and write the _pieces list data
    public List<Piece> GetPiecesListData(){
        return GetPlayerPieceCollectionData().Values.SelectMany(pieces => pieces).ToList();
    }


    // Method for read and write the dictionary collection player to Pieces data
    public void AddPlayerPieceCollectionData(IPlayer player, List<Piece> data){
        _playersPieceData.Add(player, data);
    }
    public Dictionary<IPlayer,List<Piece>> GetPlayerPieceCollectionData(){
        return _playersPieceData;
    }
    public void UpdatePiecePosition(Piece piece, Coordinate newCoordinate){
        if (piece != null){
            piece.pos.x = newCoordinate.x;
            piece.pos.y = newCoordinate.y;
            Console.WriteLine($"Piece {piece.pieceID} has been moved to ({newCoordinate.x}, {newCoordinate.y}).");
        }
        else{
            Console.WriteLine($"Piece not found.");
        }
    }
    public void RemovePiece(Piece piecToRemove){
        foreach(var player in _playersPieceData){
            if(player.Value.Remove(piecToRemove)){
                Console.WriteLine("Piece has been remove from the data!");
            }
        }
        Console.WriteLine("Finish.");

    }
}

































//     public void SetPlayersData(List<IPlayer> players){
//         foreach(IPlayer player in players){
//             if(player.playerType == PlayerType.PlayerB){
//                 List<Piece> piecesBlack = this.pieces.Where(p => p.pieceColor == ColorType.Black).ToList();
//                 this.playersData.Add(player, piecesBlack);  
//             }else if(player.playerType == PlayerType.PlayerA){
//                 List<Piece> piecesWhite = this.pieces.Where(p => p.pieceColor == ColorType.White).ToList();
//                 this.playersData.Add(player, piecesWhite);  
//             }
//         }
//     }

//     // Method for rw the Dictionary
//     public Dictionary<IPlayer, List<Piece>> GetPlayersData(){
//         return playersData;
//     }
//     public void SetPlayersData(Dictionary<IPlayer, List<Piece>> data){
//         this.playersData = data;
//     }

//     // Update Piece Position
//     public void UpdatePiecePosition(Piece piece, Coordinate newCoordinate){
//         if (piece != null){
//             piece.pos.x = newCoordinate.x;
//             piece.pos.y = newCoordinate.y;
//             Console.WriteLine($"Piece {piece.pieceID} has been moved to ({newCoordinate.x}, {newCoordinate.y}).");
//             UpdateListPiecesFromDict();
//         }
//         else{
//             Console.WriteLine($"Piece not found.");
//         }
//     }

//     // Method rw for the Piece data from List of Pieces
//     public List<Piece> GetPieceData(IPlayer playerType){
//         return this.playersData[playerType].ToList();
//     }
//     public Piece GetPieceData(int ID, IPlayer playerType){
//         return this.playersData[playerType].Where(p => p.pieceID == ID).First<Piece>();
//     }
//     public Piece GetPieceData(Coordinate position){
//         return this.playersData.Values.SelectMany(pieces => pieces).ToList().Where(p => p.pos.x == position.x && p.pos.y == position.y).First<Piece>();
//     }

//     // Method rw for List of Pieces
//     public List<Piece> GetListPiece(){
//         return this.pieces;
//     }
//     public void SetPieceListData(List<Piece> pieces){
//         this.pieces = pieces;
//     }
//     public void UpdateListPiecesFromDict(){ // Method on hold, what is the purpose?
//         SetPieceListData(this.playersData.Values.SelectMany(pieces => pieces).ToList());
//         //SetPlayersData(this.pieces);
//     }

//     // method for rw of the player information
//     public void SetPlayer(List<IPlayer> players){
//         this.players = players;
//     }
//     public List<IPlayer> GetPlayer(){
//         return this.players;
//     }
// }