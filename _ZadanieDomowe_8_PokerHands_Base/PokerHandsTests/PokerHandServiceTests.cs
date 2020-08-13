using NUnit.Framework;
using PokerHands;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHandsTests
{
    public class PokerHandServiceTests
    {
        [Test]
        public void GroupCardsFromLowest_ReturnsOrderdListFromLowestValue()
        {
            var parsedCards = new List<Card>
            {
                new Card(Color.Clubs, Value.Four),
                new Card(Color.Diamonds, Value.Three),
                new Card(Color.Spades, Value.Ace),
                new Card(Color.Spades, Value.Eight),
                new Card(Color.Diamonds, Value.Nine)
            };

            var orderedCards = parsedCards.OrderBy(card => card.Value).ToList();

            Assert.True(orderedCards[0].Value <= orderedCards[1].Value);
            Assert.True(orderedCards[1].Value <= orderedCards[2].Value);
            Assert.True(orderedCards[2].Value <= orderedCards[3].Value);
            Assert.True(orderedCards[3].Value <= orderedCards[4].Value);
        }

        [Test]
        public void CheckCorrectnessOfHand_ValidCardList_NoException()
        {
            var parsedCards = new List<Card>
            {
                new Card(Color.Clubs, Value.Four),
                new Card(Color.Diamonds, Value.Three),
                new Card(Color.Spades, Value.Ace),
                new Card(Color.Spades, Value.Eight),
                new Card(Color.Diamonds, Value.Nine)
            };

            if (parsedCards.Count != parsedCards.Distinct().Count())
            {
                throw new Exception("There are two the same cards in hand");
            }

            Assert.AreEqual(parsedCards.Count, parsedCards.Distinct().Count());
        }
    }
}
