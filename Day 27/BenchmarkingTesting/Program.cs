using System;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

class Program{
    static void Main(){
        BenchmarkRunner.Run<StringVsStringBuilderBenchmark>();
    }
}


[MemoryDiagnoser] // To get the result of how much memory allocated and GC has been triggered
public class StringVsStringBuilderBenchmark{
    [Params(100,1000,1000,100000)] // To varies of some variable to achieve multiple resutl based on this 
                                   // in this case, we want to test multiple iteration each with ther own result
    public int iteration;
    [Benchmark] // Benchmark Tag
    public string MyString(){
        string str = String.Empty;
        for(int i=0;i<iteration;i++){
            str += i;
        }
        return str;
    }

    [Benchmark]
    public string MyStringBuilder(){
        StringBuilder strbuilder = new();
        for(int i=0;i<iteration;i++){
            strbuilder.Append(i);
        }
        return strbuilder.ToString();
    }
}
