using System;
using System.Threading;
using System.Threading.Tasks;

namespace Task_Parallel_Library
{
    /*
     * The Task Parallel Library (TPL) is a set of public types and APIs in the System.Threading and System.Threading.Tasks namespaces. 
     * The purpose of the TPL is to make developers more productive by simplifying the process of adding parallelism and concurrency to applications. 
     * The TPL scales the degree of concurrency dynamically to most efficiently use all the processors that are available. 
     * In addition, the TPL handles the partitioning of the work, the scheduling of threads on the ThreadPool, 
     * cancellation support, state management, and other low-level details. By using TPL, you can maximize the performance of your code 
     * while focusing on the work that your program is designed to accomplish.
     */
    class Program
    {
        static void Main(string[] args)
        {
            /// This guy will be initialized immediately
            /// So we do not actually need the .Start() to initialize the Task
            /// It will do it automatically.
            var t1 = Task.Factory.StartNew(() => DoSomethingImportantWork(1, 1500))
                .ContinueWith((prevTask) => DoSomeOtherImportantWork(1, 1000));

            var t2 = new Task(() => DoSomethingImportantWork(2, 3000));
            t2.Start();

            var t3 = new Task(() => DoSomethingImportantWork(3, 1000));
            t3.Start();

            Console.WriteLine("Press any key to quit");
            Console.ReadLine();
        }

        static void DoSomethingImportantWork(int id, int sleepTime)
        {
            Console.WriteLine("Task {0} is beginning", id);
            Thread.Sleep(sleepTime);
            Console.WriteLine("Task {0} has completed", id);
        }

        static void DoSomeOtherImportantWork(int id, int sleepTime)
        {
            Console.WriteLine("Task {0} is beginning", id);
            Thread.Sleep(sleepTime);
            Console.WriteLine("Task {0} has completed", id);
        }
    }
}
