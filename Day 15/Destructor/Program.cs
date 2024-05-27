using System;


class Program{
    static void Main(){
        PreInterface();
        GC.Collect();
        //GC.WaitForPendingFinalizers();
        Console.WriteLine("Main Program has finished");
    }
    public static void PreInterface(){
        Child child = new();
    }
}

class GrandParent{
    public GrandParent(){
        Console.WriteLine("GrandParent was created in Class");
    }
    ~GrandParent(){
        Console.WriteLine("GrandParent was destroyed in Class");
    }
}

class Parent: GrandParent{
    public Parent(){
        Console.WriteLine("Parent was created in Class");
    }
    ~Parent(){
        Console.WriteLine("Parent was destroyed in Class");
    }
}

class Child:Parent{
    
    public Child(){
        Console.WriteLine("Child was created in Class");
    }
    ~Child(){
        Console.WriteLine("Child was destroyed in Class");
    }
}