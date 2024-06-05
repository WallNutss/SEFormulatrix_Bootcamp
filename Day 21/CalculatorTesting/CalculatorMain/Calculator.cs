using System;
using System.Text;
namespace Calculator.Prog;

public class Calculator{
    public Calculator(){

    }
    public int Add(int x, int y){
        return x+y;
    }
    public int Factorial(int x){
        int result = 1;
        for(int i=1;i<=x;i++){
            result *= i; 
        }
        return result;
    }
    
    public string Reverse(string a){
        StringBuilder result = new();
        for(int i=a.Count()-1;i>=0;i--){
            result.Append(a.ToLower()[i]);
        }
        return result.ToString();
    }
}
