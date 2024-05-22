class Program{
    static void Main(){

    }
}

internal class BikiniProgram{
    public void Greeting(){
        Console.WriteLine("Hello Squidward!");
    }
    ~BikiniProgram(){
        Console.WriteLine("Krabby Patty Sucks!");
    }
    public void Dispose(){
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}