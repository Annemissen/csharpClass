using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppPoker
{
    class Player
    {
        public Player(int money, string name, List<Card> cards)
        {
            Money = money;
            Name = name;
            Cards = cards;
        }

        public int Money { get; }

        public string Name { get; }

        public List<Card> Cards { get; }
    }
}
