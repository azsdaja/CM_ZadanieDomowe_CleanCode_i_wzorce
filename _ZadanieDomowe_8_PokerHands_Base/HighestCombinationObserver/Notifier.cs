using System;
using System.Collections.Generic;
using PokerHands;

namespace HighestCombinationObserver
{
    public class Notifier : INotifier
    {
        public delegate void HighestCombinationCalculated(int gameNumber, List<Card> cards, Combination highestCombination);

        public int GameNumber { get; set; }
        public List<Card> Cards { get; set; }
        public Combination HighestCombination { get; set; }

        public event HighestCombinationCalculated HighestCombinationCalculatedEvent;

        public void Notify()
        {
            HighestCombinationCalculatedEvent?.Invoke(GameNumber, Cards, HighestCombination);
        }
    }
}
