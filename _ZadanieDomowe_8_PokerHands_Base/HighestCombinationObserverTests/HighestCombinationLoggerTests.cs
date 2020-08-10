using System;
using System.Collections.Generic;
using HighestCombinationObserver;
using NUnit.Framework;
using PokerHands;

namespace HighestCombinationObserverTests
{
    public class HighestCombinationLoggerTests
    {
        Notifier _notifier = new Notifier();
        List<Card> _cards = new List<Card> { new Card(Color.Spades, Value.Two), new Card(Color.Clubs, Value.Two) };
        

        [Test]
        public void ValidInput_DataSaved()
        {
            //nie jest to do ko�ca test jednostkowy, ale bardziej integracyjny. Chcia�em sprawidz�, czy zadzia�a tworzenie notifiera i wywo�ywanie Notify();
            NotifierSetUp notifierSetUp = new NotifierSetUp(_notifier);
            notifierSetUp.SetUp();

            _notifier.GameNumber = 001;
            _notifier.Cards = _cards;
            _notifier.HighestCombination = Combination.Pair;

            _notifier.Notify();

            Assert.AreEqual(Combination.Pair, notifierSetUp._logger.HighestCombinationLogs[001]);
        }
    }
}