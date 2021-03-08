using System;
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

namespace WpfAppPersonList
{
    public class Person : INotifyPropertyChanged
    {
        private bool accepted;
        private string name;
        private string score;

        public Person(string name, int age, double weight, string score)
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
            Score = dataArr[3];
        }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }
        public int Age { get; }
        public double Weight { get; set; }
        public string Score
        {
            get { return score; }
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

        public string ListBoxToString
        {
            get
            {
                return Name + ", " + Age + " years old";
            }
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
        private List<Person> peopleData;

        public MainWindow()
        {
            InitializeComponent();

            // List stuff
            peopleData = initPeople();
            listViewPerson.ItemsSource = peopleData;
            gridOuter.DataContext = peopleData;
        }

        private List<Person> initPeople()
        {
            List<Person> people = new List<Person>();

            Person p1 = new Person("Dorte", 20, 70, "5");
            people.Add(p1);

            Person p2 = new Person("Jens", 50, 100, "2");
            people.Add(p2);

            Person p3 = new Person("Nina", 25, 60, "10");
            people.Add(p3);

            Person p4 = new Person("Hans", 77, 70, "9");
            people.Add(p4);

            Person p5 = new Person("Henrik", 31, 80, "10");
            people.Add(p5);

            Person p6 = new Person("Anna", 7, 40, "5");
            people.Add(p6);

            return people;
        }
    }
}
