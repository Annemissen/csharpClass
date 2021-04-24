using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCard
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck deck = new Deck();

            Console.WriteLine("BEFORE SORTING");
            deck.PrintDeck();

            Console.WriteLine("AFTER NUMBER SORTING");
            Deck.SortDeck(deck, NumberComparing);
            deck.PrintDeck();

            Console.WriteLine("AFTER SUIT SORTING");
            Deck.SortDeck(deck, SuitComparing);
            deck.PrintDeck();

            Console.ReadKey();
        }

        public static int SuitComparing(Card e1, Card e2)
        {
            return e1.Color.CompareTo(e2.Color);
        }

        public static int NumberComparing(Card e1, Card e2)
        {
            return e1.Number.CompareTo(e2.Number);
        }
    }
}
