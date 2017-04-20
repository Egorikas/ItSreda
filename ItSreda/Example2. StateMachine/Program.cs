using System;
using System.Threading.Tasks;

namespace Example2.StateMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            var example = new Example();
            example.ShowStateMachine().Wait();
            Console.ReadLine();
        }
    }

    public class Example
    {
        public async Task ShowStateMachine()
        {
            FirstSync();
            await Task.Delay(500);
            SecondSync();
        }

        public void FirstSync()
        {
            Console.WriteLine("First");
        }

        public void SecondSync()
        {
            Console.WriteLine("Second");
        }
    }

}
