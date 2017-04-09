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
            Task<int> task = FetchOrDefaultAsync();
            Console.WriteLine("Result: {0}", task.Result);
            Console.ReadLine();
        }

        private static async Task<int> FetchOrDefaultAsync()
        {
            // Nothing special about IOException here
            try
            {
                Task<int> fetcher = Task<int>.Factory.StartNew(() => { throw new IOException(); });
                return await fetcher;
            }
            catch (IOException e)
            {
                Console.WriteLine("Caught IOException: {0}", e);
                return 5;
            }
            catch (System.Exception e)
            {
                Console.WriteLine("Caught arbitrary exception: {0}", e);
                return 10;
            }
        }
    }
}
