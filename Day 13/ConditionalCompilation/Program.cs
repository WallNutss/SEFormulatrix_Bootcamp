using System;

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
    }
}