
using Chess.Enums;

namespace Chess.Boards;

public class Coordinate : IPosition{
    public int x{ get;set;}
    public int y{ get; set;}
    public Coordinate(int _x, int _y){
        this.x = _x;
        this.y = _y;
    }
    public bool IsValid(){
        Console.WriteLine("Square is valid?");
        return true;
    }
    public void GetAdjacent(){
        Console.WriteLine("Get Adjacent of the Square? What is this function?");
    }

    public static Coordinate operator +(Coordinate coord1, Direction dir1){
        return new Coordinate(coord1.x + dir1.x, coord1.y + dir1.y);
    }
}
