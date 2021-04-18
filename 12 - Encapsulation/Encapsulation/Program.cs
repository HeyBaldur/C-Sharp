using System;

namespace Encapsulation
{
    /*
     * Encapsulation is defined as the wrapping up of data under a single unit. It is the mechanism that binds 
     * together code and the data it manipulates. In a different way, encapsulation is a protective shield that 
     * prevents the data from being accessed by the code outside this shield.
     * 
     * Technically in encapsulation, the variables or data of a class are hidden from any other class and can be 
     * accessed only through any member function of own class in which they are declared.
     * As in encapsulation, the data in a class is hidden from other classes, so it is also known as data-hiding.
     * Encapsulation can be achieved by: Declaring all the variables in the class as private and using C# Properties 
     * in the class to set and get the values of variables.
     */
    class Program
    {
        static void Main(string[] args)
        {
            // Encapsulation example 
            //DriveClass dClass = new DriveClass();
            //dClass.AccessToProperties("Rodolfo", 29);

            int[] x = { 10, 19, 18 };
            int[] y = { 11, 15, 9 };

            FindNumbers findNumbers = new FindNumbers();
            findNumbers.Find(x, y);


            Console.Write($"Total pairs = {findNumbers.CountPairs(x, y, x.Length, y.Length)}");
            Console.ReadLine();
        }

        /*
         * Task # 1
         * Find number of pairs (x, y) in an array such that x^y > y^x
         * Given two arrays X[] and Y[] of positive integers, find number of pairs 
         * such that x^y > y^x where x is an element from X[] and y is an element from Y[].
         * Examples:
         *  ==> Input: X[] = {2, 1, 6}, Y = {1, 5}
         *  ==> Output: 3
         *  ==> Explanation: There are total 3 pairs where pow(x, y) is greater
         *  ==> than pow(y, x) Pairs are (2, 1), (2, 5) and (6, 1)
         */

        public class FindNumbers
        {
            public int Find(int[] x, int[] y)
            {
                Array.Sort(x);
                Array.Sort(y);
                int counter = 0;

                if (x == null)
                    return counter;

                // x^y > y^x
                for (int i = 0; i < x.Length; i++) // here we have x
                {
                    for (int j = 0; j < y.Length; j++) // here we have y
                    {
                        if (Math.Pow(x[i], y[j]) > Math.Pow(y[j], x[i]))
                            counter++;
                    }
                }

                Console.WriteLine($"There are total {counter} pairs where pow(x, y) is greater than pow(y, x)");
                return counter;
            }

            static int Count(int x, int[] Y, int n, int[] NoOfY)
            {
                // If x is 0, then there cannot be any  
                // value in Y such that x^Y[i] > Y[i]^x 
                if (x == 0)
                    return 0;

                // If x is 1, then the number of pais  
                // is equal to number of zeroes in Y[] 
                if (x == 1)
                    return NoOfY[0];

                // Find number of elements in Y[] with  
                // values greater than x getting  
                // upperbound of x with binary search 
                int idx = Array.BinarySearch(Y, x);
                int ans;
                if (idx < 0)
                {
                    idx = Math.Abs(idx + 1);
                    ans = Y.Length - idx;
                }
                else
                {
                    while (idx < n && Y[idx] == x)
                    {
                        idx++;
                    }
                    ans = Y.Length - idx;
                }

                // If we have reached here, then x 
                // must be greater than 1, increase  
                // number of pairs for y = 0 and y = 1 
                ans += (NoOfY[0] + NoOfY[1]);

                // Decrease number of pairs  
                // for x = 2 and (y = 4 or y = 3) 
                if (x == 2)
                    ans -= (NoOfY[3] + NoOfY[4]);

                // Increase number of pairs for x = 3 and y = 2 
                if (x == 3)
                    ans += NoOfY[2];

                return ans;
            }

            // Function to that returns count 
            // of pairs (x, y) such that x belongs  
            // to X[], y belongs to Y[] and x^y > y^x 
            public int CountPairs(int[] X, int[] Y, int m, int n)
            {
                // To store counts of 0, 1, 2, 3 and 4 in array Y 
                int[] NoOfY = new int[5];
                for (int i = 0; i < n; i++)
                    if (Y[i] < 5)
                        NoOfY[Y[i]]++;

                // Sort Y[] so that we can do binary search in it 
                Array.Sort(Y);

                int total_pairs = 0; // Initialize result 

                // Take every element of X and count pairs with it 
                for (int i = 0; i < m; i++)
                    total_pairs += Count(X[i], Y, n, NoOfY);

                return total_pairs;
            }
        }
    }
}
