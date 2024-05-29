using System.Text;
using Chess.Boards.Interface;
using Chess.Enums;
namespace Chess.Boards.Implementation;

public class Board: List<ISquare>, IBoard{
    public int width { get; private set; }
    public int height { get; private set; }
    public List<ISquare> squares  = new List<ISquare>();
    public Board(int width, int height){
        this.width = width;
        this.height = height;
        SetupBoard();
        InitializeCoordinate();
    }
    public void SetupBoard(){
        // What is this? What is the key value of this function
        // even exist?
        // Maybe I can use this for initializing the pieces on the board first?

    }
    public void InitializeCoordinate(){
        for (int x = 0; x < this.width; x++){
            for (int y = 0; y < this.height; y++){
                if((x+y)%2==0){
                    this.squares.Add(new Square(_x:x, _y:y,color:ColorType.White));
                }
                else if((x+y)%2!=0){
                    this.squares.Add(new Square(_x:x, _y:y,color:ColorType.Black));
                }
            }
        }
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
    public void PrintBoard(){
        // var squaresWithX = squares.Where(p => p.x == 0).ToList();
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
                    var squaresWithX = squares.Where(p => p.x == data).ToList();
                    PrintEachRowBoard(squaresWithX);
                    data++;
                    break;
                }
            }
        }
    }

}
