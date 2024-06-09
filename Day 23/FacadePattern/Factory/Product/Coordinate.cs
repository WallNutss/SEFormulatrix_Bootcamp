using System;

public class Coordinate : IPosition{
    public int X{get;set;}
    public int Y{get;set;}
    public Coordinate(int x, int y){
        X = x;
        Y = y;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(X,Y);
    }
}