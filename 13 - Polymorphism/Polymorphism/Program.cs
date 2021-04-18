using System;
using System.Collections.Generic;

namespace Polymorphism
{
    /*
     * Polymorphism is often referred to as the third pillar of object-oriented programming, 
     * after encapsulation and inheritance. Polymorphism is a Greek word that means "many-shaped" 
     * and it has two distinct aspects:
     * 
     * At run time, objects of a derived class may be treated as objects of a base class in places such as method parameters and collections or arrays. 
     * When this polymorphism occurs, the object's declared type is no longer identical to its run-time type.
     * Base classes may define and implement virtual methods, and derived classes can override them, which means they provide their own definition and implementation. 
     * At run-time, when client code calls the method, the CLR looks up the run-time type of the object, and invokes that override of the virtual method. 
     * In your source code you can call a method on a base class, and cause a derived class's version of the method to be executed.
     */
    class Program
    {
        static void Main(string[] args)
        {
            var shapes = new List<Shape>
            {
                new Circle(),
                new Rectangle()
            };

            foreach (var shape in shapes)
            {
                shape.Draw();
            }

            Console.ReadLine();
        }
    }

    // Class cirle derives from class Shape
    class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Circle");
            base.Draw();    
        }
    }

    class Rectangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Rectangle");
            base.Draw();
        }
    }
}
