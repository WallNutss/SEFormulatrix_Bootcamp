using System.Security.Cryptography.X509Certificates;

class Program{
    static void Main(){
        string result = String.Empty;
        int iteration = 100000;
        int angka = 50;
        for(int i=0; i<iteration;i++){
            result += "Hello";
            result += "Squidward!";
            if(i == 5000){ 
                result += angka.ToString();
                byte[] egString = new byte[85000];
            }
        }
        Console.WriteLine(result);
    }
}