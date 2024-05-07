// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");
using System;

namespace quadcopter{
class Program{
    static void Main(){
        // Hey this is mine
        Quadcopter AJ204 = new Quadcopter("Tarry", 12, 2);
        Console.WriteLine(AJ204.estimateFlightTime());
        Console.WriteLine(AJ204.getManufacturer());

        // name, mikrokontroller, battery, destinedPlanPathLength
        Quadcopter Karry = new Quadcopter("Karry","Flighhawk", 98, 3, true);
        Console.WriteLine(Karry.estimateFlightTime());
        Quadcopter Musk = new Quadcopter("Musk","ArduPilot", 67, 5, true);
        Console.WriteLine(Musk.estimateFlightTime());
        Console.WriteLine(Musk.getManufacturer());
    }
}

// Adding a new class! It's a cat Quadcopter
class Quadcopter{
    // 
    public string name;
    public string microcontroller;
    float gravity = 9.81f;
    public int battery;
    bool controller;
    int longpath;

    // Constructor of the class
    public Quadcopter(String name, String microcontroller, int battery, int longpath, bool controller){
        this.name = name;
        this.microcontroller = microcontroller;
        this.battery = battery;
        this.longpath = longpath * this.battery;
        this.controller = controller;
    }
    // Constructor, in case we don't know its manufacturer or its personal make
    public Quadcopter(String name, int battery, int longpath){
        this.name = name;
        this.battery = battery;
        this.longpath = longpath * this.battery;
    }
    // Method or what you can do
    public void takeOff(){
        Console.WriteLine($"{name} Take off! Move out");
    }
    public void Land(){
        Console.WriteLine("Landing, ground control!");
    }
    public void Move(){
        Console.WriteLine("I'M FLYINGGG!!!");
    }
    public float getGravity(){
        return this.gravity;
    }
    public int getBattery(){
        return this.battery;
    }
    public String getManufacturer(){
        if(this.microcontroller == null){
            return "There is no manufacturere stated in this Quadcopter";
        }else{
            return this.microcontroller;
        }
    }
    public bool isControl(){
        if(this.controller){
            return this.controller;
        }else{
            return false;
        }
    }
    public int estimateFlightTime(){
        return this.longpath;
    }
}

}