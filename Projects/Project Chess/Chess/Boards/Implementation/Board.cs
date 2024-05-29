namespace Chess.Boards.Implementation;
using System.Text;
using Chess.Boards.Interface;
using Chess.Enums;
using Chess.PlayerData;

/// <summary>
/// An Implementation of IBoard
/// </summary>
public class Board: IBoard{
    public int width { get; private set; }
    public int height { get; private set; }
    public List<ISquare> squares { get; set;}
    public Board(int width, int height){
        this.squares = new List<ISquare>();
        this.width = width;
        this.height = height;
        InitializeCoordinate();
        SetupBoard();
    }
    public void SetupBoard(){
        // What is this? What is the key value of this function
        // even exist?
        // Maybe I can use this for initializing the pieces on the board first?

    }
    public void InitializeCoordinate(){
        List<ISquare> squares  = new List<ISquare>();
        for (int x = 0; x < this.width; x++){
            for (int y = 0; y < this.height; y++){
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
    public void PrintEachRowBoard(List<ISquare> squares){
        StringBuilder printRowBoard = new();
        foreach(var s in squares){
            StringBuilder temp = new($"| ({s.x},{s.y}) ");
            printRowBoard.Append(temp);
        }
        Console.WriteLine(printRowBoard.ToString()+ "|");
    }
    public void PrintBoard(PlayerData playerData){
        char[] playerAChara = new char[7] {'a', 'b', 'c', 'd', 'e', 'f','g'};
        char[] playerBChara = new char[7] {'a', 'b', 'c', 'd', 'e', 'f','g'};
        //Console.WriteLine(squaresWithX);
        for (int x = 0, data=0; x < (this.height*2)+1; x++){
            for(int y=0; y< this.width;y++){
                // Print the upper part
                if(x%2==0){
                    Console.WriteLine("+ --- + --- + --- + --- + --- + --- + --- + --- +");
                    break;
                }
                // Print the lower part, the data
                else if(x%2==1){
                    // Filter the points where X is 0
                    var squaresWithX = this.squares.Where(p => p.x == data).ToList();
                    PrintEachRowBoard(squaresWithX);
                    data++;
                    break;
                }
            }
        }
    }

}
