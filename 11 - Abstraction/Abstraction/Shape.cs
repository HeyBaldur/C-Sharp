using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    public abstract class Shape
    {
        // Constructor
        public Shape()
        {
            this.Age = 2;
        }

        // Global variables
        public int Age { get; set; }
        public int YearOfBirth { get; set; }


        public abstract int Area();
        
        // Void method
        public void WhatEver()
        {
            // something here
        }

        // Return a array ==> Concrete method
        public Array NumberList<T>(int userId)
        {
            if (userId == 2)
            {
                // Code here
            }
            var numbers = new Array[1, 2, 3, 4];
            return (numbers);
        }

        public abstract Array ArrayMethod();
    }
}
