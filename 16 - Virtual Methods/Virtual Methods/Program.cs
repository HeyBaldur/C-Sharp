using System;

namespace Virtual_Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            Cone cone = new Cone(5, 10);
            Cylinder cylinder = new Cylinder(6, 14);
            Console.WriteLine($"The cone volume is {cone.Volume().ToString()}");
            Console.WriteLine($"The cylinder volume is {cylinder.Volume().ToString()}");
            Console.ReadKey();
        }
    }
}
