using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvedExercises {

    public partial class Person : INotifyPropertyChanged
    {

        private string name;
        private int age;
        private int weight;
        private int score;
        private bool accepted;
        private static PersonDbContext _personDbContext = null;

        public Person(string data)
        {
            // Name, Age, Weight, Score, Accepted
            var L = data.Split(';');

            Name = L[0];
            Age = int.Parse(L[1]);
            Weight = int.Parse(L[2]);
            Score = int.Parse(L[3]);
            Accepted = bool.Parse(L[4]);
        }

        public string Name
        {
            get { return name; }
            set { name = value; NotifyPropertyChanged(nameof(Name)); }
        }

        public int Age
        {
            get { return age; }
            set { age = value; NotifyPropertyChanged(nameof(Age)); }
        }

        public int Weight
        {
            get { return weight; }
            set { weight = value; NotifyPropertyChanged(nameof(Weight)); }
        }

        public int Score
        {
            get { return score; }
            set
            {
                if (value < 0 || value > 10)
                    return;
                score = value; NotifyPropertyChanged(nameof(Score));
            }
        }

        public bool Accepted
        {
            get { return accepted; }
            set { accepted = value; NotifyPropertyChanged(nameof(Accepted)); }
        }

        public override string ToString()
        {
            return String.Format("{0,-10} : {1,4} points, {2,4} years, {3,4} kg, {4,4} Accepted", Name, Score, Age, Weight, Accepted ? "" : "NOT");
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public static List<Person> ReadCSVFile(string filename)
        {
            List<Person> list = new List<Person>();
            using (var file = new StreamReader(filename))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    var p = new Person(line);
                    list.Add(p);
                }
            }
            return list;
        }

        public class SortByAge : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                return x.Age.CompareTo(y.Age);
            }
        }
        public class SortByScore : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                return x.Score.CompareTo(y.Score);
            }
        }
        public class SortByWeight : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                return x.Weight.CompareTo(y.Weight);
            }
        }
        public class SortByName : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                return x.Name.CompareTo(y.Name);
            }
        }
        public class SortByAgeDistance : IComparer<Person>
        {
            private double age;
            public SortByAgeDistance(double age)
            {
                this.age = age;
            }
            public int Compare(Person x, Person y)
            {
                double xdist = Math.Abs(x.Age - age);
                double ydist = Math.Abs(y.Age - age);
                return xdist.CompareTo(ydist);
            }
        }
        public class SortByWeightAgeLength : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                double xval = Math.Sqrt(x.Weight * x.Weight + x.Age * x.Age);
                double yval = Math.Sqrt(y.Weight * y.Weight + y.Age * y.Age);
                return xval.CompareTo(yval);
            }
        }

        public static PersonDbContext getPersonDbContext()
        {
            if (_personDbContext == null)
                _personDbContext = new PersonDbContext();
            return _personDbContext;
        }

        public static ObservableCollection<Person> GetPeople()
        {

            var list = new ObservableCollection<Person>();

            //Load all data from database
            foreach (var p in getPersonDbContext().PersonSet)
            {
                list.Add(p);
            }
            if (list.Count > 0)
            {
                return list;
            }
            else
            {
                //Initiate database content if database is empty
                getPersonDbContext().PersonSet.Add(new Person("Saul;60;63;7;false"));
                getPersonDbContext().PersonSet.Add(new Person("Mel;9;117;5;false"));
                getPersonDbContext().PersonSet.Add(new Person("Preston;50;100;10;false"));
                getPersonDbContext().PersonSet.Add(new Person("Evan;23;28;2;false"));
                getPersonDbContext().PersonSet.Add(new Person("Alison;24;93;4;false"));
                getPersonDbContext().PersonSet.Add(new Person("Nikia;90;110;7;false"));
                getPersonDbContext().PersonSet.Add(new Person("Micheal;15;10;10;false"));
                getPersonDbContext().PersonSet.Add(new Person("Brittany;21;83;8;false"));
                getPersonDbContext().PersonSet.Add(new Person("Ward;18;17;2;false"));
                getPersonDbContext().PersonSet.Add(new Person("Elmo;46;105;5;false"));
                getPersonDbContext().PersonSet.Add(new Person("Bertram;60;88;6;false"));
                getPersonDbContext().PersonSet.Add(new Person("Cristin;31;86;7;false"));
                getPersonDbContext().PersonSet.Add(new Person("Monroe;12;49;2;false"));
                getPersonDbContext().PersonSet.Add(new Person("Aundrea;16;42;3;false"));
                getPersonDbContext().PersonSet.Add(new Person("Ayanna;67;60;10;false"));
                getPersonDbContext().PersonSet.Add(new Person("Lucio;51;102;1;false"));
                getPersonDbContext().PersonSet.Add(new Person("Armando;93;105;3;false"));
                getPersonDbContext().PersonSet.Add(new Person("Audrie;56;42;5;false"));
                getPersonDbContext().PersonSet.Add(new Person("Mirtha;56;45;7;false"));
                getPersonDbContext().PersonSet.Add(new Person("Voncile;20;28;0;false"));
                getPersonDbContext().PersonSet.Add(new Person("Chae;80;13;0;false"));
                getPersonDbContext().PersonSet.Add(new Person("Halina;97;71;7;false"));
                getPersonDbContext().PersonSet.Add(new Person("Alex;13;42;5;false"));
                getPersonDbContext().PersonSet.Add(new Person("Adan;99;100;5;false"));
                getPersonDbContext().PersonSet.Add(new Person("Natashia;18;92;9;false"));
                getPersonDbContext().PersonSet.Add(new Person("Forrest;66;102;2;false"));
                getPersonDbContext().PersonSet.Add(new Person("Taina;9;96;9;false"));
                getPersonDbContext().PersonSet.Add(new Person("Simon;83;75;10;false"));
                getPersonDbContext().PersonSet.Add(new Person("Kory;46;82;8;false"));
                getPersonDbContext().PersonSet.Add(new Person("Tinisha;65;89;9;false"));
                getPersonDbContext().PersonSet.Add(new Person("Denny;38;116;2;false"));
                getPersonDbContext().PersonSet.Add(new Person("Harriette;52;67;9;false"));
                getPersonDbContext().PersonSet.Add(new Person("Conrad;14;114;2;false"));
                getPersonDbContext().PersonSet.Add(new Person("Jeanie;65;72;4;false"));
                getPersonDbContext().PersonSet.Add(new Person("Mose;5;79;4;false"));
                getPersonDbContext().PersonSet.Add(new Person("Stefan;77;47;9;false"));
                getPersonDbContext().PersonSet.Add(new Person("Wade;69;7;7;false"));
                getPersonDbContext().PersonSet.Add(new Person("Andrew;43;77;2;false"));
                getPersonDbContext().PersonSet.Add(new Person("Shameka;35;82;4;false"));
                getPersonDbContext().PersonSet.Add(new Person("Kenna;22;87;3;false"));
                getPersonDbContext().PersonSet.Add(new Person("Columbus;85;101;3;false"));
                getPersonDbContext().PersonSet.Add(new Person("Denna;98;94;4;false"));
                getPersonDbContext().PersonSet.Add(new Person("Stephanie;38;77;9;false"));
                getPersonDbContext().PersonSet.Add(new Person("Rigoberto;78;90;8;false"));
                getPersonDbContext().PersonSet.Add(new Person("Jamila;87;5;9;false"));
                getPersonDbContext().PersonSet.Add(new Person("Seymour;48;58;9;false"));
                getPersonDbContext().PersonSet.Add(new Person("Warner;31;19;2;false"));
                getPersonDbContext().PersonSet.Add(new Person("Tommie;99;104;4;false"));
                getPersonDbContext().PersonSet.Add(new Person("Emma;17;51;8;false"));
                getPersonDbContext().PersonSet.Add(new Person("Tim;70;71;8;false"));
                getPersonDbContext().PersonSet.Add(new Person("Marhta;75;34;5;false"));
                getPersonDbContext().PersonSet.Add(new Person("Joshua;21;13;7;false"));
                getPersonDbContext().PersonSet.Add(new Person("Luigi;9;84;3;false"));
                getPersonDbContext().PersonSet.Add(new Person("Vito;58;14;8;false"));
                getPersonDbContext().PersonSet.Add(new Person("Marquis;59;7;3;false"));
                getPersonDbContext().PersonSet.Add(new Person("Kaci;29;6;6;false"));
                getPersonDbContext().PersonSet.Add(new Person("Necole;18;108;4;false"));
                getPersonDbContext().PersonSet.Add(new Person("Samella;25;69;2;false"));
                getPersonDbContext().PersonSet.Add(new Person("Hang;82;64;9;false"));
                getPersonDbContext().PersonSet.Add(new Person("Asuncion;30;99;0;false"));
                getPersonDbContext().PersonSet.Add(new Person("Enoch;83;119;6;false"));
                getPersonDbContext().PersonSet.Add(new Person("Andreas;90;120;1;false"));
                getPersonDbContext().PersonSet.Add(new Person("Doyle;21;75;7;false"));
                getPersonDbContext().PersonSet.Add(new Person("Loree;66;52;0;false"));
                getPersonDbContext().PersonSet.Add(new Person("Trudie;55;86;6;false"));
                getPersonDbContext().PersonSet.Add(new Person("Jon;52;104;2;false"));
                getPersonDbContext().PersonSet.Add(new Person("Chantay;59;6;9;false"));
                getPersonDbContext().PersonSet.Add(new Person("Gwenda;15;37;5;false"));
                getPersonDbContext().PersonSet.Add(new Person("Piper;50;56;2;false"));
                getPersonDbContext().PersonSet.Add(new Person("Sabine;5;44;4;false"));
                getPersonDbContext().PersonSet.Add(new Person("Saturnina;67;62;1;false"));
                getPersonDbContext().PersonSet.Add(new Person("Dovie;81;35;9;false"));
                getPersonDbContext().PersonSet.Add(new Person("Nick;1;74;7;false"));
                getPersonDbContext().PersonSet.Add(new Person("Roxanne;86;82;3;false"));
                getPersonDbContext().PersonSet.Add(new Person("Francisco;88;23;10;false"));
                getPersonDbContext().PersonSet.Add(new Person("Galina;89;34;3;false"));
                getPersonDbContext().PersonSet.Add(new Person("Shirley;100;81;8;false"));
                getPersonDbContext().PersonSet.Add(new Person("Nada;71;113;2;false"));
                getPersonDbContext().PersonSet.Add(new Person("Jamee;64;66;0;false"));
                getPersonDbContext().PersonSet.Add(new Person("Tona;35;103;5;false"));
                getPersonDbContext().PersonSet.Add(new Person("Valencia;77;30;10;false"));
                getPersonDbContext().PersonSet.Add(new Person("Gavin;63;93;0;false"));
                getPersonDbContext().PersonSet.Add(new Person("Jean;20;120;9;false"));
                getPersonDbContext().PersonSet.Add(new Person("Darrel;28;11;10;false"));
                getPersonDbContext().PersonSet.Add(new Person("Boris;3;94;0;false"));
                getPersonDbContext().PersonSet.Add(new Person("Alverta;85;12;5;false"));
                getPersonDbContext().PersonSet.Add(new Person("Otto;71;24;8;false"));
                getPersonDbContext().PersonSet.Add(new Person("Hermelinda;81;118;0;false"));
                getPersonDbContext().PersonSet.Add(new Person("Jeffrey;78;45;6;false"));
                getPersonDbContext().PersonSet.Add(new Person("Lon;13;120;5;false"));
                getPersonDbContext().PersonSet.Add(new Person("Stuart;73;101;8;false"));
                getPersonDbContext().PersonSet.Add(new Person("Marcel;1;8;4;false"));
                getPersonDbContext().PersonSet.Add(new Person("Zita;100;59;5;false"));
                getPersonDbContext().PersonSet.Add(new Person("Damion;48;40;4;false"));
                getPersonDbContext().PersonSet.Add(new Person("Dona;54;109;4;false"));
                getPersonDbContext().PersonSet.Add(new Person("Elli;57;68;5;false"));
                getPersonDbContext().PersonSet.Add(new Person("Luther;86;76;4;false"));
                getPersonDbContext().PersonSet.Add(new Person("Alica;61;31;2;false"));
                getPersonDbContext().PersonSet.Add(new Person("Aletha;37;63;3;false"));
                getPersonDbContext().PersonSet.Add(new Person("Amina;41;105;7;false"));

                getPersonDbContext().SaveChanges();

                foreach (var p in getPersonDbContext().PersonSet)
                {
                    list.Add(p);
                }

                return list;
            }
        }
    }

}
