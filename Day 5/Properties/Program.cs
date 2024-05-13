// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");


class Human{
    public int Balance {get; private set;}
    public void SetBalance(int balance){
        Balance = balance;
    }
}

class Program{
    static void Main(){
        Human human = new();
        try{
            human.Balance = 4000;
        }catch(Exception e){
            Console.WriteLine(e);
            human.SetBalance(3000);
        }
        Console.WriteLine(human.Balance);
    }
}
