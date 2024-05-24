using System.Runtime.CompilerServices;
using System;
using System.Diagnostics;

class Proram{
    static void Main(){
        ConsoleTraceListener consoleTraceListener = new();
        TextWriterTraceListener textWriterTraceListener = new("trace.log");
        Trace.Listeners.Add(consoleTraceListener);
        Trace.Listeners.Add(textWriterTraceListener);

        Trace.WriteLine("Start of the Program");
        Trace.Flush(); // What is this?
        AnotherProgram anotherProgram = new();
        anotherProgram.Another();
        // Trace.Flush();
    }
}

class AnotherProgram{
    public AnotherProgram(){
        Trace.WriteLine("This is another program at Constructor");
        Trace.Flush();
    }   
    public void Another(){
        Trace.WriteLine("This is another program");
        Trace.Flush();
    }
}

// class Calculator{
//     public static void Add<T>(ref T x, ref T y){
//         var result = x + y;
//         return result;
//     }
// }