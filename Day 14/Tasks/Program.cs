using System;
using System.Threading;
using System.Threading.Tasks;


class Program{
    static void Main(string[] args){
        Task task = Task.Run(()=>{
            for(int i=0;i<100;i++){
                if(i%2==0){
                    Console.WriteLine("+"); 
                }else{
                    Console.WriteLine("-"); 

                }
                Thread.Sleep(5);
            }
        });

        Console.WriteLine(task.IsCompleted);
        Console.WriteLine(task.IsCanceled);
        Console.WriteLine(task.IsFaulted);

        Task.WaitAll(task);
    }
}