using System;

namespace ConsoleAppFib
{
    class Program
    {
        public static void fibIterative(int limit)
        {
            if (limit == 0)
            {
                Console.WriteLine(0);
            }
            else if (limit == 1)
            {
                Console.WriteLine("0 1");
            }
            /*else if (limit == 2)
            {
                Console.WriteLine("0 1 1");
            }*/
            else
            {
                Console.Write("0 1 ");
                int prevPrev = 0;
                int prev = 1;
                int current;
                for (int i = 2; i <= limit; i++)
                {
                    current = prevPrev + prev;
                    prevPrev = prev;
                    prev = current;
                    Console.Write(current + " ");
                }
                Console.Write("\n");
            }
        }
        static void Main(string[] args)
        {
            Console.Write("Should be 0. Result is: ");
            fibIterative(0);

            Console.Write("Should be 0, 1. Result is: ");
            fibIterative(1);

            Console.Write("Should be 0, 1, 1. Result is: ");
            fibIterative(2);

            Console.Write("Should be 0, 1, 1, 2. Result is: ");
            fibIterative(3);

            Console.Write("Should be 0, 1, 1, 2, 3. Result is: ");
            fibIterative(4);

            Console.Write("Should be 0, 1, 1, 2, 3, 5. Result is: ");
            fibIterative(5);
        }
    }
}
