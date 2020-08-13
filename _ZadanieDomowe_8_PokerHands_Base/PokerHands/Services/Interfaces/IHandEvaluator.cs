using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHands.Services.Interfaces
{
    public interface IHandEvaluator
    {
        Combination WhatIsTheHighestCombination(int gameNumber, params string[] cards);
    }
}
