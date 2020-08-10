using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHands
{
    public class ShowException : ISubscriber
    {
        public void Update(int numberOfDeal, List<Card> cards, Combination Combine)
        {
            for (int i = 0; i < 4; i++)
            {
                if (cards[i + 1].Value == cards[i].Value + 1)
                {
                    throw new ArgumentException("Karta powtórzyła się");
                }

            }
        }
    }
}
