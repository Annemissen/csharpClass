using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class Calculator
    {
        public static int Add(int i, int j)
        {
            return i + j;
        }

        public static int Substract(int i, int j)
        {
            return i - j;
        }

        public static int Multiply(int i, int j)
        {
            return i * j;
        }

        public static double Divide(int i, int j)
        {
            return decimal.ToDouble(decimal.Divide(i, j));
        }
    }
}
