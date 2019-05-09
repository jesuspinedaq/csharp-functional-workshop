using System.Collections.Generic;

namespace Poker.Library
{
    public class Poker
    {
        public Card HighCard(List<Card> cards)
        {
            cards.Sort();
            return cards[cards.Count - 1];
        }

        public bool IsPair(List<Card> cards)
        {
            cards.Sort();
            /* --------------------------------
             Checking: a a x y z
            -------------------------------- */
            if (cards[0].Rank == cards[1].Rank)
            {
                return true;
            }
            /* --------------------------------
            Checking: x a a y z
            -------------------------------- */
            else if (cards[1].Rank == cards[2].Rank)
            {
                return true;
            }
            /* --------------------------------
            Checking: x y a a z
            -------------------------------- */
            else if (cards[2].Rank == cards[3].Rank)
            {
                return true;
            }
            /* --------------------------------
            Checking: x y z a a
            -------------------------------- */
            else if (cards[3].Rank == cards[4].Rank)
            {
                return true;
            }

            return false;
        }

        public bool IsTwoPair(List<Card> cards)
        {
            cards.Sort();
            /* --------------------------------
            Checking: a a  b b x
            -------------------------------- */
            var a1 = cards[0].Rank == cards[1].Rank &&
                cards[2].Rank == cards[3].Rank;

            /* ------------------------------
                Checking: a a x  b b
            ------------------------------ */
            var a2 = cards[0].Rank == cards[1].Rank &&
                cards[3].Rank == cards[4].Rank;

            /* ------------------------------
                Checking: x a a  b b
            ------------------------------ */
            var a3 = cards[1].Rank == cards[2].Rank &&
                cards[3].Rank == cards[4].Rank;

            return (a1 || a2 || a3);
        }
        
        public bool IsThreeOfAKind(List<Card> cards)
        {
            cards.Sort();
            /* ------------------------------------------------------
                Check for: x x x a b
            ------------------------------------------------------- */
            var a1 = cards[0].Rank == cards[1].Rank &&
               cards[1].Rank == cards[2].Rank;
            /* ------------------------------------------------------
                Check for: a x x x b
            ------------------------------------------------------- */
            var a2 = cards[1].Rank == cards[2].Rank &&
               cards[2].Rank == cards[3].Rank;
            /* ------------------------------------------------------
                Check for: a b x x x
            ------------------------------------------------------- */
            var a3 = cards[2].Rank == cards[3].Rank &&
               cards[3].Rank == cards[4].Rank;

            return (a1 || a2 || a3);
        }

        public bool IsStraight(List<Card> cards)
        {
            cards.Sort();

            var testCard = cards[0].Rank + 1;
            for (int i = 1; i < 5; i++)
            {
                if (cards[i].Rank != testCard)
                    return false;
                testCard++;
            }
            return true;
        }
        
        public bool IsFlush(List<Card> cards)
        {
            var cardTest = cards[0];

            foreach (Card card in cards)
            {
                if (card.Suit != cardTest.Suit)
                    return false;
            }

            return true;
        }

        public bool IsFullHouse(List<Card> cards)
        {
            cards.Sort();
            /* ------------------------------------------------------
                Check for: x x x y y
            ------------------------------------------------------- */
            var a1 = cards[0].Rank == cards[1].Rank &&
                cards[1].Rank == cards[2].Rank &&
                cards[3].Rank == cards[4].Rank;

            /* ------------------------------------------------------
                Check for: x x y y y
            ------------------------------------------------------- */
            var a2 = cards[0].Rank == cards[1].Rank &&
                cards[2].Rank == cards[3].Rank &&
                cards[3].Rank == cards[4].Rank;

            return (a1 || a2);
        }

        public bool IsFourOfAKind(List<Card> cards)
        {
            cards.Sort();

            /* ------------------------------------------------------
                Check for: fisrst 4 cards of the same rank 
            ------------------------------------------------------- */
            var a1 = cards[0].Rank == cards[1].Rank &&
            cards[1].Rank == cards[2].Rank &&
                cards[2].Rank == cards[3].Rank;
            /* ------------------------------------------------------
                Check for: fisrst 4 cards of the same rank 
            ------------------------------------------------------- */
            var a2 = cards[1].Rank == cards[2].Rank &&
            cards[2].Rank == cards[3].Rank &&
            cards[3].Rank == cards[4].Rank;

            return (a1 || a2);
        }

        public bool IsStraightFlush(List<Card> cards)
        {
            return IsStraight(cards) && IsFlush(cards);
        }

        public bool IsRoyalFlush(List<Card> cards)
        {
            return IsStraight(cards) && IsFlush(cards) && HighCard(cards).Rank == Rank.Ace;
        }

        public ValueHand PokerHand(List<Card> cards)
        {
            if(IsRoyalFlush(cards))
                return ValueHand.RoyalFlush;
            if (IsStraightFlush(cards) )
                return ValueHand.StraightFlush;
            if ( IsFourOfAKind(cards) )
                return ValueHand.FourOfAKind;
            if ( IsFullHouse(cards) )
                return ValueHand.FullHouse;
            if ( IsFlush(cards) )
                return ValueHand.Flush;
            if ( IsStraight(cards) )
                return ValueHand.Straight;
            if ( IsThreeOfAKind(cards) )
                return ValueHand.ThreeOfAKind;
            if ( IsTwoPair(cards) )
                return ValueHand.TwoPair;
            if ( IsPair(cards) )
                return ValueHand.Pair;
            else
                return ValueHand.HighCard;
        }
    }
}