using System;


public class SimpleDuck:Duck{
    public SimpleDuck(IFlyableStrategy flyableStrategy, IQuackableStrategy quackableStrategy) : 
    base(flyableStrategy, quackableStrategy){
    }
    // They will inherit everything that was own by the Abstrat class Duck

}