using System;
        
class Program{
    static void Main(){
        public byte[] ByteArray = new byte[85000];
        ExternalResources externalResources = new();
        public List<int> totalPlayers;
    }
}

class ExternalResources{
    public ExternalResources(){
        Console.Write("You this is External Resources");
    }
}

class Player:IDisposable{
    // Example of resource that want to be cleaned
    // Remember, when  object we reference set to null
    // that will means that object will not reference agian
    // resulting can be garbage-collected


    // Marking Dispose
    public bool isDispose = false;

    // This is from the IDisposable interface
    public virtual void Dispose(){
        Dispose(true);
        GC.SuppressFinalize(true);
    }

    // Method Operator Overloading
    // This is our own template
    protected virtual void Dispose(bool disposing){
        if(!isDispose){
            if(disposing){
                // Clean managed resources here
            }
            // Clean up the rest of unmanaged resources
            isDispose = true;
        }
    }
}