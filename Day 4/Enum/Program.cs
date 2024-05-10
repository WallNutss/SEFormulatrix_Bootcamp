// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using Enum;


public class Program(){
    static void Main(){
        //DaysOfWeek today = DaysOfWeek.Tuesday;
        //Console.WriteLine(today);
        IntCalculator clc = new();
        int a = clc.Add(1,2,3,4,5);
        Console.WriteLine(a);

        var sclc = new StringCalculator();
        int b = sclc.Add("1","2","3","4","5");
        Console.WriteLine(b);

        var printc = new CustomPrintParams();
        object w = printc.Print("1", "Lotus", "Premiere", 4);
    }
}
