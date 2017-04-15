using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exmple3.ThreadingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Example1().Wait();
            Console.ReadLine();
        }

        static async Task Example1()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            await Task.FromResult(900);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }


        static async Task Example2()
        {
            Console.WriteLine($"Thread start of the method - {Thread.CurrentThread.ManagedThreadId}");
            var firstTask = Task.Run(async () =>
            {
                Console.WriteLine($"Additional Task before - {Thread.CurrentThread.ManagedThreadId}");
                await Task.Delay(900);
                Console.WriteLine($"Additional Task after  - {Thread.CurrentThread.ManagedThreadId}");
            });
            Console.WriteLine($"Thread before Task.WhenAll - {Thread.CurrentThread.ManagedThreadId}");
            await Task.WhenAll(firstTask);
            Console.WriteLine($"Thread after Task.WhenAll - {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
