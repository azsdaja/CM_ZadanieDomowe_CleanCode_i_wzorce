using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHands
{
    public class HighCombinationSaver : ISubscriber
    {
        public Combination Combination { get; set; }
        public int GameNumber { get; set; }

        public void Update(int numberOfDeal, Card card1, Card card2, Card card3, Card card4, Card card5, Combination Combine)
        {
            Combination = Combine;
            GameNumber = numberOfDeal;
        }
    }
}
