using System;
using System.Threading;
using System.Threading.Tasks;

namespace Example1.ThreadingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Example3().Wait();
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
            Console.WriteLine($"Thread start of the method - {Thread.CurrentThread.ManagedThreadId}");
            var firstTask = Task.Run(async () =>
            {
                Console.WriteLine($"firstTaskThreadId before - {Thread.CurrentThread.ManagedThreadId}");
                await Task.Delay(900);
                await Task.Delay(900);
                await Task.Delay(900);
                Console.WriteLine($"firstTaskThreadId after - {Thread.CurrentThread.ManagedThreadId}");
            });
            var secondTask = Task.Run(async () =>
            {
                Console.WriteLine($"secondTaskThreadId before - {Thread.CurrentThread.ManagedThreadId}");
                await Task.Delay(900);
                Console.WriteLine($"secondTaskThreadId after - {Thread.CurrentThread.ManagedThreadId}");
            });
            var thirdTask = Task.Run(async () =>
            {
                Console.WriteLine($"thirdTaskThreadId before - {Thread.CurrentThread.ManagedThreadId}");
                await Task.Delay(900);
                Console.WriteLine($"thirdTaskThreadId after - {Thread.CurrentThread.ManagedThreadId}");
            });
            Console.WriteLine($"Thread before Task.WhenAll - {Thread.CurrentThread.ManagedThreadId}");
            await Task.WhenAll(firstTask, secondTask, thirdTask);
            Console.WriteLine($"Thread after Task.WhenAll - {Thread.CurrentThread.ManagedThreadId}");
        }
    }
}
