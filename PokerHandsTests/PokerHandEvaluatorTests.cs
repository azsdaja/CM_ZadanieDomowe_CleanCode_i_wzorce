﻿using System;
using FluentAssertions;
using NUnit.Framework;
using PokerHands;

namespace PokerHandsTests
{
    public class PokerHandEvaluatorTests
    {
        [TestCase("C2", "S3", "D4", "C5", "HQ", Combination.HighCard)]
        [TestCase("C2", "S2", "D7", "C9", "HQ", Combination.Pair)]
        [TestCase("C2", "S2", "D7", "C7", "HQ", Combination.TwoPairs)]
        [TestCase("C2", "S2", "D2", "C9", "HQ", Combination.Three)]
        [TestCase("C2", "S3", "D4", "C5", "H6", Combination.Straight)]
        [TestCase("C2", "C5", "C7", "C9", "CQ", Combination.Flush)]
        [TestCase("S9", "S5", "H5", "C9", "C5", Combination.Full)]
        [TestCase("C2", "S2", "D2", "H2", "HQ", Combination.Quads)]
        [TestCase("H9", "H10", "H7", "H8", "HJ", Combination.StraightFlush)]
        [TestCase("H10", "HJ", "HQ", "HK", "HA", Combination.RoyalFlush)]
        public void GetHighestCombination_FiveCorrectCards_ReturnsHighestCombination
            (string card1, string card2, string card3, string card4, string card5, Combination expectedCombination)
        {
            var evaluator = new PokerHandEvaluator(new PokerCardParser());

            Combination accualCombination 
                = evaluator.GetHighestCombination(123, card1, card2, card3, card4, card5);

            Assert.AreEqual(expectedCombination, accualCombination);
        }
    }
}
