using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception
{
    class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Example1().Wait();
            }
            catch (System.AggregateException e)
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
