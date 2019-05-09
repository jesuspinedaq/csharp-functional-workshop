using System.Collections.Generic;
using System.Linq;

namespace Poker.Library
{
    public class Poker
    {
        public Card HighCard(List<Card> cards) => cards.OrderByDescending(x => x).FirstOrDefault();

        public bool IsPair(List<Card> cards) => cards.ToDicctionaryAndQuantity().Any(x => x.Value == 2);
        
        public bool IsTwoPair(List<Card> cards) => cards.ToDicctionaryAndQuantity().Where(x => x.Value == 2).Count() == 2;
        
        public bool IsThreeOfAKind(List<Card> cards) => cards.ToDicctionaryAndQuantity().Any(x => x.Value == 3);

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
        
        public bool IsFlush(List<Card> cards) => cards.All(card => card.Suit == cards.First().Suit);

        public bool IsFullHouse(List<Card> cards) => IsThreeOfAKind(cards) && IsPair(cards);

        public bool IsFourOfAKind(List<Card> cards) => cards.ToDicctionaryAndQuantity().Any(x => x.Value == 4);
        
        public bool IsStraightFlush(List<Card> cards) => IsStraight(cards) && IsFlush(cards);

        public bool IsRoyalFlush(List<Card> cards) => IsStraight(cards) && IsFlush(cards) && HighCard(cards).Rank == Rank.Ace;

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