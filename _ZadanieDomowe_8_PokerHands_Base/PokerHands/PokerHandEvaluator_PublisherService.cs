using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHands
{
    public class PokerHandEvaluator_PublisherService
    {
      
        PokerHandEvaluator pokerResult = new PokerHandEvaluator(new CardParser());
        public Publisher publisher = new Publisher();
        public HighCombinationSaver highCombinationSaver = new HighCombinationSaver();
        public ShowException showException = new ShowException();
        void SendToPublisher(int gameNumber,List<Card> cardsfromLowest ,string card1, string card2, string  card3, string card4, string card5)
        {
            publisher.RegisterSubscriber(highCombinationSaver);
            publisher.RegisterSubscriber(showException);
            publisher.NotifyEvaluator(gameNumber,cardsfromLowest, pokerResult.WhatIsTheHighestCombination(123, card1, card2, card3, card4, card5));
        }
    }
}
