namespace Enum;

public class IntCalculator
{
    public int Add(params int[] numbers){
        int sum = 0;
        foreach (int i in numbers){
            sum += i;
        }
        return sum;
    }
}


public class StringCalculator
{
    public int Add(params string[] strings){
        int sum = 0;
        foreach (string i in strings){
            sum += int.Parse(i);
        }
        return sum;
    }
}

public class CustomPrintParams{
    public object Print(params object[] objects){
        foreach(object i in objects){
            Console.WriteLine(i);
        }
        return 0;
    }
}