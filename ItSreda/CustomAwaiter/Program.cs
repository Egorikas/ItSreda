using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CustomAwaiter
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleWaitAsync().Wait();
            Console.ReadLine();
        }

        static async Task SimpleWaitAsync()
        {
            var awaitable = new SimpleInt32Awaitable();
            var result = await awaitable;
            Console.WriteLine(result);
        }

    }

    public struct SimpleInt32Awaitable 
    {
        public SimpleInt32Awaiter GetAwaiter()
        {
            return new SimpleInt32Awaiter();
        }
    }

    public struct SimpleInt32Awaiter : INotifyCompletion
    {
        public bool IsCompleted => true;

        public void OnCompleted(Action continuation)
        {
        }

        public int GetResult()
        {
            return 5;
        }
    }
}