using System;
using System.Linq;
using System.Reflection;

namespace Reflection
{
    class Program
    {
        static void Main(string[] args)
        {
            var assembly = Assembly.GetExecutingAssembly(); 
            Console.WriteLine(assembly.FullName);

            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                Console.WriteLine($"The type name is: {type.Name}");
                var props = type.GetProperties();
                foreach (var prop in props)
                {
                    Console.WriteLine($"\tThe property is: {prop.Name} Property Type: {prop.PropertyType}");
                }

                var fields = type.GetFields();
                foreach (var field in fields)
                {
                    Console.WriteLine($"\tThe field is: {field.Name} Field Type: {field.FieldType}");
                }

                var methods = type.GetMethods();
                foreach (var method in methods)
                {
                    Console.WriteLine($"The method is: {method.Name}");
                }
            }

            var sample = new Sample { Name = "Albr", Age = 30 };
            var sampleType = typeof(Sample);

            var nameProperty = sampleType.GetProperty("Name");
            if (nameProperty != null)
            {
                Console.WriteLine($"Property name: {nameProperty.Name}");
                Console.WriteLine($"Property value: {nameProperty.GetValue(sample)}");
            }

            var myMethod = sampleType.GetMethod("MyMethod");
            myMethod.Invoke(sample, null);

            Console.WriteLine("==========================");
            var attributeTypes = assembly.GetTypes().Where(t => t.GetCustomAttributes<MyClassAttribute>().Count() > 0);
            foreach (var type in attributeTypes)
            {
                Console.WriteLine($"The type is: {type.Name}");

                var methodsCustomAttributes = type.GetMethods().Where(m => m.GetCustomAttributes<MyMethodAttribute>().Count() > 0);
                foreach (var method in methodsCustomAttributes)
                {
                    Console.WriteLine($"The method name is: {method.Name}");
                }
            }

            Console.ReadLine();
        }
    }

    [MyClass]
    public class Sample
    {
        public string Name { get; set; } // This is a property
        public int Age; // this is a field

        [MyMethod]
        public void MyMethod()
        {
            Console.WriteLine("Hello from method");
        }

        [MyMethod]
        public void MyMethod2() { }
    }

    [AttributeUsage(AttributeTargets.Class)]
    public class MyClassAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.Method)]
    public class MyMethodAttribute : Attribute { }
}
