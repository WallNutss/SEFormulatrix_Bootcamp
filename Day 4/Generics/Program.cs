// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

// General Swapper
using Generics;

public class Program{

    static void Main(){
        // General Integer Swapper
        Console.WriteLine("General Integer Swapper");
        Console.WriteLine("Before Swap");
        int a = 4;
        int b = 2;
        Console.WriteLine($"a: {a}");
        Console.WriteLine($"b: {b}");

        Swapper.Swap<int>(ref a, ref b);
        Console.WriteLine("After Swap");
        Console.WriteLine($"a: {a}");
        Console.WriteLine($"b: {b}");
        Console.WriteLine("================\n");

        // General Double Swapper
        Console.WriteLine("General Double Swapper");
        Console.WriteLine("Before Swap");
        double c = 400;
        double d = 200;
        Console.WriteLine($"c: {c}");
        Console.WriteLine($"d: {d}");

        Swapper.Swap<double>(ref c, ref d);
        Console.WriteLine("After Swap");
        Console.WriteLine($"c: {c}");
        Console.WriteLine($"d: {d}");
        Console.WriteLine("================\n");

        // General String Swapper
        Console.WriteLine("General String Swapper");
        Console.WriteLine("Before Swap");
        string e = "Master";
        string f = "Welcome";
        Console.WriteLine($"e: {e}");
        Console.WriteLine($"f: {f}");

        Swapper.Swap<string>(ref e, ref f);
        Console.WriteLine("After Swap");
        Console.WriteLine($"e: {e}");
        Console.WriteLine($"f: {f}");
        Console.WriteLine("================\n");

        // General Object Swapper
        Console.WriteLine("General Object Swapper");
        Console.WriteLine("Before Swap");
        object g = 45;
        object h = 11;
        Console.WriteLine($"g: {g}");
        Console.WriteLine($"h: {h}");

        Swapper.Swap<object>(ref g, ref h);
        Console.WriteLine("After Swap");
        Console.WriteLine($"g: {g}");
        Console.WriteLine($"h: {h}");
        Console.WriteLine("================\n");
    }
}
