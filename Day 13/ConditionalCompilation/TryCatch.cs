using System.Runtime.InteropServices;
namespace Conditional;

class TryCatch{
    public void Try2(){
        // File name
        string fileName = "./file.txt";

        FileStream2 fm = new();
        string write = "Lorem Ipsum Dolor Pi 3.14 If today is wednesday write.....\nbut if it's not calculate 5+7MOD13";
        fm.Write(fileName, write);
        // fm.Write(fileName, write);
        Console.WriteLine("This is from Try Catch Method");

    }
}

class FileStream2{
    public void Write(string filename, string text){
        for(int i=0;i<10;i++){
            try{
                StreamWriter writer = new(filename); 
                Console.WriteLine("First Iteration"); 
                writer.WriteLine(text);
                // Console.WriteLine(writer);
            }catch(Exception e){
            Console.WriteLine($"Error : {e}");
            }finally{
            Console.WriteLine("StreamWrite has been run on try catch method");
            }
        }
    }

    public string Read(string filename){
        string result;
        using(StreamReader reader = new(filename)){
            result = reader.ReadLine();
        }
        return result;
    }

}

