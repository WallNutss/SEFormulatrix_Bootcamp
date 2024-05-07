namespace Components;

public class Wheel
{
    public string wheelType;
    public int wheelRadius;
    public int wheelBuild;

    // Start constructor here for predifiend
    public Wheel(string wheelType,int wheelRadius,int wheelBuild){
        this.wheelType = wheelType;
        this.wheelRadius = wheelRadius;
        this.wheelBuild = wheelBuild;
    }
    // Here we can have a method to get it information too!
    public void getAttr(){
        Console.WriteLine($"\nTire Type is {this.wheelType}");
        Console.WriteLine($"This Tire engine has a radius of{this.wheelRadius} cm");
        Console.WriteLine($"This Tire engine was build in {this.wheelBuild}");
    }
}
