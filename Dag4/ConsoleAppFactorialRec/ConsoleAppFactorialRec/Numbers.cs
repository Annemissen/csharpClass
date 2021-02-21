using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppFactorialRec
{
    public class Numbers
    {
        private int[] numbers;

        public Numbers()
        {
            Random random = new Random();
            int[] randomNumbers = new int[10];
            for (int i = 0; i < randomNumbers.Length; i++)
            {
                randomNumbers[i] = random.Next(0, 100);
            }
            this.numbers = randomNumbers;
        }

        public int[] GetNumbers()
        {
            return numbers;
        }

        //private void SetNumbers(int[] value)
        //{
        //    numbers = value;
        //}

        public void Sort()
        {
            Comparator c = Compare;
            SortArray(this.numbers, c);
        }

        public bool Compare(int e1, int e2)
        {
            return e1 > e2 ? true : false;
        }

        // vi skal bruge Comparator til at vælge mellem stigende og faldende orden
        public delegate bool Comparator(int e1, int e2);

        // sorter array ved hjælp af Comparator delegate
        public static void SortArray(int[] array, Comparator Compare)
        {
            for (int i = array.Length - 1; i >= 0; i--)
            {
                for (int j = 0; j <= i - 1; j++)
                {
                    if (Compare(array[j], array[j+1])) //array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        public void PrintNumbers()
        {
            string s = "[";
            for (int i = 0; i < this.numbers.Length; i++)
            {
                //Console.Write(this.numbers[i]);
                s += numbers[i] + ", ";
            }
            s += "]";
            Console.WriteLine(s);
        }

    }
}
