using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFactorialRec
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Factorial(4) = " + 4.Factorial());
            Console.WriteLine("Power(4, 2) = " + 2.Power(4));
            Console.WriteLine("ABBA is palindrom = " + "ABBA".IsPalindrom());
            Console.WriteLine("radar is palindrome = " + "radar".IsPalindrom());
            Numbers numbers = new Numbers();
            Console.WriteLine("Before sorting the array:");
            numbers.PrintNumbers();
            numbers.Sort();
            Console.WriteLine("After the array is sorted:");
            numbers.PrintNumbers();
            Console.ReadLine();
        }


    }
}
