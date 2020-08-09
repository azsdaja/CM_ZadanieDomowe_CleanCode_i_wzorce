using System;
using FluentAssertions;
using NUnit.Framework;
using PokerHands;

namespace PokerHandsTests
{
    public class PokerHandEvaluatorTests
    {
        private readonly ICardCreator _cardCreator;
        public PokerHandEvaluatorTests(ICardCreator cardCreator)
        {
            _cardCreator = cardCreator;
        }

        [Test]
        public void GetHighestCombination_FourSevens_ReturnsQuads()
        {
            var evaluator = new PokerHandEvaluator(_cardCreator);

            Combination highestCombination = evaluator.WhatIsTheHighestCombination(123, "H7", "S7", "C7", "CQ", "D7");

            if(highestCombination != Combination.Quads)
                throw new Exception("not quads");
            
           
        }

        [TestCase("C2", "S5", "D7", "C9", "HQ", Combination.HighCard)]
        [TestCase("C2", "S2", "D7", "C9", "HQ", Combination.Pair)]
        [TestCase("C2", "S2", "D7", "C7", "HQ", Combination.TwoPairs)]
        [TestCase("C2", "S2", "D2", "C9", "HQ", Combination.Three)]
        [TestCase("C2", "S3", "D4", "C5", "H6", Combination.Straight)]
        [TestCase("C2", "C5", "C7", "C9", "CQ", Combination.Flush)]
        [TestCase("C2", "S2", "D2", "D7","C7", Combination.Full)] 
        [TestCase("C2", "S2", "D2", "H2", "HQ", Combination.Quads)]
        [TestCase("H9", "H10", "H7", "H8", "HJ", Combination.StraightFlush)]
        [TestCase("H10", "HJ", "HQ", "HK", "HA", Combination.RoyalFlush)]

        public void GetHighestCombination_FiveCorrectCards_ReturnsHighestCombination
            (string card1, string card2, string card3, string card4, string card5, Combination expect)
        {
            var evaluator = new PokerHandEvaluator(_cardCreator);
            Combination x
                = evaluator.WhatIsTheHighestCombination(123, card1, card2, card3, card4, card5);
            Assert.AreEqual(expect, x);

              evaluator.NotifyEvaluator(123, _cardCreator.ParseCardString(card1), _cardCreator.ParseCardString(card2), _cardCreator.ParseCardString(card3), _cardCreator.ParseCardString(card4),
                  _cardCreator.ParseCardString(card5), x);
     

        }
    }
}
