namespace Child;
using Parents;
using Components;

public class Bus:Vehicle
{
    public Engine engine;
    public Wheel wheel;
    // Start inherit and first define
    public Bus(int fuelAmmount, int capacity, Engine engine, Wheel wheel)
    :base()
    {
        this.fuelAmmount = fuelAmmount;
        this.capacity = capacity;
        this.engine = engine;
        this.wheel = wheel;
    }

    public void getAttrBus(){
        Console.WriteLine($"This bus has {this.fuelAmmount}Liters left with capacity {this.capacity} ton");
        Console.WriteLine($"This bus has {this.engine.engineType} engine type");
        Console.WriteLine($"This bus has wheel with {this.wheel.wheelRadius}cm radius");
    }
}
