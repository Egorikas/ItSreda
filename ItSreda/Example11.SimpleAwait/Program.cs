using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Example11.SimpleAwait
{
    public class Program
    {
        public static async Task Main(string[] args)
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

