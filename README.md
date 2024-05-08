# Software Engineering Formulatrix Bootcamp
Here lies the base repo for the Formulatrix Software Engineering Bootcamp. C# Ecosystem will be used here

## Progress
### 1st day 
Build initial repo for the rest of the ongoing bootcamp, making an example of the branch, and installing the essential tools for the bootcamp (.NET(still dont know what is this), C# VSCode Extension, and SourceTree(Just like towergit)). 

For the first creation of the C# Project structure, the workflow of the creation is as follow
    `solution(sln) --> project(.csproj) --> assembly --> [.exe, .dll]`
Now for adding a new solution blueprint, how we do it? Below are the terminal command for it
```sh
dotnet new sln -n "filename"
```
After we make the solution, we can make the project based on those blueprint(solution) wih this command at the shell
```sh
dotnet new 'console' -lang "C#" -n "ProjectName" -o "CSPROJName"
```

* a-fact : in C#, everything needs to be done in class, just like Java I guess. I mean, maybe thats why Java is going to extinct
* a-fact : In default, variable in class C# is protected, no one from outside can access those the trick is to make a function to make them public and access them there
* a-fact again : in C#, every function or method in C# in this case, need everytime to evaluate each class with a type, so if you want a even need to return 

### 2nd Day
Another day continuing C# project inisialisation. Today we focus more using namespace and modulatization of each function in the project. Day 2 progress contained in Work2 Folder. The steps are like this, for more easy work, we can make a folder with itention the name of the namespace it is, because I want to make a namespace of `quadcopter` included a model also the motor parameter, I named my folder quadcopter.

    ├── Quadcopter
    ├──--- Model.cs
    ├──--- Motor.cs

With the in first of the line code at motor.cs is as folllows
```csharp
using System;
namespace Quadcopter;

// here lies how we construct the main class
public class Motor{
    // and here is the constructor
    public Motor(**args){
    }
}
```

But the problem is that I still don't get it how I achieve if I want to use another namespace as my calculation group with it parameter from another namespace and called it in my main program

Now, it's inheritance. 
Inheretence basically like super _init__ like python. So basically in python you go like this (I got this from ROS Gazebo class Node)
```python
from rclpy.node Import Node

class bigClass(Node){
    super().__init__('')
    # Something to code
}
```
in C#, we can do something similar like this
```csharp
public class Parents{
    // Constructor and Method here
}

public class Child:Parents{
    public Child():base(){
        // Code here
    }
}
```

### 3rd Day
In 3rd day, Types, Polyphremism, and Override Method was introduce here. The way I see it, we can use Override if there is derived childs from parent class that some of them have this behaviour and some of them are not. So, we can further save time from typing it. Override is special to method/function.

Ada juga pelajari tentang interface. Interface and Abstrack in C# is such a dumb idea. Probably wise to see some example of interface. Yeah interface is just for method. Bedanya pake modifier `abstrack` itu sama seperti `virtual`, saat method itu diganti pada class child itu kita bisa menggantinya dan bahkan di abstrak boleh ada isinya, sedangkan interface itu cuma boleh ada cetakan method doang

// Isi code contoh penggunaan abstract
```csharp
abstract class Shape{
    public abstract void Draw();
    public void ChangeColor(){
        Console.Writeline("Change color now!");
    }
    // and so on, we can put some abstract method here + some method blueprints that we want to derivate to the child. In this case the ChangeColor Method
}
```

// Isi penggunaan Interface
```csharp
interface IShape{
    void Draw();
    void MakeWay();
    // And so on, interface only provide blueprints method
}
```

// Pengunaan Abstract dan Interface
```csharp
public class Program{
    static void Main(){
        var circle = new Circle()
        circle.Draw();  // Draw a circle
        circle.Changecolor(); // Change Color now (if using abstract classifier)
    }
}

public Circle:Shape, IShape{
    // If its using Interface
    public void Draw(){
        Console.Writeline("Draw a circle in Interface!");
    }
    // If its using Abstract classifier access
    public override void Draw(){ // use override access 
        Console.Writeline("Draw a circle in Abstract Modifier");
    }
    // If using abstract classifier, the ChangeColor method will be inhereted here in Circle Class
}
```

`static` classifier adalah salah satu konvensi yang enak jika ingin membuat sebuah function tapi nggak mau repot memasukkannya kedalam sebuah `var` untuk dimasukkan

Previous assignment, for modularity there is components that we need to assign to a new variable to even access them, but with `static` classifier, we can use the function just by call their class. See example below:

// Without static
```csharp
public class Program{
    static void Main(){
        var engine = new Engine(); 
        engine.engineLast(); // See? We need var engine to even access the Engine Class
    }
}

public class Engine{
    public string engineType = "Diesel";
    public int engineLast(){
        return 1000;
    }
}
```

// With static
```csharp
public class Program{
    static void Main(){
        Engine.engineLast(); // See? so simple
    }
}

public static class Engine{
    public static string engineType = "Diesel";
    public static int engineLast(){
        return 1000;
    }
}
```

So if you want to directly access a field(variable) or a method(function), you need to add a static access modifier in front of them. Adding `static` in their parent class is preferable.




