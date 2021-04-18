using System;

namespace Extension_Methods
{
    /*Extension methods enable you to "add" methods to existing types without creating a new derived type, 
     * recompiling, or otherwise modifying the original type. Extension methods are static methods, 
     * but they're called as if they were instance methods on the extended type. For client code written in 
     * C#, F# and Visual Basic, there's no apparent difference between calling an 
     * extension method and the methods defined in a type.
     */
    class Program
    {
        static void Main(string[] args)
        {
            var p = new Person { Name = "Rodolfo", Age = 5 };
            var p2 = new Person { Name = "Alberto", Age = 5 };
            p.SayHello(p2);

            Console.ReadLine();
        }
    }

    public static class Extenstions
    {
        public static void SayHello(this Person person, Person person2)
        {
            Console.WriteLine("{0} says hello to {1}", person.Name, person2.Name);
        }
    }
}
