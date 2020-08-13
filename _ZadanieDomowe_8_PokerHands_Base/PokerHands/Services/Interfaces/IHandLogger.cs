using PokerHands.Model;
using System.Collections.Generic;

namespace PokerHands.Services.Interfaces
{
    public interface IHandLogger
    {
        GameLog SaveGameResult(int gameNumber, List<Card> cardsInHand, Combination highestCombination);
    }
}
