using System;
using System.Globalization;
using System.Threading;

class Program{
    static void Main(){
        Random random = new();
        MainCharacter MC = new("Taiwan Calendar", random.Next(100));
        Enemy Evil = new("Goblin-A", random.Next(10));

        ConsoleProgram consoleProgram = new();

        // Game Start here, thread handle
        Thread T1 = new Thread(()=>{
            consoleProgram.ApplyAttack(MC,Evil);
        });
        Thread T2 = new Thread(()=>{
            consoleProgram.ApplyAttack(Evil,MC);
        });


        try{
            T1.Start();
            T2.Start();
            T1.Join();
            T2.Join();
        }catch(Exception e){
            Console.WriteLine(e);
        }
 
    }
}

public class ConsoleProgram{
    public static readonly string keyword = "Semuanyadamaisebelumnegaraapimenyerang";
    public void ApplyAttack(ICharacter player1, ICharacter player2){
        //lock(keyword){
            for(int i=0;i<player1.turn;i++){
                player1.AttackAction(player2);
                Thread.Sleep(500);
            }
        //}
    }
}

class Enemy:ICharacter{
    public int characterHP{ get; set; }
    public int attack{ get; set; }
    public int turn{ get; set; }
    public string name{ get; set; }
    public Penduduk typePenduduk{ get; set; }
    public Enemy(string name, int attackValue){
        this.characterHP = 1000;
        this.turn = 100;
        this.attack = attackValue;
        this.name = name;
        this.typePenduduk = Penduduk.Goblin;
    }
    public void AttackAction(ICharacter chara){
        if(chara.characterHP>0){
            chara.characterHP -= this.attack;
            Console.WriteLine($"{this.name} has attacked {chara.name} by {this.attack}, {chara.name} has {chara.characterHP} life remaining");
        }else if(chara.characterHP < 0){
            Thread.CurrentThread.Interrupt();
            Console.WriteLine($"Character {chara.name} has been defeated by {this.name}");
        }
    }
}

class MainCharacter:ICharacter{
    public int characterHP{ get; set; }
    public int attack{ get; set; }
    public int turn{ get; set; }
    public string name{ get; set; }
    public Penduduk typePenduduk{ get; set; }
    public MainCharacter(string name, int attackValue){
        this.characterHP = 400;
        this.turn = 100;
        this.name = name;
        this.attack = attackValue;
        this.typePenduduk = Penduduk.Slayer;
    }
    public void AttackAction(ICharacter chara){
        if(chara.characterHP>0){
            chara.characterHP -= this.attack;
            Console.WriteLine($"{this.name} has attacked {chara.name} by {this.attack}, {chara.name} has {chara.characterHP} life remaining");
        }else if(chara.characterHP < 0){
            Thread.CurrentThread.Interrupt();
            Console.WriteLine($"Character {chara.name} has been defeated by {this.name}");
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
