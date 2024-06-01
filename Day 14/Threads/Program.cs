using System;
using System.Threading;

class Program{
    //public delegate void UserHasInput(int ID);
    static void Main(){
        // SimpleThreadExample simpleThreadExample = new();
        // simpleThreadExample.StartMultipleThread();

        // Console Animtion Program that waiting 
        ConsoleProgram consoleProgram = new();
        //UserHasInput userHasInput = consoleProgram.StoreData;

        Thread t1 = new(consoleProgram.ConsoleProgramAnimation);
        Thread t2 = new(consoleProgram.ConsoleProgramFibbonaciCalculation);

        
        t1.IsBackground = true;
        t1.Priority = ThreadPriority.Highest;

        t1.Start();
        t2.Start();
        t1.Join();
    }
}

public class ConsoleProgram{
    public void ConsoleProgramAnimation(){
        string[] loadingFrames = {"|", "/", "-", "\\"};
        int currentFrame = 0;
        for (int i = 0; i < 100; i++)
        {
            Console.SetCursorPosition(0,4);
            Console.Write($"\rCalculating: {loadingFrames[currentFrame]}");
            currentFrame = (currentFrame + 1) % loadingFrames.Length;
            Thread.Sleep(100);
        }
        Console.Clear();
        Console.WriteLine("Calculation Done!");
    }
    // public void ConsoleProgramInput(){
    //     Console.WriteLine("Input ID: ");
    //     int input = Int32.Parse(Console.ReadLine());
    //     int result = input;
    // }
    public void ConsoleProgramFibbonaciCalculation(){
        int a = 0;
        int b = 1;
        List <int> results = new List<int>();
        results.Add(a);
        results.Add(b);

        for(int i=0;i<20;i++){
            int temp = results[results.Count -1] + results[results.Count -2];
            results.Add(temp);
            string s = String.Join(", ", results);
            Console.WriteLine($"\r{s}");
            //Console.WriteLine($"\rWaiting in t1, loops: {i}, tid {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(500);
            Console.Clear();
        }
    }
}

public class SimpleThreadExample{
    public void StartMultipleThread(){
        Thread t1 = new Thread(()=>{
            int numberOfSecondsElapsed = 0;
            while(numberOfSecondsElapsed<5){
                Thread.Sleep(1000); //ms
                Console.WriteLine($"Waiting in t1, loops: {numberOfSecondsElapsed}, tid {Thread.CurrentThread.ManagedThreadId}");
                numberOfSecondsElapsed++;
            }
            Console.WriteLine("I Ran for 5 Seconds");
        });

        Thread t2 = new Thread(()=>{
            int numberOfSecondsElapsed = 0;
            while(numberOfSecondsElapsed<8){
                Thread.Sleep(1000); //ms
                Console.WriteLine($"Waiting in t2, loops: {numberOfSecondsElapsed}, tid {Thread.CurrentThread.ManagedThreadId}");
                numberOfSecondsElapsed++;
            }
            Console.WriteLine("I Ran for 8 Seconds");
        });   

        Thread t3 = new Thread(()=>{
            int numberOfSecondsElapsed = 0;
            while(numberOfSecondsElapsed<10){
                Thread.Sleep(1000); //ms
                Console.WriteLine($"Waiting in t3, loops: {numberOfSecondsElapsed}, tid {Thread.CurrentThread.ManagedThreadId}");
                numberOfSecondsElapsed++;
            }
            Console.WriteLine("I Ran for 10 Seconds");
        });      

        t1.Start();
        t2.Start();
        t3.Start();

        //t1.Join();
    }
}