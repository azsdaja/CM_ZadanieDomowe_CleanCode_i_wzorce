using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PokerHands.Services.Interfaces
{
    public interface IHandService
    {
        List<Card> GroupCardsFromLowest(IEnumerable<Card> parsedCards);
        List<Card> GroupByMostOccurences(List<IGrouping<Value, Card>> cardGroupsByValues);
        IEnumerable<IGrouping<Value, Card>> GroupCardsByValues(List<Card> cardsByValue);
    }
}
