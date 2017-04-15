using System;
using System.Threading;
using System.Threading.Tasks;

namespace Example1.ThreadingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Example1().Wait();
        }

        static async Task Example1()
        {
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(900);
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }
    }
}
