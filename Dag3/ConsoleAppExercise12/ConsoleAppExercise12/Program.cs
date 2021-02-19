using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace ConsoleAppExercise12
{
    class Program
    {
        static void Main(string[] args)
        {
            Animal a = new Animal("Dog", "Mammal", "Cockerspaniel");
            Console.WriteLine(a.Name);
        }
    }
}
