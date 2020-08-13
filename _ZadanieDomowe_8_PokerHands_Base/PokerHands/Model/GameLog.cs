using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHands.Model
{
    public class GameLog
    {
        public int GameNumber { get; set; }
        public Combination HighestCombination { get; set; }
        public List<Card> CardsInHand { get; set; }

        public GameLog(int gameNumber, List<Card> cardsInHand, Combination highestCombination)
        {
            GameNumber = gameNumber;
            CardsInHand = cardsInHand;
            HighestCombination = highestCombination;
        }
    }
}
