using System.Collections.Generic;
using System.Linq;

namespace Poker.Library
{
    public static class Extensions
    {
        public static  Dictionary<Rank, int> ToDicctionaryAndQuantity(this IEnumerable<Card> @value)
        {
            var CardQuantity = new Dictionary<Rank, int>();

            foreach (Card card in @value)
            {
                if (CardQuantity.Keys.Contains(card.Rank))
                    CardQuantity[card.Rank] += 1;
                else
                    CardQuantity[card.Rank] = 1;
            }

            return CardQuantity;
        }
    }

}