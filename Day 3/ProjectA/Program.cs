using System;
using System.Text;
// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");


class Program{
    static void Main(){
        // StringBuilder sb = new StringBuilder();

        // for(int i=0;i<10;i++){
        //     sb.Append("Data"+ i);
        // }

        // string result = sb.ToString();
        // Console.WriteLine(result);

        // This is error?
        // result = "Monalisa";
        // result.Dump();

        //Animal.MakeSound();
        var parents = new Animal();
        var child = new Child();
        parents.MakeSound();
        child.MakeSound();
    }
}


public class Animal{
    public virtual void MakeSound(){
        Console.WriteLine("Sound A");
    }
}

public class Child:Animal{
    public override void MakeSound()
    {
        Console.WriteLine("Sound B");
    }
}