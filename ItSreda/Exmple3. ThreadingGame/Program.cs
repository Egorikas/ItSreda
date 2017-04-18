using System;
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
            await Task.Delay(900);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }

        static async Task Example2()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            await Task.FromResult(900);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }


        static async Task Example3()
        {
            Console.WriteLine($"Thread start of Example3 - {Thread.CurrentThread.ManagedThreadId}");
            var firstTask = Task.Run(async () =>
            {
                Console.WriteLine($"Task.Run before await- {Thread.CurrentThread.ManagedThreadId}");
                //await Task.FromResult(900);
                await Task.Delay(900);
                Console.WriteLine($"Task.Run Task await  - {Thread.CurrentThread.ManagedThreadId}");
            });
            Console.WriteLine($"Thread before Task.WhenAll - {Thread.CurrentThread.ManagedThreadId}");
            await Task.WhenAll(firstTask);
            Console.WriteLine($"Thread after Task.WhenAll - {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
