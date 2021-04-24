using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCard
{
    public class Deck
    {
        private List<Card> deck;
        
        public Deck()
        {
            this.deck = MakeDeck();
        }

        private List<Card> MakeDeck()
        {
            List<Card> deck = new List<Card>();
            foreach (Card.CardColor color in Enum.GetValues(typeof(Card.CardColor)))
            {

                foreach (Card.CardNumber number in Enum.GetValues(typeof(Card.CardNumber)))
                {
                    Card c = new Card(color, number);
                    deck.Add(c);
                }
            }

            return deck;
        }

        public List<Card> GetDeck()
        { 
            return this.deck; 
        }

        public delegate int Comparator(Card e1, Card e2);

        public static void SortDeck(Deck deck, Comparator comparator)
        {
            for (int i = deck.GetDeck().Count - 1; i >= 0; i--)
            {
                for (int j = 0; j <= i - 1; j++)
                {
                    if (comparator(deck.GetDeck()[j], deck.GetDeck()[j + 1]) >= 0) //array[j] > array[j + 1])
                    {
                        Card temp = deck.GetDeck()[j];
                        deck.GetDeck()[j] = deck.GetDeck()[j + 1];
                        deck.GetDeck()[j + 1] = temp;
                    }
                }
            }
        }

        public void PrintDeck()
        {
            int counter = 0;
            string s = "";
            foreach (Card c in GetDeck())
            {
                if (counter < 4)
                {
                    s += " " + c.ToString();
                    counter++;
                }
                else
                {
                    Console.WriteLine(s);
                    counter = 1;
                    s = c.ToString();
                }
            }
        }

    }
}
