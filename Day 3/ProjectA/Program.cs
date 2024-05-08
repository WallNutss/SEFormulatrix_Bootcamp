using System;
using System.Text;
// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

class Program{
    static void Main(){
        StringBuilder sb = new StringBuilder();

        for(int i=0;i<10;i++){
            sb.Append("Data"+ i);
        }

        string result = sb.ToString();
        Console.WriteLine(result);

        // This is error?
        // result = "Monalisa";
        // result.Dump();
    }
}