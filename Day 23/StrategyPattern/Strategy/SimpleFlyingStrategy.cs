using System;


public class SimpleFlyingStrategy : IFlyableStrategy{
    public void Fly(){
        Console.WriteLine("This method make flying normal!");
    }
}