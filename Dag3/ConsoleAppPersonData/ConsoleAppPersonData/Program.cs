using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleAppPersonData
{
    class Program
    {
        static void Main(string[] args)
        {
            // Making the list of people
            List<Person> people = MakePersonList();

            //Excercise8To10(people);

            // ----------------------------------------------------
            // PEOPLE CLASS TESTING FOR EXERCISE 11
            Exercise11(people);
        }

        static void PrintPersonList(List<Person> people)
        {
            foreach (Person person in people)
            {
                Console.WriteLine(person.ToString());
            }
        }

        static List<Person> MakePersonList()
        {
            Person p1 = new Person("Hanne", 66, 77.5);
            Person p2 = new Person("Ronja;12;40");
            Person p3 = new Person("Saul;60;63");
            Person p4 = new Person("Søren;27;90");
            Person p5 = new Person("Dorte;57;70");
            Person p6 = new Person("Henrik;64;89");
            Person p7 = new Person("Anders;24;66");

            List<Person> people = new List<Person>(new Person[] {p1, p2, p3, p4, p5, p6, p7});

            return people;
        }

        static void Excercise8To10(List<Person> people)
        {
            Console.WriteLine("Orignal:");
            PrintPersonList(people);
            Console.WriteLine();

            // EXPLAIN: Explain the behavior of this call: people.Sort((p1, p2) => p1.Age.CompareTo(p2.Age));
            /**
             * Sort er en extension method. Den 
             */

            people.Sort((p1, p2) => p2.Age.CompareTo(p1.Age));
            //PrintPersonList(people);

            //EXPLAIN
            //people.Sort(new SortByAge());


            // Finding the four oldest people
            List<Person> fourOldestPeople = people.OrderByDescending(p => p.Age).Take(4).ToList();
            Console.WriteLine("Four oldest people");
            PrintPersonList(fourOldestPeople);
            Console.WriteLine();

            // Finding the four youngest people
            List<Person> fourYoungestPeople = people.OrderBy(p => p.Age).Take(4).ToList();
            Console.WriteLine("Four youngest people");
            PrintPersonList(fourYoungestPeople);
        }

        static void Exercise11(List<Person> peopleList)
        {

            // AddPerson()
            People peopleDictionary = new People();
            foreach (Person p in peopleList)
            {
                peopleDictionary.AddPerson(p.Name, p);
            }

            Person hanne = new Person("Hanne", 98, 60);
            bool res = peopleDictionary.AddPerson(hanne.Name, hanne);
            Console.WriteLine("Should be false: " + res);
            Person jens = new Person("Jens", 54, 101);
            res = peopleDictionary.AddPerson(jens.Name, jens);
            Console.WriteLine("Should be true: " + res);

            // GetPerson()
            Person dorte = peopleDictionary.GetPerson("Dorte");
            Console.WriteLine(dorte.ToString());
            Person test = peopleDictionary.GetPerson("Rikke");
            Console.WriteLine(test);

            // Size()
            Console.WriteLine("Should be 8: " + peopleDictionary.Size());
        }

    }
}
