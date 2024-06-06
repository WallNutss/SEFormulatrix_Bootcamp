using System;
using Chess.Pieces;
using Chess.Enums;
using Chess.Boards;
using Chess.Players;

namespace Chess.PlayerDatas;

public class PlayersData{
    private List<IPlayer> _players;
    private Dictionary<IPlayer, List<Piece>> _playersPieceData;
    public int numOfPiecesPerPlayer;
    public PlayersData(){
        numOfPiecesPerPlayer = 16;
        _players = new List<IPlayer>();
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
        List<Piece> pieces = _SetupPiecesInitialPosition(_InitializePieces());
        
        _SetInitialPlayersData(pieces);
    }

    private List<Piece> _InitializePieces(){
        List<Piece> pieces = new();
        for(int p=1;p<3;p++){
            ColorType pieceColor = p==1 ? ColorType.Black : ColorType.White;
            for(int i=1;i<=numOfPiecesPerPlayer;i++){
                Coordinate position = new Coordinate(0,0);   
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

    private void _SetInitialPlayersData(List<Piece> pieces){
        foreach(IPlayer player in GetAllPlayerFromPlayersList()){
            if(player.playerType == PlayerType.PlayerB){
                List<Piece> piecesBlack = pieces.Where(p => p.pieceColor == ColorType.Black).ToList();
                AddPlayerPieceCollectionData(player, piecesBlack);  
            }else if(player.playerType == PlayerType.PlayerA){
                List<Piece> piecesWhite = pieces.Where(p => p.pieceColor == ColorType.White).ToList();
                AddPlayerPieceCollectionData(player, piecesWhite);  
            }
        }
    }

    private List<Piece> _SetupPiecesInitialPosition(List<Piece> pieces){
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
        return pieces;
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