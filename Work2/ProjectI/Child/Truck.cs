namespace Child;
using Parents;
using Components;

public class Truck:Vehicle
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

    public void getAttrTruck(){
        Console.WriteLine($"This Truck has {this.fuelAmmount}Liters left with capacity {this.capacity} ton");
        Console.WriteLine($"This Truck has {this.engine.engineType} engine type");
        Console.WriteLine($"This Truck has wheel with {this.wheel.wheelRadius}cm radius");
    }
}
