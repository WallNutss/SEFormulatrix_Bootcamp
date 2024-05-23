namespace Child;
using Parents;
using Components;

public class Bus:Vehicle, Isound, IFlash, IDoor
{
    public Engine engine;
    public Wheel wheel;
    // Start inherit and first define
    public Bus(int fuelAmmount, int capacity, string engineType, 
               int enginePower, int engineBuilt, string wheelType,
               int wheelRadius, int wheelBuild
               )
    :base() 
    {
        this.fuelAmmount = fuelAmmount;
        this.capacity = capacity;
        this.engine = new Engine("Diesel", 4000, 2007);
        this.wheel = new Wheel("Offroad", 100, 2023);
    }
    public void HornSound(){
        Console.WriteLine("Telolet!");
    }
    public void Flash(){
        Console.WriteLine("Bus: Flashbang!!!");
    }
    public void Door(){
        Console.WriteLine("Bus: With the power of magic, Open Sesame!");
    }
    public override void applyWiper(){
        Console.Write("Wiper Bus On!!");
    }
    // public override void Wiper(){ // use override access 
    //     Console.Writeline("Wiper Fast Srutttt!");
    // }
    public void getAttrBus(){
        Console.WriteLine($"This bus has {this.fuelAmmount} Liters left with capacity {this.capacity} ton");
        Console.WriteLine($"This bus has {this.engine.engineType} engine type");
        Console.WriteLine($"This bus has wheel with {this.wheel.wheelRadius}cm radius");
    }
}
