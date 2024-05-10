namespace Generics;

public class Swapper
{
    public static void Swap<T>(ref T x, ref T y){
        T swaps = x;
        x = y;
        y = swaps;
    }
}
