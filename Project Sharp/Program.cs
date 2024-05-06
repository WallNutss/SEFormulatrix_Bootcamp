// // See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

class Program{
    static void Main(){
        Cat bino = new Cat();
        bino.Eat();
        Console.WriteLine(bino.isColor());
    }
}

// Adding a new class! It's a cat
class Cat{
    string color = "Orange"; //Private
    string species = "Kampung"; //Private
    int age = 2; //Private

    public void Eat(){
        Console.WriteLine("Hey you Eat Now!");
    }
    // In default, variable in class is protected, no one
    // from outside can access those, the trick is
    // to make a function to make them public and access
    // them there
    public string isColor(){
        return color;
    }
}