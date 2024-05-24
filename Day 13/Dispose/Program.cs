using System;

class Program{
    static void Main(){
        
    }    
}


public class Human:IDisposable{
    // Managed resources
    public List<int> totalPlayers;

    // Unmanaged resource
    private bool isDispose = false;

    // Start constructor
    Human(){
        Console.WriteLine("Human Constructed!");
    }

    // Start destructor
    ~Human(){
        Console.WriteLine("Human got exploded!");
    }

    // Override Idisposable method
    // See here https://learn.microsoft.com/en-us/dotnet/api/system.idisposable?view=net-8.0
    public void Dispose(){
        Dispose(true);
        Console.WriteLine(this);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposingStart){
        if(!isDispose){
            if(disposingStart){
                // Clean managed resources here
            }
            // Clean up the rest of unmanaged resources
            isDispose = true;
        }
    }
}