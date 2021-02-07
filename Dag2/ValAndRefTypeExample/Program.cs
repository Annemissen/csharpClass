using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 7;
            IncrementValueRef(ref a);
            Console.WriteLine(a);

            a = 7;
            IncrementValueNoRef(a);
            Console.WriteLine(a);

            Integer A = new Integer(7);
            IncrementValue(A);
            Console.WriteLine(A.value);

            Console.ReadLine();
        }

        private static void IncrementValue(Integer A)
        {
            A.value = A.value + 1;
        }

        private static void IncrementValueRef(ref int a)
        {
            a = a + 1;
        }

        private static void IncrementValueNoRef(int a)
        {
            a = a + 1;
            Console.WriteLine("Should be 8. Result is: " + a);

        }
    }

    class Integer
    {
        public int value;
        
        public Integer(int val)
        {
            value = val;
        }
    }
}
