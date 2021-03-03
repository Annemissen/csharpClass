﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppPerson
{
    public class Person : INotifyPropertyChanged
    {
        private bool accepted;
        private string name;
        private int score;

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

        public string Name 
        { 
            get { return name; } 
            set { 
                name = value;
                NotifyPropertyChanged("Name");
            }
        }
        public int Age { get; }
        public double Weight { get; set; }
        public int Score 
        { 
            get { return score;}
            set
            {
                score = value;
                NotifyPropertyChanged("Score");
            }
        }
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

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Person person;
        public MainWindow()
        {
            person = new Person("Hanne", 30, 70, 10);
            InitializeComponent();

            // Labels
            ageLbl.Content = person.Age;
            weightLbl.Content = person.Weight;
            acceptedLbl.Content = person.Accecpted;

            txtBoxName.Text = person.Name;
            nameLbl.DataContext = person;

            txtBoxScore.Text = person.Score.ToString();
            scoreLbl.DataContext = person;
        }

        public Person Person { get; set; }

        private void NameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (person != null)
                person.Name = ((TextBox)sender).Text;
        }

        private void TxtBoxScore_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (person != null)
                person.Score = Int32.Parse(((TextBox)sender).Text);
        }
    }
}
