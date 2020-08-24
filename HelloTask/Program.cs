using System;
using System.Threading;

namespace HelloTask
{
    class Program
    {
        static void Main(string[] args)
        {
            //Synchronous();
            NewThreadToEveryNumber();
        }
        public static void Synchronous()
        {
            for (int i = 0; i <= 1000000; i++)
            {
                Console.WriteLine(i);
            }
        }
        public static void NewThreadToEveryNumber()
        {
            for (int i = 0; i <= 1000000; i++)
            {
               Thread thread =  new Thread(() =>
                {
                    Console.WriteLine(i);
                });

                thread.Start();
            }
        }
    }
}
