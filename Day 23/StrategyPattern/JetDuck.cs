using System;


public class JetDuck:Duck{
    public JetDuck(IFlyableStrategy flyableStrategy, IQuackableStrategy quackableStrategy) : 
    base(flyableStrategy, quackableStrategy){
    }

}