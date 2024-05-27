using System;
using System.Text;
using System.Diagnostics;

class Program{
    static void Main(){
        StringBuilder text = new();
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        for(int i=0;i<1000;i++){
            text.Append("A");
            text.Append("B");
            text.Replace("B", "D");
        }

        stopwatch.Stop();
        Console.WriteLine($"Elapsed in {stopwatch.ElapsedMilliseconds} ms");
    }
}