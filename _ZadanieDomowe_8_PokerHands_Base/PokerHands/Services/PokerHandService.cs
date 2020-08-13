using PokerHands.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHands.Services
{
    public class PokerHandService : IHandService
    {
        public List<Card> GroupCardsFromLowest(IEnumerable<Card> parsedCards) => parsedCards.OrderBy(card => card.Value).ToList();

        public List<Card> GroupByMostOccurences(List<IGrouping<Value, Card>> cardGroupsByValues) =>
                cardGroupsByValues
                .OrderByDescending(g => g.Count())
                .ThenByDescending(g => g.Key)
                .First()
                .ToList();

        public IEnumerable<IGrouping<Value, Card>> GroupCardsByValues(List<Card> cardsByValue) =>
            from card in cardsByValue
            group card by card.Value
            into cardGroup
            select cardGroup;

        public void CheckCorrectnessOfHand(List<Card> parsedCards)
        {
            if (parsedCards.Count != parsedCards.Distinct().Count())
            {
                throw new Exception("There are two the same cards in hand");
            }
        }
    }
}
