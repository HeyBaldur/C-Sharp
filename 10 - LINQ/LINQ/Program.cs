using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    /*
     * Language-Integrated Query (LINQ) is the name for a set of technologies based on the integration 
     * of query capabilities directly into the C# language. Traditionally, queries against data are 
     * expressed as simple strings without type checking at compile time or IntelliSense support. 
     * Furthermore, you have to learn a different query language for each type of data source: 
     * SQL databases, XML documents, various Web services, and so on. With LINQ, a query is a 
     * first-class language construct, just like classes, methods, events. You write queries 
     * against strongly typed collections of objects by using language keywords and familiar operators. 
     * The LINQ family of technologies provides a consistent query experience for objects (LINQ to Objects), 
     * relational databases (LINQ to SQL), and XML (LINQ to XML).
     */
    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>
            {
                new Person{FirstName = "Rodolfo", LastName = "Jaubert", Age = 29},
                new Person{FirstName = "Angie", LastName = "Avila", Age = 25},
                new Person{FirstName = "Laura", LastName = "Jaubert", Age = 55},
                new Person{FirstName = "Mike", LastName = "Campos", Age = 44},
                new Person{FirstName = "Lagertha", LastName = "Campos", Age = 22}
            };


            //string myValue = "I really love to code things and create the world with you!";
            //var myLinqResult = from p in myValue
            //                   where
            // p == 'a' || p == 'e' || p == 'i' || p == 'o' || p == 'u'
            //                   orderby p
            //                   group p by p;

            var myLinqResult = from p in people
                               where p.LastName.Contains("Jaubert")
                               select new
                               {
                                   FName = p.FirstName, // This is anonymous Type
                                   LName = p.LastName // This is anonymous Type
                               };


            foreach (var item in myLinqResult)
            {
                // Console.WriteLine($"{item.Key} - {item.Count()}");
                Console.WriteLine($"FN {item.FName} LN: {item.LName}");
            }
            Console.ReadLine();
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
