namespace Child;
using Parents;
using Components;

public class Truck:Vehicle, Isound, IFlash
{
    public Engine engine;
    public Wheel wheel;
    // Start inherit and first define
    public Truck(int fuelAmmount, int capacity, Engine engine, Wheel wheel)
    :base()
    {
        this.fuelAmmount = fuelAmmount;
        this.capacity = capacity;
        this.engine = engine;
        this.wheel = wheel;
    }
    public override void applyWiper(){
        Console.Write("Wiper truck On!!");
    }
    public void Flash(){
        Console.WriteLine("Truck : Flashbang!!!");
    }
    public void HornSound(){
        Console.WriteLine("Ton Ton!");
    }
    public void getAttrTruck(){
        Console.WriteLine($"This Truck has {this.fuelAmmount} Liters left with capacity {this.capacity} ton");
        Console.WriteLine($"This Truck has {this.engine.engineType} engine type");
        Console.WriteLine($"This Truck has wheel with {this.wheel.wheelRadius}cm radius");
    }
}
