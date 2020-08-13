using PokerHands.Model;
using System.Collections.Generic;

namespace PokerHands.Services
{
    public class PokerHandLogger
    {
        public GameLog SaveGameResult(int gameNumber, List<Card> cardsInHand, Combination highestCombination)
        {
            return new GameLog(gameNumber, cardsInHand ,highestCombination);
        }
    }
}
