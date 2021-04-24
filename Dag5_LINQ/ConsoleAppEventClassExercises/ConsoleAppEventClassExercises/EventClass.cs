using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEventClassExercises
{
    public static class EventClass
    {
        private static StringToInt stringToInt = CountChars;

        public delegate int StringToInt(string s);

        public static int CountChars(string s)
        {
            return s.ToCharArray().Where(c => !Char.IsWhiteSpace(c)).Count();
        }

        public static void CountCharsInThreeDiffStrings()
        {
            Console.WriteLine(stringToInt("hej"));
            Console.WriteLine(stringToInt("hej hej"));
            Console.WriteLine(stringToInt("hejhej"));
        }

        public static int DelegateUser(this string s, StringToInt del)
        {
            return del(s);
        }
    }
}
