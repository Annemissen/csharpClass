using System;

namespace ConsoleAppTimeStruct
{
    class Program
    {
        static void Main(string[] args)
        {
            Time t1, t2;
            t1 = new Time("08:30:00");
            t2 = t1;
            t2.Hour = t2.Hour + 2;
            //textBox1.Text = t1.ToString();
            //textBox2.Text = t2.ToString();
            Console.WriteLine(t1.ToString());
            Console.WriteLine(t2.ToString());

        }
    }
    
    public struct Time
    {
        //private int SecondSinceMidnight;

        public Time (string time)
        {
            string[] timeStrings = time.Split(":");
            Hour = Int32.Parse(timeStrings[0]);
            Minute = Int32.Parse(timeStrings[1]);
            Second = Int32.Parse(timeStrings[2]);
        }

        public Time (int hour, int minute, int second)
        {
            Hour = hour;
            Minute = minute;
            Second = second;
        }

        public int Hour { get; set; }
        public int Minute { get; set; }
        public int Second { get; set; }

        public override string ToString()
        {
            string hourString;
            string Minutetring;
            string Secondtring;

            if (Hour < 10)
            {
                hourString = $"0{Hour}";
            }
            else
            {
                hourString = $"{Hour}";
            }

            if (Minute < 10)
            {
                Minutetring = $"0{Minute}";
            }
            else
            {
                Minutetring = $"{Minute}";
            }

            if (Second < 10)
            {
                Secondtring = $"0{Second}";
            }
            else
            {
                Secondtring = $"{Second}";
            }

            return $"{hourString}:{Minutetring}:{Secondtring}";

        }
    }
}
