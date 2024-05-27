using System;
using System.Diagnostics;


// For example, all class will be empty
// Will be example cooking breakfast
class Noodles{}
class Coffee{}
class Egg{}

class Program{
    static void Main(){
        int choice = 1;


        if(choice == 1){
            Stopwatch stopwatch = new();
            stopwatch.Start();
            Thread thread = new(() => PourCoffee());
            Console.WriteLine("Coffee has been served!");

            Thread thread2 = new(() => CookNoodles(2));
            Console.WriteLine("Noodles has been coocked!");

            // Egg egg = FryEgg(3);
            Thread thread3 = new(() => FryEgg(4));
            Console.WriteLine("Egg has been fried");


            stopwatch.Stop();
            Console.WriteLine($"Total program duration : {stopwatch.ElapsedMilliseconds}ms");
            thread.Start();
            thread2.Start();
            thread3.Start();
        }else{
            Stopwatch stopwatch = new();
            stopwatch.Start();
            PourCoffee();
            Console.WriteLine("Coffee has been served!");

            CookNoodles(2);
            Console.WriteLine("Noodles has been coocked!");

            FryEgg(3);
            Console.WriteLine("Egg has been fried");

            stopwatch.Stop();
            Console.WriteLine($"Total program duration : {stopwatch.ElapsedMilliseconds}ms");
        }
        
    }

    public static void PourCoffee(){
        Console.WriteLine("Pouring cofee to cup!");
        // return new Coffee();
    }

    public static void CookNoodles(int indomie){
        Console.WriteLine($"{indomie} noodles goes to wok!");
        // return new Noodles();
    }

    public static void FryEgg(int eg){
        Console.WriteLine($"Ongoing work fry {eg}!");
        // return new Egg();
    }
}