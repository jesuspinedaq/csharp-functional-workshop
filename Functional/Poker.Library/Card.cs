using System;

namespace Poker.Library
{
    public class Card: IComparable<Card>
    {
        public Rank Rank { get; }
        public Suit Suit { get; }

        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public int CompareTo(Card other) => Rank.CompareTo(other.Rank);

    }
}