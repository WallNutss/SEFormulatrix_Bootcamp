using System;
using System.Threading;
using System.Security.AccessControl;


class Program{
    static SemaphoreSlim semaphoreSlim = new(2);
    static async Task Main(){
        // Making 10 new task
        Task[] tasks = new Task[10];
        for(int i=0;i<tasks.Length;i++){
            int index = i;
            tasks[index] = Task.Run(async ()=> await DoWork(index));
        }
        await Task.WhenAll(tasks);
    }
    static async Task DoWork(int index){
        Console.WriteLine($"Task {index} started");
        
        await semaphoreSlim.WaitAsync();

        await Task.Delay(500);
        Console.WriteLine($"Task {index} processing");
        await Task.Delay(500);
        semaphoreSlim.Release();
        Console.WriteLine($"Task {index} ended");
    }
}