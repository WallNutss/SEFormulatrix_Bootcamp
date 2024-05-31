using System;
using Chess.Boards;
using Chess.PlayerDatas;
using Chess.Players;
using Chess.Enums;
using Chess.Pieces;

namespace Chess.GameController;


public class GameController{
    // Inisialization of all the model in the game
    private Board _board {get;}
    public PlayerData playersData;
    public List<IPlayer> players;
    public int numOfPiecesPerPlayer = 16;
    public GameController(){
        this._board = new Board();
        this.players = new List<IPlayer>();
        this.playersData = new PlayerData();

        InitializeAllData();
    }

    public void InitializeAllData(){
        // Default Game Players Starters
        IPlayer player1 = new Player(2, "Player-B", PlayerType.PlayerB);
        IPlayer player2 = new Player(1, "Player-A", PlayerType.PlayerA);
        // Adding the Player to the List of Players
        AddPlayers2List(new List<IPlayer>(){player1,player2});

        // Initialize the data of pieces from _InitializePieces() to List Pieces Data from playersData
        this.playersData.SetPieceData(SetupPiecesInitialPosition(_InitializePieces()));
        // Send the list pieces data at playersData to Dictionary according to the player
        this.playersData.SetInitialPlayersData(this.players);
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
    internal void AddPlayers2List(List<IPlayer> players){
        this.players = players;
    }
    

    public void PreGameStart(){
        _board.PrintBoard(this.playersData.GetPlayersData());
    }
    public void StartGame(){}
    public void StopGame(){}
    public void EndTurn(){}
    public void GetPlayerData(){}
    public void GetAllPlayerData(){}
    public void PlayerTurn(){}
    public void PossibleMoves(){}
    public void Occupancy(){}

}