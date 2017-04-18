using System;
using System.IO;
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
            using (var reader = File.OpenText("Words.txt"))
            {
                var fileText = await reader.ReadToEndAsync();
                Console.WriteLine(fileText);
                Console.ReadLine();
            }
        }
    }
}
