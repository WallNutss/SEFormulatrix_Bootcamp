using System;


public class Person:IPlayer{
    public string UserName{get;set;}
    public int UserID{get;set;}
    // public Person(string name, int ID){
    //     UserName = name;
    //     UserID = ID;
    // }
    public string GetPersonIdentifier(Person person){
        if(person==null) return null;
        return $"{person.UserName}{person.UserID}";
    }
}