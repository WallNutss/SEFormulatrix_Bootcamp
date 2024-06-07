using System;


public class NoQuackStrategy:IQuackableStrategy{
    public void Quack(){
        Console.WriteLine("There is avaiilabe Quack for this duck");
    }
}