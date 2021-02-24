using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppPersonLinq
{
    class Person
    {
        public Person(string name, int age, int weight, int score)
        {
            Name = name;
            Age = age;
            Weight = weight;
            Score = score;
            Accepted = score >= 5;
        }

        public Person(string data)
        {
            string[] dataArr = data.Split(';');
            Name = dataArr[0];
            Age = Int32.Parse(dataArr[1]);
            Weight = Int32.Parse(dataArr[2]);
            Score = Int32.Parse(dataArr[3]);
            Accepted = Score >= 5;
        }

        public string Name { get; }
        public int Age { get; }
        public int Weight { get; set; }
        public int Score { get; set; }
        public bool Accepted { get; set; }

        public double GetDWA()
        {
            return Math.Sqrt(Math.Pow(Weight, 2) + Math.Pow(Age, 2));
        }

        public static List<Person> ReadCSVFile(string filename)
        {
            List<Person> people = new List<Person>();
            using (var file = new StreamReader(filename))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    //Console.WriteLine(line);
                    Person p = new Person(line);
                    people.Add(p);
                }
            }

            return people;
        }

        public static List<Person> GetPeople()
        {
            return ReadCSVFile(Directory.GetCurrentDirectory() + "/../../data1.csv");
        }

        public override string ToString()
        {
            string acc = Accepted ? "is accepted" : "is not accepted";
            return $"{Name} : {Age} years, {Weight} kg, {Score} points, {acc}";
        }
    }
}
