using NUnit.Framework;
using PokerHands;
using System.Collections.Generic;

namespace PokerHandsTests
{
    public class CardServiceTests
    {

        [Test]
        public void ParseCardString_CorrectCard_ReturnsCard()
        {
            var service = new CardService();

            Card actualCard = service.ParseCardString("C4");

            Card expectedCard = new Card(Color.Clubs, Value.Four);

            Assert.AreEqual(expectedCard, actualCard);
        }

        [Test]
        public void ParseCardString_UncorrectCard_ReturnsCard()
        {
            var service = new CardService();

            Assert.Throws<KeyNotFoundException>(() => service.ParseCardString("L4"));
        }

    }
}
