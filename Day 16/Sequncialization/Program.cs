using System;
using System.Text.Json;
using System.Xml.Serialization;

public class Human{
    public string name {get ; set;}
    public int age {get;set;}
    public Human(){}
    public Human(string name, int age){
        this.name = name;
        this.age = age;
    }
}

class Program{
    static void Main(){
        Human yusa = new("Yusa",26);
        Human ega = new("Ega",22);
        Human rizky = new("Rizky", 24);
        Human fadil = new("Fadil", 24);
        Human dewi = new("Dewi", 25);
        Human wulan = new("Wulan", 29);
        Human bella = new("Bella", 24);
        Human kinara = new("Kinara", 27);
        Human jun = new("Juni", 23);

        List<Human> boocampMember = new List<Human>(){
            yusa,ega,rizky,fadil,dewi,wulan,bella,kinara,jun
            
        };
        // JSON
        string JASON = JsonSerializer.Serialize(boocampMember);
        using(StreamWriter streamWriter = new("file1.json")){
            streamWriter.Write(JASON);
        }
        // XML
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Human>));
        using(StreamWriter streamWriter1 = new("file2.xml")){
            xmlSerializer.Serialize(streamWriter1,boocampMember);
        }

        string result;
        using(StreamReader streamReader = new("file1.json")){
            result = streamReader.ReadToEnd();
        }

        List<Human> humansMember = JsonSerializer.Deserialize<List<Human>>(result);

        foreach(var human in humansMember){
            Console.WriteLine($"name: {human.name}, age:{human.age}");
        }
    }

}