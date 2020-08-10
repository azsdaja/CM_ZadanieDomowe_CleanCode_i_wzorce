using System;
using System.Collections.Generic;
using System.Text;
using PokerHands;

namespace HighestCombinationObserver
{
    public class HighestCombinationLogger
    {
        public HighestCombinationLogger()
        {
            HighestCombinationLogs = new Dictionary<int, Combination>();
        }

        public Dictionary<int, Combination> HighestCombinationLogs { get; set; }

        public void LogHighestCombination(int gameNumber, List<Card> cards, Combination highestCombination)
        {
            HighestCombinationLogs.Add(gameNumber, highestCombination);
        }
    }
}
