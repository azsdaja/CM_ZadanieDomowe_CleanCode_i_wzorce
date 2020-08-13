namespace PokerHands.Services.Interfaces
{
    public interface IHandEvaluator
    {
        Combination WhatIsTheHighestCombination(int gameNumber, params string[] cards);
    }
}
