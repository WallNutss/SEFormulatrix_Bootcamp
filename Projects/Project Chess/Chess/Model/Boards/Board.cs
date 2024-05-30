namespace Chess.Boards;

using System;
using System.Text;

using Chess.Enums;
using Chess.Pieces;
using Chess.PlayerData;

/// <summary>
/// An Implementation of IBoard
/// </summary>
public class Board: IBoard{
    public int width { get; private set; }
    public int height { get; private set; }
    public List<IPosition> squares { get; set;}
    public Board(ref PlayerData playerData){
        this.squares = new List<IPosition>();
        this.width = 8;
        this.height = 8;
        InitializeCoordinate();
        SetupBoard(ref playerData);
    }
    public void SetupBoard(ref PlayerData playerData){
        int i = 1;
        int swapper = 8;
        for(int y=1;y<=8;y++){
            for(int x=1;x<=8;x++){
                if(y==1){
                    (playerData.pieces[i-1].pos.x,playerData.pieces[i-1].pos.y) = (x,y);
                    i++;
                }
                else if(y==2){
                    (playerData.pieces[i-1].pos.x,playerData.pieces[i-1].pos.y) = (x,y);
                    i++;
                }
                else if(y==7){
                    (playerData.pieces[i+swapper-1].pos.x,playerData.pieces[i+swapper-1].pos.y) = (x,y);
                    i++;
                }
                else if(y==8){
                    (playerData.pieces[i-swapper-1].pos.x,playerData.pieces[i-swapper-1].pos.y) = (x,y);
                    i++;
                }
            }
        }
    }
    public void InitializeCoordinate(){
        List<IPosition> squares  = new List<IPosition>();
        for (int x = 1; x <= this.width; x++){
            for (int y = 1; y <= this.height; y++){
                squares.Add(new Square(_x:x, _y:y));
            }
        }
        this.squares = squares;
        
    }

    public void MovePiece(){

    }
    public void GetPieceAt(){
        
    }

    public void IsOccupied(){

    }
    public void IsOccupiedByOpponent(){

    }
    public void PrintEachRowBoard(List<Piece> pieceWithData, int X){

        string[] playerAChara = new string[6] {"KW", "QW", "RW", "BW", "HW", "PW"};
        string[] playerBChara = new string[6] {"KB", "QB", "RB", "BB", "HB", "PB"};
        StringBuilder printRowBoard = new();
        for(int x=1;x<=this.width;x++){
            int index =  pieceWithData.FindIndex(p => p.pos.x == x);
            if(index==-1){
                StringBuilder temp = new("|    ");
                printRowBoard.Append(temp);
            }else{
                string pieceChoose = PlayerType.PlayerA == pieceWithData[index].playerType? playerAChara[(int)pieceWithData[index].piecesType].ToString() : playerBChara[(int)pieceWithData[index].piecesType].ToString();
                StringBuilder temp = new($"| {pieceChoose} ");
                printRowBoard.Append(temp);
            }
        }
        Console.WriteLine($"{X}  "+printRowBoard.ToString()+ "|");
    }
    public void PrintBoard(PlayerData playerData){
        // var squaresWithX = squares.Where(p => p.x == 0).ToList();
        //Console.WriteLine(squaresWithX);
        // Console.WriteLine("   + -- + -- + -- + -- + -- + -- + -- + -- +");
        Console.WriteLine("      1    2    3    4    5    6    7    8");
        for (int y = 1, data=1; y <= (this.height*2)+1; y++){
            // Print the upper part
            if(y%2==0){
                // Filter the points where X is 0
                List<Piece> pieceWithData = playerData.pieces.Where(p => p.pos.y == data).ToList();
                PrintEachRowBoard(pieceWithData,data);
                data++; // This is to check each row that printable on
            }
            // Print the lower part
            else if(y%2==1){
                Console.WriteLine("   + -- + -- + -- + -- + -- + -- + -- + -- +");
            }
        }
    }
}