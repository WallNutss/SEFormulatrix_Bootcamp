// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using System;
using TaskFoobar;


// 3 foo
// 5 bar
// User input => n

// n = 15
// 0, 1, 2, foo, 4, bar, foo, 7, 8, foo, bar, 11, foo, 13, 14, foobar



class Program{
    private static int input = 0;
    private static bool state = true;
    
    static void Main(){
        while(state){
            try{
                Console.WriteLine("Foobar Task");
                Console.WriteLine("Enter a loop number: ");
                input = int.Parse(Console.ReadLine()); // Read user input
                state = false;
            }catch(FormatException e){
                Console.WriteLine("Hey you suppose to input a number!");
                Console.WriteLine($"{e}\n");
            }
        }

        Foobar.Task(input);
    }
}