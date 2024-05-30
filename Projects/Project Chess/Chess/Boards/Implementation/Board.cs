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
    public List<ICoordinate> squares { get; set;}
    public Board(ref PlayerData playerData){
        this.squares = new List<ICoordinate>();
        this.width = 8;
        this.height = 8;
        InitializeCoordinate();
        SetupBoard(ref playerData);
    }
    public void SetupBoard(ref PlayerData playerData){
        int i = 1;
        int swapper = 8;
        // What is this? What is the key value of this function
        // even exist?
        // Maybe I can use this for initializing the pieces on the board first?
        for(int x=1;x<=8;x++){
            for(int y=1;y<=8;y++){
                if(x==1){
                    (playerData.pieces[i-1].Properties.x,playerData.pieces[i-1].Properties.y) = (x,y);
                    i++;
                }
                else if(x==2){
                    (playerData.pieces[i-1].Properties.x,playerData.pieces[i-1].Properties.y) = (x,y);
                    i++;
                }
                else if(x==7){
                    (playerData.pieces[i+swapper-1].Properties.x,playerData.pieces[i+swapper-1].Properties.y) = (x,y);
                    i++;
                }
                else if(x==8){
                    (playerData.pieces[i-swapper-1].Properties.x,playerData.pieces[i-swapper-1].Properties.y) = (x,y);
                    i++;
                }
            }
        }

    }
    public void InitializeCoordinate(){
        List<ICoordinate> squares  = new List<ICoordinate>();
        for (int x = 1; x <= this.width; x++){
            for (int y = 1; y <= this.height; y++){
                if((x+y)%2==0){
                    squares.Add(new Square(_x:x, _y:y,color:ColorType.White));
                }
                else if((x+y)%2!=0){
                    squares.Add(new Square(_x:x, _y:y,color:ColorType.Black));
                }
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
    public void PrintEachRowBoard(List<Piece> pieceWithData, int x){

        string[] playerAChara = new string[6] {"KB", "QB", "RB", "BB", "HB", "PB"};
        string[] playerBChara = new string[6] {"KW", "QW", "RW", "BW", "HW", "PW"};
        StringBuilder printRowBoard = new();
        for(int y=1;y<=this.width;y++){
            int index =  pieceWithData.FindIndex(p => p.Properties.y == y);
            if(index==-1){
                StringBuilder temp = new("|    ");
                printRowBoard.Append(temp);
            }else{
                string pieceChoose = PlayerType.PlayerA == pieceWithData[index].playerType? playerAChara[(int)pieceWithData[index].piecesType].ToString() : playerBChara[(int)pieceWithData[index].piecesType].ToString();
                StringBuilder temp = new($"| {pieceChoose} ");
                printRowBoard.Append(temp);
            }
        }
        Console.WriteLine($"{x}  "+printRowBoard.ToString()+ "|");
    }
    public void PrintBoard(PlayerData playerData){
        // var squaresWithX = squares.Where(p => p.x == 0).ToList();
        //Console.WriteLine(squaresWithX);
        for (int x = 1, data=1; x <= (this.height*2)+1; x++){
            // Print the upper part
            if(x%2==0){
                // Filter the points where X is 0
                List<Piece> pieceWithData = playerData.pieces.Where(p => p.Properties.x == data).ToList();
                PrintEachRowBoard(pieceWithData,data);
                data++; // This is to check each row that printable on
            }
            // Print the lower part
            else if(x%2==1){
                Console.WriteLine("   + -- + -- + -- + -- + -- + -- + -- + -- +");
            }
        }
    }
}