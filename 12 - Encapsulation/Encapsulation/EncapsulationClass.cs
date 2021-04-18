using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    public class EncapsulationClass
    {
        private String studentName;
        private int studentAge;

        // using accessors to get and  
        // set the value of studentName 
        public String Name
        {
            get { return studentName; }
            set { studentName = value; }
        }

        public int Age
        {
            get { return studentAge; }
            set { studentAge = value; }
        }
    }

    public class DriveClass
    {
        public void AccessToProperties(string fname, int age)
        {
            EncapsulationClass encapsulationClass = new EncapsulationClass();

            encapsulationClass.Name = fname;
            encapsulationClass.Age = age;

            Console.WriteLine($"The name is: {encapsulationClass.Name} and the age: {encapsulationClass.Age}");
            Console.ReadLine();
        }
    }

    /*
     * Explanation: In the above program the class DemoEncap is encapsulated as the 
     * variables are declared as private. To access these private variables 
     * we are using the Name and Age accessors which contains the get and set method 
     * to retrieve and set the values of private fields. Accessors are defined as 
     * public so that they can access in other class.
     */
}
