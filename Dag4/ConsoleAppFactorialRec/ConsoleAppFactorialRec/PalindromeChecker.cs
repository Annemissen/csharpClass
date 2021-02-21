using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFactorialRec
{
    public static class PalindromeChecker
    {
        public static bool IsPalindrom(this string tekst)
        {
            char[] letters = tekst.ToCharArray();
            int mid = letters.Length / 2;

            Stack<char> charStack = new Stack<char>();
            for (int i = 0; i < mid; i++)
            {
                charStack.Push(letters[i]);
            }

            if (letters.Length % 2 != 0)
            {
                mid++;
            }

           for (int m = mid; m < letters.Length; m++)
            {
                if (letters[m] != charStack.Pop())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
