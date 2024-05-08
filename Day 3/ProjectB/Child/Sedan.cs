namespace Child;
using Parents;
using Components;

public class Sedan:Vehicle, Isound, IFlash
{
    public Engine engine;
    public Wheel wheel;
    // Start inherit and first define
    public Sedan(int fuelAmmount, int capacity, Engine engine, Wheel wheel)
    :base()
    {
        this.fuelAmmount = fuelAmmount;
        this.capacity = capacity;
        this.engine = engine;
        this.wheel = wheel;
    }

    public void HornSound(){
        Console.WriteLine("Tom Tom!");
    }
    public void Flash(){
        Console.WriteLine("Sedan : Flashbang!!!");
    }
    public override void applyWiper(){
        Console.Write("Wiper Sedan On!!");
    }
    public void getAttrSedan(){
        Console.WriteLine($"This Sedan has {this.fuelAmmount} Liters left with capacity {this.capacity} ton");
        Console.WriteLine($"This Sedan has {this.engine.engineType} engine type");
        Console.WriteLine($"This Sedan has wheel with {this.wheel.wheelRadius}cm radius");
    }
}
