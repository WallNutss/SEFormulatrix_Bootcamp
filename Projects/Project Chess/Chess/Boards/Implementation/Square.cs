using Chess.Boards;
using Chess.Enums;
namespace Chess.Boards;

public class Square : ICoordinate{
    public int x{ get; set; }
    public int y{ get; set; }
    public ColorType color { get; set; }
    public Square(int _x, int _y, ColorType color){
        this.x = _x;
        this.y = _y;
        this.color = color;
    }
    public bool IsValid(){
        Console.WriteLine("Square is valid?");
        return true;
    }
    public void GetAdjacent(){
        Console.WriteLine("Get Adjacent of the Square? What is this function?");
    }

}
