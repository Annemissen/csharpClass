using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppPoker
{
    public class Card
    {
        public Card(CardColor color, CardNumber number)
        {
            Color = color;
            Number = number;
        }

        public CardColor Color {get;}
        public CardNumber Number {get;}

        public enum CardColor
        {
            Clubs,
            Diamonds,
            Hearts,
            Spades
        }

        public enum CardNumber
        {
            Ace,
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King
        }
    }
}
