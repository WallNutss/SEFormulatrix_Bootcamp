using System.Runtime.InteropServices;

class Program{
    static void Main(){
        // File name
        string fileName = "./file.txt";

        FileStream fm = new();
        string write = "Lorem Ipsum Dolor Pi 3.14 If today is wednesday write.....\nbut if it's not calculate 5+7MOD13";
        fm.WriteTry(fileName, write);
        // fm.Write(fileName, write);

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
    public void WriteTry(string filename, string text){
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

