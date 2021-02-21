using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ConsoleAppPersonData
{
    /**
     * Write a class Person with Name, Age and Weight properties.
     */
    class Person
    {
        public Person(string name, int age, double weight)
        {
            Name = name;
            Age = age;
            Weight = weight;
        }

        public Person(string data)
        {
            string[] dataArr = data.Split(";");
            Name = dataArr[0];
            Age = Int32.Parse(dataArr[1]);
            Weight = Double.Parse(dataArr[2]);
        }

        public string Name { get; }
        public int Age { get; }
        public double Weight { get; set; }

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

        public override string ToString()
        {
            return $"{Name} : {Age} years, {Weight} kg";
        }
    }


}
