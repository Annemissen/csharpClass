using DelegateExercises;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises {
    class Program {
        static void Main(string[] args) {



            PersonUserClass.Main(args);


            Console.WriteLine("Press Enter to return from Main");
            Console.ReadKey();
        }

        public void PrintFullNameLastNameFirst(Person p)
        {
            Console.WriteLine($"{p.LastName}, {p.FirstName}");
        }

        public static string PrintFullNameAllCaps(Person p)
        {
            return $"{p.LastName.ToUpper()}, {p.FirstName.ToUpper()}";
        }

        public void PrintFullNameLowerCase(Person p)
        {
            Console.WriteLine($"{p.LastName.ToLower()}, {p.FirstName.ToLower()}");
        }

        public void PrintShortName(Person p)
        {
            Console.WriteLine($"{p.FirstName.Substring(0, 1)}. {p.LastName}");
        }
    }
}
