using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHands
{
    public class PokerHandEvaluator
    {
        IPokerCardParser _pokerCardParser;
        public PokerHandEvaluator(IPokerCardParser pokerCardParser)
        {
            _pokerCardParser = pokerCardParser;
        }

        public Combination GetHighestCombination(int gameNumber, params string[] cards)
        {
            IEnumerable<Card> parsedCards = cards.Select(card => _pokerCardParser.ParseCardString(card));

            List<Card> cardsFromLowest = parsedCards.OrderBy(k => k.Value).ToList();

            bool cardsAreStraight = AreCardsStraight(cardsFromLowest);

            bool cardsAreSameColor = AreCardsSameColor(cardsFromLowest);

            if (cardsAreStraight)
            {
                if (cardsAreSameColor)
                {
                    bool highestIsAce = cardsFromLowest.Last().Value == Value.Ace;
                    return highestIsAce ? Combination.RoyalFlush : Combination.StraightFlush;
                }
                return Combination.Straight;
            }
            if (cardsAreSameColor)
            {
                return Combination.Flush;
            }

            List<IGrouping<Value, Card>> orderedGroupsByMostOccurences = GroupCardsByOccurance(cardsFromLowest);
            List<Card> groupWithMostOccurences = orderedGroupsByMostOccurences.First().ToList();

            if (groupWithMostOccurences.Count == 4)
            {
                return Combination.Quads;
            }

            List<Card> secondGroupByMostOccurences = GetSecondGroupByOccurance(orderedGroupsByMostOccurences);

            if (groupWithMostOccurences.Count == 3)
            {
                return (secondGroupByMostOccurences.Count == 2) ? Combination.Full : Combination.Three;
            }

            if (groupWithMostOccurences.Count == 2)
            {
                return (secondGroupByMostOccurences.Count == 2) ? Combination.TwoPairs : Combination.Pair;
            }

            return Combination.HighCard;
        }

        private static List<IGrouping<Value, Card>> GroupCardsByOccurance(List<Card> cardsFromLowest)
        {
            List<IGrouping<Value, Card>> cardGroupsByValues = GroupCardsByValues(cardsFromLowest).ToList();

            List<IGrouping<Value, Card>> orderedGroupsByMostOccurences = cardGroupsByValues
                .OrderByDescending(g => g.Count())
                .ThenByDescending(g => g.Key).ToList();
            return orderedGroupsByMostOccurences;
        }

        private static bool AreCardsSameColor(List<Card> cardsfromLowest)
        {
            Color firstCardColor = cardsfromLowest.First().Color;
            bool cardsAreSameColor = cardsfromLowest.All(c => c.Color == firstCardColor);
            return cardsAreSameColor;
        }

        private List<Card> GetSecondGroupByOccurance(List<IGrouping<Value, Card>> groupOrderedByMostOccurences)
        {
            groupOrderedByMostOccurences.RemoveAt(0);
            return groupOrderedByMostOccurences.First().ToList();
        }

        private static bool AreCardsStraight(List<Card> cardsfromLowest)
        {
            bool isStraight = false;

            for (int i = 1; i < cardsfromLowest.Count; i++)
            { 
                if (cardsfromLowest[i-1].Value +1 == cardsfromLowest[i].Value)
                {
                    isStraight = true;
                }
                else
                {
                    isStraight = false;
                    break;
                }
            }
            return isStraight;
        }

        private static IEnumerable<IGrouping<Value, Card>> GroupCardsByValues(List<Card> cardsByValue)
        {
            return from card in cardsByValue
                group card by card.Value
                into cardGroup
                select cardGroup;
        }        
    }
}