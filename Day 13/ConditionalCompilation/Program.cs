using System;
using Conditional;

class Program{
    static void Main(){
        #if DEBUG
            Console.WriteLine("DEBUG");
        #endif
        #if RELEASE
            Console.WriteLine("RELEASE");
        #endif
        #if DEVELOPMENT
            Console.WriteLine("DEVELOPMENT");
        #endif
        #if DEVELOPMENT_USING
            Using usedd = new();
            usedd.Using2();
            Console.WriteLine("DEVELOPMENT_USING");
        #endif
        #if DEVELOPMENT_TRYCATCH
            TryCatch trre = new();
            trre.Try2();
            Console.WriteLine("DEVELOPMENT_TRYCATCH");
        #endif
    }
}