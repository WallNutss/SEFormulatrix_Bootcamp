namespace Generics;

public class GenericConstraint
{
    public static void GenericConstraintMethod<T>(ref T x, ref T y){
        T swaps = x;
        x = y;
        y = swaps;
    }
}
