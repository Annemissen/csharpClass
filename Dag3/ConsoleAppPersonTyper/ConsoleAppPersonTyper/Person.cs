using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppPersonTyper
{
    /**
     * For personer registreres navn og adresse. Det skal være muligt både at opdatere og hente navn og adresse.
     */
    public class Person
    {
        public Person(string nyNavn, string nyAdresse)
        {
            Navn = nyNavn;
            Adresse = nyAdresse;
        }

        public string Navn { get; set; }

        public string Adresse { get; set; }

        public virtual void print()
        {
            Console.WriteLine($"Navn: {Navn}, Adr: {Adresse}");

        }
    }


}
