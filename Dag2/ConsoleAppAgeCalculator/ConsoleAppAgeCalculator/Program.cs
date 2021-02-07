using System;

namespace ConsoleAppAgeCalculator
{
    class Program
    {
        /*in is used to state that the parameter passed cannot be modified by the method. 
        * out is used to state that the parameter passed must be modified by the method*/
        public static void calcAge(in int birthYear, out int age)
        {
            int currentYear = DateTime.Now.Year;
            age = (currentYear - birthYear);
            Console.WriteLine(age);
        }
        static void Main(string[] args)
        {
            int year = 1994;
            int age;
            calcAge(in year, out age);
        }
    }
}
