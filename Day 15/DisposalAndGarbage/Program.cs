// Unmanaged Resources

using System;
using System.IO;

class Program{
    static void Main(){
        Console.WriteLine("Oshiete Kurbea");
    }
}

class ResourceHandler : IDisposable{
    private Pineaple spongebob;
    private MemoryStream managedResources;
    private FileStream unManagedResources;

    public bool dispose = false;
    
    public ResourceHandler(string filePath){
        managedResources = new MemoryStream();
        unManagedResources = new FileStream(filePath, FileMode.Open);
    }
    protected virtual void Dispose(bool dispose){
        if(!dispose){
            Console.WriteLine(!dispose);
            spongebob = null;
        }
        
    }
    public void Dispose(){
        Dispose(dispose: true); // Kok bisa padahal nggak ada isinya, how?
        GC.SuppressFinalize(this);
    }
}

class Pineaple{}