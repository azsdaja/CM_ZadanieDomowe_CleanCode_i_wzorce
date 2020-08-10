using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHands
{
   public class Publisher
    {
        public List<ISubscriber> _subscribers = new List<ISubscriber>();
        public void RegisterSubscriber(ISubscriber subscriber)
        {
            _subscribers.Add(subscriber);
        }

        public void NotifyEvaluator(int number,List<Card> cards, Combination combination)
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.Update(number, cards, combination);
            }
        }
    }
}
