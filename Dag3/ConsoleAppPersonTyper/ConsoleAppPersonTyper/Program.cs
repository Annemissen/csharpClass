using System;

namespace ConsoleAppPersonTyper
{

    class Program
    {

        static void Main(string[] args)
        {
            Person person = new Person("Anders", "Finlandsgade 18");
            person.print();

            Mekaniker m = new Mekaniker("Jonas", "Nødkjær Allé 13", 1994, 100);
            
            m.Navn = "Jonas Jensen";
            m.Adresse = "Helsingforsgade 13";
            m.print();

            Værkfører vf = new Værkfører("Hr. Værkfører", "Hr. Værkførervej 73", 1987, 100, 1997, 25);
            vf.print();
            vf.TillægPrUge = 50;
            vf.print();

            Synsmand sm = new Synsmand("Hr. Synsmand", "Hr. Synsmandsvej 86", 2005, 100);
            sm.print();
            sm.AntalSynDenneUge = 10;
            sm.print();
        }
    }



}
