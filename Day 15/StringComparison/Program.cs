using System;
using System.Diagnostics;

class Program{
    static void Main(){
        string text = String.Empty;
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        for(int i=0;i<1000;i++){
            text += "A";
            text += "B";
            text = text.Replace("A","C");
        }

        stopwatch.Stop();
        Console.WriteLine($"Elapsed in {stopwatch.ElapsedMilliseconds} ms");
    }
}