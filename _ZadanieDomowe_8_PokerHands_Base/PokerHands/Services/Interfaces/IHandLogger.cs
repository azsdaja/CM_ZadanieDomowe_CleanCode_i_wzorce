using PokerHands.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHands.Services.Interfaces
{
    public interface IHandLogger
    {
        GameLog SaveGameResult(int gameNumber, List<Card> cardsInHand, Combination highestCombination);
    }
}
