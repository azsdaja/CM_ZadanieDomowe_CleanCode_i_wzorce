using PokerHands.Model;
using PokerHands.Services.Interfaces;
using System.Collections.Generic;

namespace PokerHands.Services
{
    public class PokerHandLogger : IHandLogger
    {
        public GameLog SaveGameResult(int gameNumber, List<Card> cardsInHand, Combination highestCombination)
        {
            return new GameLog(gameNumber, cardsInHand ,highestCombination);
        }
    }
}
