using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHands
{
  public interface ISubscriber
    {
        void Update(int numberOfDeal,List<Card> cards, Combination Combine);
    }
}
