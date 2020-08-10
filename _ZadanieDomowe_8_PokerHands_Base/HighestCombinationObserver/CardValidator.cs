using System;
using System.Collections.Generic;
using System.Text;
using PokerHands;

namespace HighestCombinationObserver
{
    public class CardValidator
    {
        public void CheckForDuplicatedCards(int gameNumber, List<Card> cards, Combination highestCombination)
        {
            for (int i = 1; i < cards.Count; i++)
            {
                bool cardsAreIdentical = (cards[i - 1].Color == cards[i].Color && cards[i - 1].Value == cards[i].Value);
                if (cardsAreIdentical) throw new Exception("Duplicated cards found.");
            }
        }
    }
}
