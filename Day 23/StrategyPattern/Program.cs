using System;


class Program{
    static void Main(string[] args){

        // Implementing the algoritm/strategy to be incoporated to child class
        SimpleFlyingStrategy simpleFlyingStrategy = new();
        JetFlyingStrategy jetFlyingStrategy = new();

        // Implementing different strategy of quacks
        WAAAQuackStrategy wAAAQuackStrategy = new();
        WOOOQuackStrategy wOOOQuackStrategy = new();
        NoQuackStrategy noQuackStrategy = new();


        // Class implementation of Duck
        // So instead hardcoding the Fly Method, we can pass the algorithm/strategy
        // of fly into the inizialization of it
        SimpleDuck simpleDuck = new(simpleFlyingStrategy, wOOOQuackStrategy);
        JetDuck jetDuck = new(jetFlyingStrategy, noQuackStrategy);


        // Simply call the algorithm back
        simpleDuck.Fly();
        jetDuck.Fly();
    }
}