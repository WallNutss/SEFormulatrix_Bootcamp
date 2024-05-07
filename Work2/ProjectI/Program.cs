// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using Child;
using Components;
using System;

public class Program{
    static void Main(){

        // Note
        // I think we can further simply? Idk how we do it
        Engine engineBusA = new Engine("Diesel", 2000, 2021);
        Wheel wheelBusA = new Wheel("Offroad", 60, 2023);
        Bus busA = new Bus(1000, 6, engineBusA, wheelBusA);

        Engine engineSedanA = new Engine("Petrol", 2000, 2021);
        Wheel wheelSedanA = new Wheel("Urban", 60, 2023);
        Sedan sedanA = new Sedan(1000, 6, engineSedanA, wheelSedanA);

        Engine engineTruckA = new Engine("Diesel", 2000, 2021);
        Wheel wheelTruckA = new Wheel("Urban", 60, 2023);
        Truck truckA = new Truck(1000, 6, engineTruckA, wheelTruckA);

        // Print the information
        // Well can it be busB?
        busA.getAttrBus();
        sedanA.getAttrSedan();
        truckA.getAttrTruck();
    }
}