using System;


public abstract class Duck:IFlyableStrategy, IQuackableStrategy{
    protected IFlyableStrategy flyable;
    protected IQuackableStrategy quackable;
    public Duck(IFlyableStrategy flyableStrategy, IQuackableStrategy quackableStrategy){
        flyable = flyableStrategy;
        quackable = quackableStrategy;
    }
    public void Fly(){
        flyable.Fly();
    }
    public void Quack(){
        quackable.Quack();
    }
}