using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHands
{
    public class HighCombinationSaver : ISubscriber
    {
        public Combination Combination { get; set; }
        public int GameNumber { get; set; }
        Dictionary<int, Combination> dealResuslt = new Dictionary<int, Combination>();
        public void Update(int numberOfDeal, List<Card> cards, Combination Combine)
        {
            Combination = Combine;
            GameNumber = numberOfDeal;
            dealResuslt.Add(GameNumber, Combination);
        }
    }
}
