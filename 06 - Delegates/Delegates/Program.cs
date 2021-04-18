using System;

namespace Delegates
{
    /*
     * A delegate is a type that represents references to methods with a particular 
     * parameter list and return type. When you instantiate a delegate, you can 
     * associate its instance with any method with a compatible signature and 
     * return type. You can invoke (or call) the method through the delegate instance.
     * 
     * Delegates are used to pass methods as arguments to other methods. Event handlers 
     * are nothing more than methods that are invoked through delegates. You create a 
     * custom method, and a class such as a windows control can call your method when a 
     * certain event occurs. The following example shows a delegate declaration:
     */
    class Program
    {
        //delegate void MyDelegate();
        delegate void Operation(int number);
        static void Main(string[] args)
        {
            //MyDelegate del = new MyDelegate(SayHello);
            //MyDelegate del2 = SayHello;
            //del2.Invoke();
            //del.Invoke();
            SayHello();

            Operation op = Double;
            ExecuteOperation(2, op);

            op = Tripe;
            ExecuteOperation(8, op);

            Console.ReadLine();
        }

        enum Level
        {
            Low,
            Medium,
            High
        }

        static void SayHello()
        {
            Console.WriteLine($"Hello guys! {Level.High}");
        }

        static void Double(int num)
        {
            Console.WriteLine($"{num} x 2 = {num * 2}");
        }

        static void Tripe(int num)
        {
            Console.WriteLine($"{num} x 3 = {num * 3}");
        }

        static void ExecuteOperation(int num, Operation operation)
        {
            operation(num);
        }
    }
}
