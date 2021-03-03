using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppPersonLinq
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            List<Person> people = Person.GetPeople(Directory.GetCurrentDirectory() + "/../../data1.csv");

            // EXERCISE 8: LINQ
            // Sorted by age in ascending order
            var s = people.OrderBy(p => p.Age);
            //foreach (Person p in s) Console.WriteLine(p.ToString());

            // Sorted by score in ascending order
            s = people.OrderBy(p => p.Score);
            //s.ToList<Person>().ForEach(p => Console.WriteLine(p.ToString()));

            // Sorted by age in descending order
            s = people.OrderByDescending(p => p.Age);
            //foreach (Person p in s) Console.WriteLine(p.ToString());

            // Sorted by score in descending order
            s = people.OrderByDescending(p => p.Score);
            //foreach (Person p in s) Console.WriteLine(p.ToString());

            // -----------------------------------------------------
            // EXERCISE 9: HARDER PROBLEM
            // 1. Sorting people by distance to the average Age
            //SortingByAverageAgeDist(people);

            // 2. Sort the people by size of their Dwa 
            var orderedPeople = people.OrderBy(p => p.GetDWA());
            //foreach (Person p in orderedPeople) Console.WriteLine(p.ToString());

            // -----------------------------------------------------
            // EXERCISE 11: Write an extension method on the List<Person> class so you can make this call: people.Reset();
            //The call must set person.Accepted = false for all people on the list.
            people.Reset();
            //people.ForEach(p => Console.WriteLine(p.ToString()));

            // -----------------------------------------------------
            // EXERCISE 13: Use LINQ to group people by the first letter in their names.
            //Exercise13GruopPeopleByFirstLetterInName(people);

            // -----------------------------------------------------
            // EXERCISE 14: Find all names that occur in both data1.csv and data2.csv
            List<Person> people1 = Person.GetPeople(Directory.GetCurrentDirectory() + "/../../data2.csv");
            List<string> intersectingPeople = FindPeopleWithIntersectingNames(people, people1);
            intersectingPeople.ForEach(p => Console.WriteLine(p.ToString()));


            Console.ReadLine();
        }

        private static List<string> FindPeopleWithIntersectingNames(List<Person> people1, List<Person> people2)
        {
            var res =
                from peopleX in people1
                join peopleY in people2
                on peopleX.Name equals peopleY.Name
                select peopleX.Name;

            /*
            var res =
                from peopleX in people1
                from peopleY in people2
                where peopleX.Name == peopleY.Name
                select peopleX.Name;
                };
             */

            return res.ToList();
        }

        private static void Exercise13GruopPeopleByFirstLetterInName(List<Person> people)
        {
            var groups = people.GroupBy(p => p.Name.Substring(0, 1));
            foreach (var group in groups)
            {
                Console.WriteLine("Group name: " + group.Key);
                foreach (Person p in group)
                {
                    Console.WriteLine(p.ToString());
                }
            }
        }

        private static void SortingByAverageAgeDist(List<Person> people)
        {
            var averageAge = (from p in people select p.Age).Average();
            var s = people.OrderBy(p => Math.Abs(p.Age - averageAge));
            Console.WriteLine("The average age is: " + averageAge);
            foreach (Person p in s) Console.WriteLine(p.ToString());

        }

        private static void Reset(this List<Person> people)
        {
            people.ForEach(p => p.Accepted = false);
        }
    }
}
