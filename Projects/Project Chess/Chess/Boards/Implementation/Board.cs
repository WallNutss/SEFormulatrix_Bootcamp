namespace Chess.Boards.Implementation;

using System;
using System.Text;
using Chess.Boards.Interface;
using Chess.Enums;
using Chess.Pieces.Implementation;
using Chess.PlayerData;

/// <summary>
/// An Implementation of IBoard
/// </summary>
public class Board: IBoard{
    public int width { get; private set; }
    public int height { get; private set; }
    public List<ISquare> squares { get; set;}
    public Board(int width, int height, ref PlayerData playerData){
        this.squares = new List<ISquare>();
        this.width = width;
        this.height = height;
        InitializeCoordinate();
        SetupBoard(ref playerData);
    }
    public void SetupBoard(ref PlayerData playerData){
        int i = 1;
        // What is this? What is the key value of this function
        // even exist?
        // Maybe I can use this for initializing the pieces on the board first?
        for(int x=1;x<=8;x++){
            for(int y=1;y<=8;y++){
                if(x==1){
                    (playerData.pieces[i-1].x,playerData.pieces[i-1].y) = (x,y);
                    i++;
                }
                else if(x==2){
                    (playerData.pieces[i-1].x,playerData.pieces[i-1].y) = (x,y);
                    i++;
                }
                else if(x==7){
                    (playerData.pieces[i-1].x,playerData.pieces[i-1].y) = (x,y);
                    i++;
                }
                else if(x==8){
                    (playerData.pieces[i-1].x,playerData.pieces[i-1].y) = (x,y);
                    i++;
                }
            }
        }

    }
    public void InitializeCoordinate(){
        List<ISquare> squares  = new List<ISquare>();
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
    public void PrintEachRowBoard(List<ISquare> squares, List<Piece> pieceWithData){
        StringBuilder printRowBoard = new();
        
        //pieceWithData.ForEach(Console.WriteLine);
        for(int y=1;y<=this.width;y++){
            if(pieceWithData.Count > 0){
                foreach(var data in pieceWithData){
                    //Console.WriteLine(data);
                    if(data.y == y){
                        StringBuilder temp = new($"| {data.pieceID} ");
                        printRowBoard.Append(temp);
                        break;
                    }
                }
            }
            else{
                StringBuilder temp = new("|   ");
                printRowBoard.Append(temp);
            }
        }
        Console.WriteLine(printRowBoard.ToString()+ "|");

        // if(pieceWithData.Length < ){
        //     Console.WriteLine("Empty");
        // }else{
        //     foreach(var s in squares){
        //         StringBuilder temp = new($"| ({s.x},{s.y}) ");
        //         printRowBoard.Append(temp);
        //     }
        // }
    }
    public void PrintBoard(PlayerData playerData){
        char[] playerAChara = new char[6] {'♔', '♕', '♖', '♗', '♘', '♙'};
        char[] playerBChara = new char[6] {'♚', '♛', '♜', '♝', '♞', '♙'};
        // var squaresWithX = squares.Where(p => p.x == 0).ToList();
        //Console.WriteLine(squaresWithX);
        for (int x = 1, data=1; x <= (this.height*2)+1; x++){
            for(int y=1; y< this.width;y++){
                // Print the upper part
                if(x%2==0){
                  // Filter the points where X is 0
                    var squaresWithX = this.squares.Where(p => p.x == data).ToList();
                    var pieceWithData = playerData.pieces.Where(p => p.x == data).ToList();
                    PrintEachRowBoard(squaresWithX, pieceWithData);
                    data++;
                    break;
                }
                // Print the lower part
                else if(x%2==1){
                    Console.WriteLine("+ --- + --- + --- + --- + --- + --- + --- + --- +");
                    break;
                }
            }
        }
    }
}