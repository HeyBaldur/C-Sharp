using System;
using System.Linq;
using System.Reflection;

namespace Attributes
{
    class Program
    {
        /// <summary>
        /// Attributes provide a powerful method of associating metadata, or declarative information, 
        /// with code (assemblies, types, methods, properties, and so forth). After an attribute 
        /// is associated with a program entity, the attribute can be queried at run time by using a 
        /// technique called reflection. 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // A little bit about reflexion
            var types = from t in Assembly.GetExecutingAssembly().GetTypes()
                        where t.GetCustomAttributes<SampleAttribute>().Count() > 0
                        select t;

            foreach (var type in types)
            {
                Console.WriteLine(type.Name);
                foreach (var prop in type.GetProperties())
                {
                    Console.WriteLine(prop.Name);
                }
            }

            Console.ReadLine();
        }

        /// <summary>
        /// This class uses the attributes
        /// </summary>
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Interface)]
        public class SampleAttribute : Attribute
        {
            public int MyProperty { get; set; }
            public bool Validation { get; set; }
        }

        [AttributeUsage(AttributeTargets.Class)]
        public class OtherAttribute: Attribute
        {
            public int MyProperty { get; set; }
        }

        [Sample]
        public class MyClass
        {
            [Sample]
            public int MyProperty { get; set; }
        }

        [Other(MyProperty = 2)]
        public class MyOtherClass
        {
            // Do some other stuff here
        }
    }
}
