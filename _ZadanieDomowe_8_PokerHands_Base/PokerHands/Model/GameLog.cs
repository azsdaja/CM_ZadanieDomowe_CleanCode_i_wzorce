using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHands.Model
{
    public class GameLog
    {
        public int GameNumber { get; set; }
        public Combination HighestCombination { get; set; }

        public GameLog(int gameNumber, Combination highestCombination)
        {
            GameNumber = gameNumber;
            HighestCombination = highestCombination;
        }
    }
}
