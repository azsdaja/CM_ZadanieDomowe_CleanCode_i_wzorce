using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHands
{
  public interface ISubscriber
    {
        void Update(int numberOfDeal, Card card1, Card card2, Card card3, Card card4, Card card5, Combination Combine);
    }
}
