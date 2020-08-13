using NUnit.Framework;
using PokerHands;
using PokerHands.Services;

namespace PokerHandsTests
{
    public class CardParserServiceTests
    {
        [TestCase("CA", Color.Clubs, Value.Ace)]
        [TestCase("D2", Color.Diamonds, Value.Two)]
        [TestCase("HQ", Color.Hearts, Value.Queen)]
        [TestCase("S10", Color.Spades, Value.Ten)]
        public void ParseCardString_ValidString_ReturnsValidCard(string cardString, Color expectedColor, Value expectedValue)
        {
            var parserService = new CardParserService();

            var actualCard = parserService.ParseCardString(cardString);
            var expectedCard = new Card(expectedColor, expectedValue);

            Assert.AreEqual(expectedCard, actualCard);
        }
    }
}
