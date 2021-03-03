using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppEventClassExercises
{
    class Program
    {
        static void Main(string[] args)
        {

            EventClass.CountCharsInThreeDiffStrings();
            Console.WriteLine("hejhej".DelegateUser(EventClass.CountChars));
            Console.ReadLine();
        }
    }
}
