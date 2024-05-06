// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");


class Program{
    static void Main(){
        quadcopter Karry = new quadcopter();
        // Take off
        Karry.takeOff();
        // Move
        Console.WriteLine(Karry.getBattery());
        Karry.Move();
        // Estimate flight time remaining
        Console.WriteLine(Karry.estimateFlightTime(3));
        // Landing
        Console.WriteLine(Karry.isControl());
        Karry.Land();
    }
}

// Adding a new class! It's a cat Quadcopter
class quadcopter{
    string name = "Cat Quadcopter";
    string producer = "Flighthawk";
    float gravity = 9.81f;
    int battery = 100;
    bool controller = true;

    public void takeOff(){
        Console.WriteLine("Take off! Move out");
    }
    public void Land(){
        Console.WriteLine("Landing, moving out!");
    }
    public void Move(){
        Console.WriteLine("I'M FLYINGGG!!!");
    }
    public float getGravity(){
        return gravity;
    }
    public int getBattery(){
        return battery;
    }
    public bool isControl(){
        return controller;
    }
    public int estimateFlightTime(int longpath){
        return battery*longpath;
    }
}
