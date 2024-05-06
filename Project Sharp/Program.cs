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
    public string color = "Orange";
    string species = "Kampung";
    int age = 2;

    public void Eat(){
        Console.WriteLine("Hey you Eat Now!");
    }
    public string isColor(){
        return color;
    }
}