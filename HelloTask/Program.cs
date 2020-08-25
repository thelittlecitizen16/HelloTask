using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;


namespace HelloTask
{
    class Program
    {
        public static ConcurrentStack<int> stack =  new ConcurrentStack<int>();
        static void Main(string[] args)
        {
            //Synchronous();
            // NewThreadToEveryNumber();
            //ThreadPoolToNumbers();
            CreateStack();
            RunTask(stack);

            Console.ReadLine();
        }
        public static void RunParallel()
        {
            for (int i = 0; i < stack.Count; i++)
            {
                Parallel.ForEach(stack, i =>
                {
                    Console.WriteLine(i);
                });
            }
        }
        public static void RunTask(ConcurrentStack<int> stack)
        {
            for (int i = 0; i <3; i++)
            {
                Task.Factory.StartNew(()=>
                {
                    while (!stack.IsEmpty)
                    {
                        int num;
                        stack.TryPop(out num);
                        Console.WriteLine(num);
                    }
                   
                });
            }
        }
        public static void CreateStack()
        {
            for (int i = 0; i <= 5000; i++)
            {
                stack.Push(i);
            }
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
                Thread thread = new Thread(() =>
                {
                    Console.WriteLine(i);
                });

                thread.Start();
            }
        }
        public static void ThreadPoolToNumbers()
        {
            for (int i = 0; i <= 1000000; i++)
            {
                ThreadPool.QueueUserWorkItem( place =>
                {
                    Console.WriteLine(place);
                } , i);
           }
        }
    }
}
