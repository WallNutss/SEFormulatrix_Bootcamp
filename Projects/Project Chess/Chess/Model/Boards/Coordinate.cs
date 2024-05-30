
using Chess.Enums;

namespace Chess.Boards;

public class Coordinate : IPosition{
    public int x{ get;set;}
    public int y{ get; set;}
    public Coordinate(int _x, int _y){
        this.x = _x;
        this.y = _y;
    }

    public ColorType GetSquare(){
        if((x+y)%2==0){
            return ColorType.White;
        }
        else{
            return ColorType.Black;
        }
    }
    public bool IsValid(){
        Console.WriteLine("Square is valid?");
        return true;
    }
    public void GetAdjacent(){
        Console.WriteLine("Get Adjacent of the Square? What is this function?");
    }

}
