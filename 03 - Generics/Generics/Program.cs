using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace Generics
{
    class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            var result = new Report<bool, int>
            {
                MyProperty = 1,
                MyProperty2 = true,
                MyProperty3 = 4
            };

            var helper = new PrintInformation();
            helper.Print(result);
            RunGenerics(); // Real life case
        }

        /// <summary>
        /// Report with generics class
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        public class Report<T, U>
        {
            public int MyProperty { get; set; }
            public T MyProperty2 { get; set; }
            public U MyProperty3 { get; set; }
        }

        /// <summary>
        /// Print information method
        /// </summary>
        public class PrintInformation
        {
            public void Print<T, U>(Report<T, U> report)
            {
                Console.WriteLine(report.MyProperty);
                Console.WriteLine(report.MyProperty2);
                Console.WriteLine(report.MyProperty3);
                Console.ReadKey();
            }
        }

        #region Generic real life
        public class Request<AnyType>
        {
            readonly AnyType data;
            public Request(AnyType person)
            {
                this.data = person;
            }

            /// <summary>
            /// Requester to the endpoint
            /// </summary>
            /// <param name="url"></param>
            /// <returns></returns>
            public string Requester(string url)
            {
                string result = string.Empty;
                WebRequest oRequest = WebRequest.Create(url);
                oRequest.Method = "POST";
                oRequest.ContentType = "application/json;charset=UTF-8";

                using (var oSW = new StreamWriter(oRequest.GetRequestStream()))
                {
                    string json = JsonConvert.SerializeObject(data);
                    oSW.Write(json);
                    oSW.Flush();
                    oSW.Close();
                }

                WebResponse oResponse = oRequest.GetResponse();
                using (var oSR = new StreamReader(oResponse.GetResponseStream()))
                {
                    result = oSR.ReadToEnd().Trim();
                }

                return result;
            }
        }

        /// <summary>
        /// This method will create the request to the endpoint
        /// </summary>
        public static void RunGenerics()
        {
            // Main endpoint
            string endPoint = "https://jsonplaceholder.typicode.com/posts";

            // Object 1
            Person person = new Person { Name = "Baldur", Age = 2 };
            Request<Person> oRequest = new Request<Person>(person);
            string myResponse = oRequest.Requester(endPoint);

            // Object 2
            Car car = new Car { Brand = "Nissan", Type = "Cashcai" };
            Request<Car> oRequest2 = new Request<Car>(car);
            string myResponse2 = oRequest2.Requester(endPoint);
        }

        /// <summary>
        /// Person model
        /// This classes are usually stored in their own models folder
        /// </summary>
        public class Person
        {
            /// <summary>
            /// Name of person
            /// </summary>
            public string Name { get; set; }

            /// <summary>
            /// Age of person
            /// </summary>
            public int Age { get; set; }
        }

        /// <summary>
        /// Car
        /// </summary>
        public class Car
        {
            /// <summary>
            /// Brand of car
            /// </summary>
            public string Brand { get; set; }

            /// <summary>
            /// Type of car
            /// </summary>
            public string Type { get; set; }
        }
        #endregion
    }
}
