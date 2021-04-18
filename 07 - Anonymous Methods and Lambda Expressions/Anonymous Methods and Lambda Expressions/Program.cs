using System;

namespace Anonymous_Methods_and_Lambda_Expressions
{
    delegate void Operation(int number);
    class Program
    {
        /*
         * You use a lambda expression to create an anonymous function. Use the lambda declaration 
         * operator => to separate the lambda's parameter list from its body. 
         * A lambda expression can be of any of the following two forms:
         */
        static void Main(string[] args)
        {
            // This is an Anonymous way
            Operation op = delegate (int number)
            {
                Console.WriteLine($"{number} x 2 = {number * 2}");
            };
            op(2);

            // Generic delegates
            Action<int> operation = num => { Console.WriteLine($"{num} x 2 = {num * 2}"); };
            Func<int, int> myFunction = x => { return x * 2; };
            Func<int, string> anotherFunction = (x) => { Console.WriteLine($"{x}"); return "Hello"; };
            operation(2);

            Console.WriteLine(myFunction(6));

            // Final line
            Console.ReadLine();
        }

        static void Double(int number)
        {
            Console.WriteLine($"{number} x 2 = {number * 2}");
        }
    }
}
