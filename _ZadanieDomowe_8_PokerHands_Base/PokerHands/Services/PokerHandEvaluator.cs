using PokerHands.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHands
{
    public class PokerHandEvaluator : IHandEvaluator
    {
        private readonly IHandService _handService;
        private readonly ICardParser _cardParser;

        public PokerHandEvaluator(IHandService handService, ICardParser cardParser)
        {
            _handService = handService;
            _cardParser = cardParser;
        }

        public Combination WhatIsTheHighestCombination(int gameNumber, params string[] cards)
        {
            var parsedCards = cards.Select(card => _cardParser.ParseCardString(card));

            var cardsfromLowest = _handService.GroupCardsFromLowest(parsedCards);
            var cardGroupsByValues = _handService.GroupCardsByValues(cardsfromLowest).ToList();
            var cardGroupWithMostOccurences = _handService.GroupByMostOccurences(cardGroupsByValues);

            bool cardsAreSameColor = IsSameColor(cardsfromLowest);
            bool isStraight = IsStraight(cardsfromLowest);

            if (isStraight)
            {
                if (cardsAreSameColor)
                {
                    bool highestIsAce = cardsfromLowest.Last().Value == Value.Ace;
                    return highestIsAce ? Combination.RoyalFlush : Combination.StraightFlush;
                }
                return Combination.Straight;
            }
            else if (cardsAreSameColor)
            {
                return Combination.Flush;
            }
            else if (cardGroupsByValues.Any(IsGroupOf(2)) && cardGroupsByValues.Any(IsGroupOf(3)))
            {
                return Combination.Full;
            }
            else if (cardGroupsByValues.Count(IsGroupOf(2)) == 2)
            {
                return Combination.TwoPairs;
            }

            switch (cardGroupWithMostOccurences.Count)
            {
                case 4:
                    return Combination.Quads;
                case 3:
                    return Combination.Three;
                case 2:
                    return Combination.Pair;
                default:
                    return Combination.HighCard;
            }
        }

        private bool IsSameColor(List<Card> cardsfromLowest) => cardsfromLowest.All(card => card.Color == cardsfromLowest.First().Color);

        private bool IsStraight(List<Card> cardsfromLowest) => !cardsfromLowest.Select((card, selector) =>
            card.Value - selector).Distinct().Skip(1).Any();

        private Func<IGrouping<Value, Card>, bool> IsGroupOf(int n) =>
            group => group.Count() == n;
    }
}