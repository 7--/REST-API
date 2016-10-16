using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Chp1_1
{
  public static class Program
  {
    public static ThreadLocal<int> _field
      = new ThreadLocal<int>(() =>
      {
        return Thread.CurrentThread.ManagedThreadId;
      });

    public static void ThreadMethod(object a)
    {
      for (int i = 0; i < 10; i++)
      {
        Console.WriteLine("ThreadProc: {0}", i);
        Thread.Sleep(0);
      }
    }
    public static void Main()
    {
      bool stopped = false;
      //Thread t = new Thread(new ParameterizedThreadStart(ThreadMethod));
      //t.Start(5);
      Thread t2 = new Thread(new ThreadStart(() =>
      {
        while (!stopped)
        {
          Console.WriteLine("Running...");
          Thread.Sleep(0);
        }
      }));
      t2.Start();
      
      for (int i = 0; i < 4; i++)
      {
        Console.WriteLine("Main thread: Do some work.");
        Thread.Sleep(0);
      }
      //t.Join();
      stopped = true;



      new Thread(() =>
      {
        Console.WriteLine();
      }).Start();

      ThreadPool.QueueUserWorkItem((s) =>
      {
        Console.WriteLine("Working on a thread from threadpool");
      });

      Task<int> task = Task.Run(() =>
      {
        for(int i=0; i<10; i++)
        {
          Console.Write(i);
        }
        return 9001;
      });
      Console.WriteLine(task.Result);
    
      task.Wait();
      Parallel.For(0, 10, i =>
       {
         Console.WriteLine("Parrallel" + i);
       });
      var numbers = Enumerable.Range(0, 10);
      Parallel.ForEach(numbers, a =>
      {
        Console.WriteLine(a);
      });

      Async asy = new Async();
      asy.Button_Click();


      var  enumerable = Enumerable.Range(0, 100000);
      var parallelResult = enumerable.AsParallel()
        .Where(i => i % 2 == 0).AsSequential()
        .ToArray();
      foreach(int i in parallelResult)
        Console.WriteLine(i);
      Console.ReadLine();

    }
  }
}