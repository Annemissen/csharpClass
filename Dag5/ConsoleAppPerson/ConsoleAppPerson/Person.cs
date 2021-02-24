using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleAppPerson
{
    class Person
    {
        private bool accepted;

        public Person(string name, int age, double weight, int score)
        {
            Name = name;
            Age = age;
            Weight = weight;
            Score = score;
            this.accepted = false;
        }

        public Person(string data)
        {
            string[] dataArr = data.Split(';');
            Name = dataArr[0];
            Age = Int32.Parse(dataArr[1]);
            Weight = Double.Parse(dataArr[2]);
            Score = Int32.Parse(dataArr[3]);
        }

        public string Name { get; }
        public int Age { get; }
        public double Weight { get; set; }
        public int Score { get; set; }
        public bool Accecpted { get; set; }

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
            string acc = Accecpted ? "is accepted" : "is not accepted";
            return $"{Name} : {Age} years, {Weight} kg, {Score} points, {acc}";
        }
    }
}
