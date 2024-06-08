
using Chess.Enums;

namespace Chess.Boards;

public class Coordinate : IPosition{
    public int x{ get;set;}
    public int y{ get; set;}
    public Coordinate(int _x, int _y){
        x = _x;
        y = _y;
    }
    public bool IsValid(){
        Console.WriteLine("Square is valid?");
        return true;
    }
    public void GetAdjacent(){
        Console.WriteLine("Get Adjacent of the Square? What is this function?");
    }

    public override bool Equals(object obj){
        if (obj is Coordinate other){
            return x == other.x && y == other.y;
        }
        return false;
    }

    public override int GetHashCode(){
        return HashCode.Combine(x, y);
    }

    public static bool operator ==(Coordinate left, Coordinate right){
        return EqualityComparer<Coordinate>.Default.Equals(left,right);
    }
    public static bool operator !=(Coordinate left, Coordinate right){
        return !(left == right);
    }

    public static Coordinate operator +(Coordinate coord1, Direction dir1){
        return new Coordinate(coord1.x + dir1.x, coord1.y + dir1.y);
    }
}
