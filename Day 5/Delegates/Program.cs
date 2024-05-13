// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using System.Reflection;
public delegate int MyDelegate(int x);

class Saturate{
    public static int Print(int x){
        // Console.WriteLine($"Hai! {word}");
        return (x + x);
    }
    public static int Mush(int x){
        // Console.WriteLine($"Kumbala Mush {word}!");
        return (x * x);
    }
}

class Program{
    static void Main(){
        MyDelegate roar = new MyDelegate(Saturate.Print);

        Console.WriteLine("Before adding mush method");
        roar += Saturate.Mush;
        Console.WriteLine("After adding mush method");

        int result = roar(5);
        //result.Dump();

        Delegate[] dels = roar.GetInvocationList();

        // Accessing each return
        foreach(Delegate dg in dels){
            Console.WriteLine(dg.GetMethodInfo().Name + ": " +
            ((MyDelegate)dg).Invoke(5));
        }
    }
}