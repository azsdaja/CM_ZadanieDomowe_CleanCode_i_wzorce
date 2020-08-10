using System;
using System.Collections.Generic;
using HighestCombinationObserver;
using NUnit.Framework;
using PokerHands;

namespace HighestCombinationObserverTests
{
    public class CardValidatorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void DuplicatedCards_ExceptionThrown()
        {
            var cards = new List<Card> { new Card(Color.Spades, Value.Two), new Card(Color.Spades, Value.Two) };
            var cardValidator = new CardValidator();

            Assert.Throws(typeof(Exception), new TestDelegate(delegate { cardValidator.CheckForDuplicatedCards(111, cards, Combination.Pair); }));
        }
        [Test]
        public void NotDuplicatedCards_ReturnsNull()
        {
            var cards = new List<Card> { new Card(Color.Spades, Value.Three), new Card(Color.Spades, Value.Two) };
            var cardValidator = new CardValidator();

            Assert.DoesNotThrow(new TestDelegate(delegate { cardValidator.CheckForDuplicatedCards(111, cards, Combination.Pair); }));
        }
    }
}