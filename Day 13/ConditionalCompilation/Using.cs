using System.Runtime.InteropServices;
namespace Conditional;

class Using{
    public void Using2(){
        // File name
        string fileName = "./file.txt";

        FileStream fm = new();
        string write = "Lorem Ipsum Dolor Pi 3.14 If today is wednesday write.....\nbut if it's not calculate 5+7MOD13";
        fm.Write(fileName, write);

        Console.WriteLine("This is from Using Method");

    }
}

class FileStream{
    public void Write(string filename, string text){
        for(int i=0;i<100000;i++){
            using(StreamWriter writer = new (filename)){
            Console.WriteLine(writer);
            // GCHandle handle = GCHandle.Alloc(writer, GCHandleType.Pinned);
            // Console.WriteLine($"Address: 0x{handle.AddrOfPinnedObject():X}");
            writer.WriteLine(text);
            Console.WriteLine("StreamWrite has been run on using method");
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

