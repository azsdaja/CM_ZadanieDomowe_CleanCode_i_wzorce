using System.Collections.Generic;
using System.Linq;

namespace PokerHands
{
    public interface ICardParser
    {
        IEnumerable<IGrouping<Value, Card>> GroupCardsByValues(List<Card> cardsByValue);
        bool IsStraight(List<Card> cardsfromLowest);
        Card ParseCardString(string card);
    }
}