using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleAppPoker
{
    class Game
    {
        private List<Card> deck;
        
        public Game(string[] players, string gameID)
        {
            Players = MakePlayers(players);
            deck = MakeDeck();
            GameID = gameID;
        }

        public string GameID { get; }

        public List<Player> Players { get; }

        public List<Card> MakeDeck()
        {
            List<Card> deck = new List<Card>();
            foreach (Card.CardColor color in Enum.GetValues(typeof (Card.CardColor))){

                foreach (Card.CardNumber number in Enum.GetValues(typeof(Card.CardNumber)))
                {
                    Card c = new Card(color, number);
                    deck.Add(c);
                }
            }

            return deck;
        }

        public List<Player> MakePlayers(string[] names) 
        {
            List<Player> players = new List<Player>();
            foreach (string name in names)
            {
                Player p = new Player(100, name);
                players.Add(p);
            }
            return players;
        }
    }
}
