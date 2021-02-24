using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppPersonLinq
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            List<Person> people = Person.GetPeople();

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

            // EXERCISE 9: HARDER PROBLEM
            // 1. Sorting people by distance to the average Age
            //SortingByAverageAgeDist(people);

            // 2. Sort the people by size of their Dwa 
            var orderedPeople = people.OrderBy(p => p.GetDWA());
            //foreach (Person p in orderedPeople) Console.WriteLine(p.ToString());


            // EXERCISE 11: Write an extension method on the List<Person> class so you can make this call: people.Reset();
            //The call must set person.Accepted = false for all people on the list.
            people.Reset();
            people.ForEach(p => Console.WriteLine(p.ToString()));

            Console.ReadLine();
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
