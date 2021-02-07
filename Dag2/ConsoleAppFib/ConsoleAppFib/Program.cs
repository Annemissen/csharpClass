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
            Console.WriteLine("Indtast grænseværdi");
            int grænseværdi = Convert.ToInt32(Console.ReadLine());
            while (grænseværdi != -1)
            {
                fibIterative(grænseværdi);
                Console.WriteLine("Indtast grænseværdi eller -1 for at afslutte");
                grænseværdi = Convert.ToInt32(Console.ReadLine());
            }



        }
    }
}
