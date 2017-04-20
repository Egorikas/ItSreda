using System;
using System.Threading.Tasks;

namespace Example7.Exceptions
{
    class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Example1().Wait();
            }
            catch (AggregateException e)
            {
                Console.WriteLine(e);
            }
            Console.ReadLine();
        }

        public static async Task Example1()
        {
            await Task.Delay(30);
            throw new NotImplementedException("bang");
        }

        public static async void Example2()
        {
            await Task.Delay(30);
            throw new NotImplementedException("bang-bang");
        }


        public static async Task Example3()
        {
            try
            {
                Execute(async () => { throw new NotImplementedException("bang-bang-bang"); });
            }
            catch (System.Exception e)
            {
                Console.WriteLine("An exception occured: " + e.Message);
            }
            await Task.Delay(TimeSpan.FromSeconds(1));
        }

        public static void Execute(Action action)
        {
            action();
        }
    }
}
