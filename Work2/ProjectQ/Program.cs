// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using System;
using Quadcopter;

class Program{
    // Start of the simulation
    static void Main(){
        // Console write information first
        Motor motorA = new Motor("SUN", 2018, 1200, 100);
        Model quadcopterA = new Model("Parrot", 2019, 2023, 4, 10 ,motorA);
        quadcopterA.getAttr();
        motorA.getAttr();

        Console.WriteLine("\nStart the simulation");
        // Run simulation, just run 5 loops
        for(int i=1; i<=5; i++){
            Console.WriteLine(quadcopterA.calculateVelocity()); 
            Console.WriteLine("========================");
        }
    }
}