using System.Collections.Generic;
using PokerHands;

namespace HighestCombinationObserver
{
    public interface INotifier
    {
        List<Card> Cards { get; set; }
        int GameNumber { get; set; }
        Combination HighestCombination { get; set; }

        event Notifier.HighestCombinationCalculated HighestCombinationCalculatedEvent;

        void Notify();
    }
}
