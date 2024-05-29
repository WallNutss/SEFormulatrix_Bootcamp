using Chess.Boards.Interface;
using Chess.Enums;
namespace Chess.Boards.Implementation;

public class Square : ISquare{
    public int x{ get; set; }
    public int y{ get; set; }
    public ColorType color { get; set; }
    public Square(int _x, int _y, ColorType color){
        this.x = _x;
        this.y = _y;
        this.color = color;
    }
    public void IsValid(){
        Console.WriteLine("Square is valid?");
    }
    public void GetAdjacent(){
        Console.WriteLine("Get Adjacent of the Square? What is this function?");
    }

}
