using System;

namespace Abstraction
{
    /*
     * Language-Integrated Query (LINQ) is the name for a set of technologies based on the 
     * integration of query capabilities directly into the C# language. Traditionally, 
     * queries against data are expressed as simple strings without type checking at compile 
     * time or IntelliSense support. Furthermore, you have to learn a different query language 
     * for each type of data source: SQL databases, XML documents, various Web services, and so on. 
     * With LINQ, a query is a first-class language construct, just like classes, methods, events. 
     * You write queries against strongly typed collections of objects by using language keywords 
     * and familiar operators. The LINQ family of technologies provides a consistent query experience 
     * for objects (LINQ to Objects), relational databases (LINQ to SQL), and XML (LINQ to XML).
     */
    class Program
    {
        static void Main(string[] args)
        {
            Shape sp = new Square(4);
            double result = sp.Area();
            Console.WriteLine("{0}", result);
            Console.ReadLine();
        }
    }

    public class Square : Shape
    {
        private int _side;
        public Square(int x = 0)
        {
            _side = x;
        }

        public override int Area()
        {
            Console.WriteLine("Area of square: ");
            return (_side * _side);
        }

        public override Array ArrayMethod()
        {
            throw new NotImplementedException();
        }
    }
}
