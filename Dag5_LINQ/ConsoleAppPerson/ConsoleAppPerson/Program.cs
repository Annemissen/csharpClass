using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppPerson
{
    public static class Program
    {
        private static void Main(string[] args)
        {
            List<Person> people = Person.GetPeople();

            // ØVELSE 1 USING FINDALL

            //1. All persons with a score below 2
            //PeopleWithAScoreBelow2(people);

            //2. All persons with even score
            //PeopleWithAnEvenScore(people);

            //3. All persons with even score and weight above 60
            //PeopleWithAnEvenScoreAndWeightAbove60(people);

            //4. All persons with a weight divisible by 3
            //PeopleWithAWeightDivisableBy3(people);


            // -----------------------------------------------------
            // ØVELSE 2 USING FINDINDEX

            //5. Use the FindIndex method on the List < T > class to find the index of the first person with a Score of 3.
            int index = people.FindIndex((p) => p.Score == 3);
            Console.WriteLine("First person score == 3: " + people[index].ToString());

            //6. Use FindIndex to find the index of the first person under 10 years, with a score of 3.
            index = people.FindIndex((p) => p.Age < 10 && p.Score == 3);
            Console.WriteLine("First person age < 10 && score == 3: " + people[index].ToString());

            //7. How many people are there under 10 years, with a score of 3?
            int count = people.FindAll((p) => p.Age < 10 && p.Score == 3).Count;
            Console.WriteLine("Number of people under 10 years with a score of 3: " + count);

            //8. Use FindIndex to find the index of the first person under 8 years, with a score of 3.
            index = people.FindIndex((p) => p.Age < 8 && p.Score == 3);
            if (index >= 0)
            {
                Console.WriteLine(people.Count + " " + index);
            }
            else
            {
                Console.WriteLine("Matching person not found");
            }

            //9. What does the return value mean?

            // -----------------------------------------------------
            // ØVELSE 3 USING SORTING WITH List<T>.Sort()

            // Sort persons after both Score and Age, (both ascending and descending)

            // Ascending order score (stigende)
            people.Sort((p1, p2) => p1.Score - p2.Score);
            //people.ForEach(p => Console.WriteLine(p.ToString()));

            // Ascending order age (stigende)
            people.Sort((p1, p2) => p1.Age - p2.Age);
            //people.ForEach(p => Console.WriteLine(p.ToString()));

            // Descending order score (faldende)
            people.Sort((p1, p2) => p2.Score - p1.Score);
            //people.ForEach(p => Console.WriteLine(p.ToString()));

            // Descending order age (faldende)
            people.Sort((p1, p2) => p2.Age - p1.Age);
            //people.ForEach(p => Console.WriteLine(p.ToString()));

            // -----------------------------------------------------
            // ØVELSE 4: Write an extension method on the List<Person> class so you can make this call:
            //people.UpdatePeople(p => p.Score >= 6 && p.Age <= 40, (p) => { p.Accepted = true; });
            //Hint: Use a Predicate delegate and an Action delegate to solve this problem.
            people.UpdatePeople(p => p.Score >= 6 && p.Age <= 40, (p) => { p.Accecpted = true; });
            people.ForEach(p => Console.WriteLine(p.ToString()));

            Console.ReadLine();
        }


        private static void UpdatePeople(this List<Person> people, Predicate<Person> pre, Action<Person> act)
        {
           foreach(Person p in people)
            {
                if (pre(p))
                {
                    act(p);
                }
            }
        }

        private static void PeopleWithAScoreBelow2(List<Person> people)
        {
            List<Person> searchResult = people.FindAll((p) => p.Score < 2);
            Console.WriteLine("All persons with a score below 2");
            searchResult.ForEach(p => Console.WriteLine(p.ToString()));
        }

        private static void PeopleWithAnEvenScore(List<Person> people)
        {
            List<Person> searchResult = people.FindAll(p => p.Score % 2 == 0);
            Console.WriteLine("All persons with even score");
            searchResult.ForEach(p => Console.WriteLine(p.ToString()));
        }

        private static void PeopleWithAnEvenScoreAndWeightAbove60(List<Person> people)
        {
            List<Person> searchResult = people.FindAll(p => p.Score % 2 == 0 && p.Weight > 60);
            Console.WriteLine("All persons with even score and weight above 60");
            searchResult.ForEach(p => Console.WriteLine(p.ToString()));
        }

        private static void PeopleWithAWeightDivisableBy3(List<Person> people)
        {
            List<Person> searchResult = people.FindAll(p => p.Weight%3 == 0);
            Console.WriteLine("All persons with a weight divisable by 3");
            searchResult.ForEach(p => Console.WriteLine(p.ToString()));
        }
    }
}
