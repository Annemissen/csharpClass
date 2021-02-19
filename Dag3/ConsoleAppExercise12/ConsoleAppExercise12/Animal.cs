using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace ConsoleAppExercise12
{
    public class Animal : ClassLibrary1.MyExternalClass
    {
        public Animal(string name, string speciesClass, string race) : base(name)
        {
            SpeciesClass = speciesClass;
            Race = race;
        }

        public string SpeciesClass { get; }
        public string Race { get; }
    }
}
