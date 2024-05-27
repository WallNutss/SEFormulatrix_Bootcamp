using System;
using System.Threading;

    class Program{
       static readonly string pblock = "WOW"; // The key
       static readonly int gear = 2;
       public static int result = 0;
       static void PrintInfo(int adder){
        if(gear==1){
            lock(pblock){
                for (int i = 1; i <= 4; i++)
                {
                    result += adder;
                    Console.WriteLine($"i value: {i}, Name: {Thread.CurrentThread.Name},  tid {Thread.CurrentThread.ManagedThreadId}, result {result}");
                    Thread.Sleep(1000);
                }
            }
        }else{
            for (int i = 1; i <= 4; i++)
            {
                result += adder;
                Console.WriteLine($"i value: {i}, Name: {Thread.CurrentThread.Name},  tid {Thread.CurrentThread.ManagedThreadId}, result {result}");
                Thread.Sleep(1000);
            }
        }
       }
       static void Main(string[] args)
       {
          Thread t1 = new Thread(() => PrintInfo(1));
          Thread t2 = new Thread(() => PrintInfo(2));
          Thread t3 = new Thread(() => PrintInfo(3));
          Thread t4 = new Thread(() => PrintInfo(4));
          Thread t5 = new Thread(() => PrintInfo(5));
          t1.Name = "T1";
          t2.Name = "T2";
          t3.Name = "T3";
          t4.Name = "T4";
          t5.Name = "T5";
          t1.Start();
          t2.Start();
          t3.Start();
          t4.Start();
          t5.Start();
          // Console.ReadLine();
       }
    }
