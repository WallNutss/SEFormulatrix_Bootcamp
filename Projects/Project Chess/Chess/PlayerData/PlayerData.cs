using System;
using Chess.Pieces;
using Chess.Enums;
using Chess.Boards;
using Chess.Players;

namespace Chess.PlayerDatas;

public class PlayerData{
    public Dictionary<IPlayer, List<Piece>> playersData;
    public List<Piece> pieces {get;set;}
    public int numOfPiecesPerPlayer;
    public PlayerData(){
        this.numOfPiecesPerPlayer = 16;
        this.playersData = new Dictionary<IPlayer, List<Piece>>();
        this.pieces = new List<Piece>();
    }

    public Dictionary<IPlayer, List<Piece>> GetPlayersData(){
        return playersData;
    }
    public void SetInitialPlayersData(List<IPlayer> players){
        foreach(IPlayer player in players){
            if(player.playerType == PlayerType.PlayerB){
                List<Piece> piecesBlack = this.pieces.Where(p => p.pieceColor == ColorType.Black).ToList();
                this.playersData.Add(player, piecesBlack);  
            }else{
                List<Piece> piecesWhite = this.pieces.Where(p => p.pieceColor == ColorType.White).ToList();
                this.playersData.Add(player, piecesWhite);  
            }
        }
    }

    public List<Piece> GetPieceData(Player playerType){
        return this.playersData[playerType].ToList();
    }
    public Piece GetPieceData(int ID, Player playerType){
        return this.playersData[playerType].Where(p => p.pieceID == ID).First<Piece>();
    }
    public void SetPieceData(List<Piece> pieces){
        this.pieces = pieces;
    }
 // public void InitializePieces2Players(List<IPlayer> players){
    //    ColorType colorType = ColorType.Black; 
    //     foreach(IPlayer player in players){
    //         if(colorType == ColorType.Black){
    //             List<Piece> piecesBlack = this.pieces.Where(p => p.pieceColor == colorType).ToList();
    //             this.playersData.Add(player, piecesBlack);  
    //         }else{
    //             List<Piece> piecesWhite = this.pieces.Where(p => p.pieceColor == colorType).ToList();
    //             this.playersData.Add(player, piecesWhite);  
    //         }
    //     }
    // }
}

//     public bool IsEmpty(Coordinate location){
//         int index =  this.pieces.FindIndex(p => p.pos.x == location.x && p.pos.y == location.y);
//         return index > 0 ? false : true;
//     }

//     public bool IsOccupiedByOpponent(Coordinate location, IPlayer requester){
//         int index =  this.pieces.FindIndex(p => p.pos.x == location.x && p.pos.y == location.y && p.playerType != requester.playerType);
//         return index > 0 ? false : true;
//     }
    
//     public Piece GetPieceAt(Coordinate location){
//         Piece piece = this.pieces.Where(p => p.pos.y == location.y).First<Piece>();
//         return piece;
//     }
// }
