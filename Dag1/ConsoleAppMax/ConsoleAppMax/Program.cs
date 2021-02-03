using System;

namespace ConsoleAppMax
{
    class Program
    {
        /**
         *  It should be possible to call the method, Max, with a random number of double-parameter as shown in the code. 
         *  Complete the declaration of Max
         */
        public static double Max(params double[] values)
        {
            double result = values[0];
            foreach (double value in values)
            {
                if (value > result)
                {
                    result = value;
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            double m1 = Max(28.5, 17.2);
            double m2 = Max(4.0, 10.8, 34.25, 2.0, 23.6);

            Console.WriteLine(m1 + " " + m2);
            Console.ReadLine();
        }
    }
}
