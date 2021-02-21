using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFactorialRec
{
    public static class MathExtensions
    {
        public static int Factorial(this int n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
            {
                return n * Factorial(n - 1);
            }
        }

        public static int Power(this int n, int p)
        {
            if (p == 1)
            {
                return n;
            }
            else
            {
                return n * Power(n, p - 1);
            }
        }
    }
}
