using System;
using System.Globalization;
using System.Threading;

class Program{
    static void Main(){
        MainCharacter MC = new("Taiwan Calendar");
        Enemy Cimory = new();

        ConsoleProgram consoleProgram = new();

        // Game Start here, thread handle
        Thread T1 = new Thread(()=>{
            consoleProgram.ApplyAttack(MC,Cimory);
        });
        Thread T2 = new Thread(()=>{
            consoleProgram.ApplyAttack(Cimory,MC);
        });

        T1.Start();
        T2.Start();
        T1.Join();
        T2.Join();
 
    }
}

public class ConsoleProgram{
    public static readonly string keyword = "Semuanyadamaisebelumnegaraapimenyerang";
    public void ApplyAttack(ICharacter player1, ICharacter player2){
        lock(keyword){
            for(int i=0;i<player1.turn;i++){
                player1.AttackAction(player2);
                Thread.Sleep(500);
            }
        }
    }
}

class Enemy:ICharacter{
    public int characterHP{ get; set; }
    public int attack{ get; set; }
    public int turn{ get; set; }
    public string name{ get; set; }
    public Penduduk typePenduduk{ get; set; }
    public Enemy(){
        this.characterHP = 1000;
        this.turn = 10;
        this.attack = 1;
        this.name = "Goblin-A";
        this.typePenduduk = Penduduk.Goblin;
    }
    public void AttackAction(ICharacter chara){
        if(chara.characterHP>0){
            chara.characterHP -= this.attack;
            Console.WriteLine($"{this.name} has attacked {chara.name} by {this.attack}, {chara.name} has {chara.characterHP} life remaining");
        }else if(chara.characterHP < 0){
            Console.WriteLine($"Character {chara.name} has been defeated, jahat lu");
        }
    }
}

class MainCharacter:ICharacter{
    public int characterHP{ get; set; }
    public int attack{ get; set; }
    public int turn{ get; set; }
    public string name{ get; set; }
    public Penduduk typePenduduk{ get; set; }
    public MainCharacter(string name){
        this.characterHP = 400;
        this.turn = 5;
        this.name = name;
        this.attack = 20;
        this.typePenduduk = Penduduk.Slayer;
    }
    public void AttackAction(ICharacter chara){
        if(chara.characterHP>0){
            chara.characterHP -= this.attack;
            Console.WriteLine($"{this.name} has attacked {chara.name} by {this.attack}, {chara.name} has {chara.characterHP} life remaining");
        }else if(chara.characterHP < 0){
            Console.WriteLine($"Character {chara.name} has been defeated, jahat lu");
        }
    }
}


public interface ICharacter{
    int characterHP{ get; set; }
    int attack{ get; set; }
    int turn{ get; set; }
    string name{ get; set; }
    Penduduk typePenduduk{ get; set; }
    void AttackAction(ICharacter character);
}
public enum Penduduk{
    Goblin,
    Slayer,
    None
}
