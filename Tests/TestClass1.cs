using System;

namespace automationCSharp.TestCases
{

    public class TestClass1 
    {

        
        //[Test, Order(1)]
        public void TestMethod1()
        {

            string env = Environment.GetEnvironmentVariable("ENV");
            string browser = Environment.GetEnvironmentVariable("BROWSER");

            Console.WriteLine($"Running TestMethod1 with ENV={env} and BROWSER={browser}");


            Console.WriteLine("TestMethod1 executed1");
            // Add your test logic here
            Console.WriteLine("TestMethod1 executed");
        }

        

    }

}