using System;


public class Card:ICard{
    public string CardName {get;private set;}
    public int CardID {get;}
    public Card(string name, int ID){
        CardName = name;
        CardID = ID;
    }
    public void GetInfo(){
        Console.WriteLine($"Card name: {CardName}");
        Console.WriteLine($"Card id: {CardID}");
    }

}