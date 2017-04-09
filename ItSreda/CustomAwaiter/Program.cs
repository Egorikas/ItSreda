using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CustomAwaiter
{
    class Program
    {
        static void Main(string[] args)
        {
            SimpleWaitAsync();
            Console.ReadLine();
        }

        static async void SimpleWaitAsync()
        {
            SimpleInt32Awaitable awaitable = new SimpleInt32Awaitable();
            int result = await awaitable;
            var i = 0;
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
        public bool IsCompleted
        {
            get { return true; }
        }

        public void OnCompleted(Action continuation)
        {
        }

        public int GetResult()
        {
            return 5;
        }
    }
}