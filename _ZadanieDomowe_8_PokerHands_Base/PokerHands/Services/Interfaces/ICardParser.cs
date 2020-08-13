using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHands.Services.Interfaces
{
    public interface ICardParser
    {
        Card ParseCardString(string cardName);
    }
}
