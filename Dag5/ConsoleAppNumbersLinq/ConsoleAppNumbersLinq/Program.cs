using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppNumbersLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = { 34, 8, 56, 31, 79, 150, 88, 7, 200, 47, 88, 20 };


            // 1. Return all two - digit integers sorted in ascending order.
            var orderedDigits = numbers.Where(n => n >= 10).OrderBy(n => n);
            foreach (int i in orderedDigits) Console.Write(i + " ");
            Console.WriteLine();

            // 2. Return all two - digit integers sorted in descending order.
            orderedDigits = numbers.Where(n => n >= 10).OrderByDescending(n => n);
            foreach (int i in orderedDigits) Console.Write(i + " ");
            Console.WriteLine();

            // 3. As in a.but instead of integers you must return strings ”20”, ”31”, ”34”, etc.
            var queryString = numbers.Where(n => n >= 10).OrderBy(n => n).Select(n => Convert.ToString(n));
            foreach (string s in queryString) Console.Write(s + " ");
            Console.WriteLine();

            // 4. As in c.but returning “20 even”, “31 uneven”, …
            queryString = numbers.Where(n => n >= 10).OrderBy(n => n).Select(n => n % 2 == 0 ? Convert.ToString(n) + " even, " : Convert.ToString(n) + " odd, ");
            foreach (string s in queryString) Console.Write(s + " ");
            Console.WriteLine();

            // 5. Write a query returning an anonymous type with two values: the integer and true / false indicating if the number is even.
            // Name the object attributes ”Number” and ”Even”.
            var queryObj =
                from n in numbers
                select new
                {
                    number = n,
                    even = (n % 2 == 0)
                }; 

            //foreach (var s in queryObj) Console.Write(s.ToString() + " ");

            queryObj = numbers.Select(n => new { number = n, even = (n % 2 == 0) });
            foreach (var s in queryObj) Console.Write(s.ToString() + " ");




            Console.ReadLine();
        }
    }
}
