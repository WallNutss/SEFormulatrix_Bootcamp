using System;
namespace Quadcopter;

public class Model{
    // General Information
    private string modelName;
    private int yearBuilt;
    private int yearRevision;
    private int numberOfPropeller;
    private Motor motor;
    private int speed;

    // Specified Information of the model
    float gravity = 9.81f;
    float mass = 0.08f;
    float length = 0.06f;
    float Ixx = 0.0068f;
    float Iyy = 0.0068f;
    float Izz = 0.0131f;

    public Model(string modelName, int yearBuilt, int yearRevision, int numberOfPropeller, int speed, Motor motor){
        this.modelName = modelName;
        this.yearBuilt = yearBuilt;
        this.yearRevision = yearRevision;
        this.numberOfPropeller = numberOfPropeller;
        this.speed = speed;
        this.motor = motor;
    }
    public void getAttr(){
        Console.WriteLine($"Quadcopter Brand is {this.modelName} build in {this.yearBuilt} and has {this.numberOfPropeller} propeller");
    }

    public float getGravity(){
        return this.gravity;
    }
    public float calculateVelocity(){
        return this.speed += 10;
    }
}