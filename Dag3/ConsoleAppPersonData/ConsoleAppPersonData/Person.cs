using System;
using System.Collections.Generic;
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

        public override string ToString()
        {
            return $"{Name} : {Age} years, {Weight} kg";
        }
    }


}
