namespace Parents;
// This is the parent class
// As we know, there are some similarity with
// Vehicle, that is they need fuel, they have
// Capacity, and they can apply brakes, but
// vehicle can have different engine and 
// different wheel types, sooo
public class Vehicle
{
    public int fuelAmmount;
    public float capacity;

    public void applyBrakes(){
        Console.WriteLine("Applying brakes!");
    }

    public virtual void hordSound(){
        Console.WriteLine("Tin Tin!");
    }
}
