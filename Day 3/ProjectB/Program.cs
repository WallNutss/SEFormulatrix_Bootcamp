// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using Child;
using Components;
using System;

public class Program{
    static void Main(){

        // Note
        // I think we can further simply? Idk how we do it
        // Engine engineBusA = new Engine("Diesel", 4000, 2007);
        // Wheel wheelBusA = new Wheel("Offroad", 100, 2023);
        Bus busA = new Bus(1000, 10, "Diesel", 4000, 2007, "Offroad", 100, 2023);

        Engine engineSedanA = new Engine("Petrol", 1500, 2021);
        Wheel wheelSedanA = new Wheel("Urban", 60, 2022);
        Sedan sedanA = new Sedan(300, 1, engineSedanA, wheelSedanA);

        Engine engineTruckA = new Engine("Diesel", 10000, 2002);
        Wheel wheelTruckA = new Wheel("Urban", 120, 2023);
        Truck truckA = new Truck(2000, 12, engineTruckA, wheelTruckA);

        // Print the information
        // Well can it be busB?
        busA.getAttrBus();
        busA.hordSound();
        Console.WriteLine("\n===========================");
        sedanA.getAttrSedan();
        sedanA.hordSound();
        Console.WriteLine("\n===========================");
        truckA.getAttrTruck();
        truckA.hordSound();
        Console.WriteLine("\n===========================");
    }
}