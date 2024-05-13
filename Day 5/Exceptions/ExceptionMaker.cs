namespace Exceptions;

public delegate int MyIntDelegate();
public delegate void MyVoidDelegate();

public class ExceptionMaker{
    public static int DivideByZeroExc(){
        int x = 5;
        int results = x/0;
        return results;
    }
    public static void OverFlowExc(){
        int[] numbers = [1,2,3,4,5];
        //int[10] = 4;
    }
    public static float NotFiniteNumberExc(){
        float x = 5.0f;
        float results = x/0;
        results += 2.0f;
        return results;
    }
    public static void StackOverflowExc(){
        StackOverflowExc();
    }
    public static void Print(){
        Console.WriteLine("Hey");
    }
}
