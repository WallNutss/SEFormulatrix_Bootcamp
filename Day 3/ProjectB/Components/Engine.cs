namespace Components;

public class Engine
{
    public string engineType;
    public int enginePower;
    public int engineBuilt;

    // Start constructor here for predifiend
    public Engine(string engineType, int enginePower,int engineBuilt){
        this.engineType = engineType;
        this.enginePower = enginePower;
        this.engineBuilt = engineBuilt;
    }
    // Here we can have a method to get it information too!
    public void getAttr(){
        Console.WriteLine($"\nEngine Type is {this.engineType}");
        Console.WriteLine($"This vehicle engine has {this.enginePower} horsepower");
        Console.WriteLine($"This vehicle engine was build in {this.engineBuilt}");
    }
}
