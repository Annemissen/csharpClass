using System;

namespace ConsoleAppRandomNumberArr
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Indtast hvor mange tilfældige tal der skal genereres");
            int arrSize = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Indtast startværdi for spændet af tallene");
            int start = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Indtast slutværdi for spændet af tallene");
            int end = Convert.ToInt32(Console.ReadLine());
            end = end + 1;
            Console.WriteLine("end test (should be one greater than input value): " + end);

            // Creating the random number generator
            Random rnd = new Random();

            // Creating the array for the random values
            int[] resultArr = new int[arrSize];

            for (int i = 0; i < arrSize; i++)
            {
                resultArr[i] = rnd.Next(start, end);
            }

            for (int i = 0; i < resultArr.Length; i++)
            {
                Console.Write(resultArr[i] + " ");
            }

        }
    }
}
