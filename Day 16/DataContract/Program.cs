using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.DataContracts;
using System.Runtime.Serialization.Json;

[DataContract]
class Player{
    [DataMember]
    private string _name;
    [DataMember]
    private int _money;
    [DataMember]
    public int Gold{get;set;}
    [DataMember]
    public int exp{get;set;}

    // public int Gold {get;private set;} bedanya ini
    // private int _Gold {get; set;} sama ini apa ya?
    public Player(string name, int money, int gold, int exp){
        this._name = name;
        this._money = money;
        this.Gold = gold;
        this.exp = exp;
    }
}

class Program{
    static void Main(string[] args){
        Player juan = new("Juan", 2000,300, 10000);
        Player redo = new("Redo", 4000,50, 1500);
        Player jason = new("Jason", 1000,600, 5000);

        List<Player> players = new List<Player>(){juan, redo, jason};

        DataContractJsonSerializer serializer = new(typeof(List<Player>));
        using(FileStream fileStream = new("player.json", FileMode.Create)){
            serializer.WriteObject(fileStream,players);
        }
    }
}