using System;
namespace Quadcopter;

public class Motor{
    private string motorBrand;
    private int yearBuilt;
    private int maxMotorSpeed;
    private int minMotorSpeed;

    // Start constuctor here
    public Motor
    (string motorBrand, int yearBuilt,
    int maxMotorSpeed, int minMotorSpeed){
        this.motorBrand = motorBrand;
        this.yearBuilt = yearBuilt;
        this.maxMotorSpeed = maxMotorSpeed;
        this.minMotorSpeed = minMotorSpeed;
    }
    // Method here
    public void getAttr(){
        Console.WriteLine($"Quadcopter Motor Brand is: {this.motorBrand} build in {this.yearBuilt}");
        Console.WriteLine($"This motor has max power speed of {this.maxMotorSpeed} rpm");
        Console.WriteLine($"While this motor has min power speed of {this.minMotorSpeed} rpm");
    }
}