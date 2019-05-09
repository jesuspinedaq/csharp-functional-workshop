using System;

namespace Poker.Library
{
    public class Card: IComparable<Card>
    {
        public Rank Rank { get; set; }
        public Suit Suit { get; set; }

        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public int CompareTo(Card other)
        {
            return Rank.CompareTo(other.Rank);
        }
    }
}