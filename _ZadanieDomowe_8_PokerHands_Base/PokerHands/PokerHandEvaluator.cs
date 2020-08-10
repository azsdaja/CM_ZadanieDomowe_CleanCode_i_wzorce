using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace PokerHands
{
    public class PokerHandEvaluator
    {
       
        private readonly ICardParser _cardParser;

        public PokerHandEvaluator(ICardParser cardParser)
        {
            _cardParser = cardParser;          
        }
       
        public Combination WhatIsTheHighestCombination(int gameNumber, params string[] cards )
        {

            IEnumerable<Card> parsedCards = cards.Select(card => _cardParser.ParseCardString(card));

            List<Card> cardsfromLowest = parsedCards.OrderBy(k => k.Value).ToList();

            bool isStraight = _cardParser.IsStraight(cardsfromLowest);

            Color firstCardColor = cardsfromLowest.First().Color;
            bool cardsAreSameColor = cardsfromLowest.All(c => c.Color == firstCardColor);
            if (isStraight)
            {
                if (cardsAreSameColor)
                {
                    bool highestIsAce = cardsfromLowest.Last().Value == Value.Ace;
                    return highestIsAce ? Combination.RoyalFlush : Combination.StraightFlush;
                }

                return Combination.Straight;
            }
            if (cardsAreSameColor)
            {
                return Combination.Flush;
            }
            
            
            List<IGrouping<Value, Card>> cardGroupsByValues = _cardParser.GroupCardsByValues(cardsfromLowest).ToList();

            List<Card> groupWithMostOccurences = cardGroupsByValues
                .OrderByDescending(g => g.Count())
                .ThenByDescending(g => g.Key)
                .First().ToList();
            
            if (groupWithMostOccurences.Count == 4)
            {
                return Combination.Quads;
            }

            if (groupWithMostOccurences.Count == 3)
            {
                if (cardsfromLowest[3].Value == cardsfromLowest[4].Value)
                {
                    return Combination.Full;
                }
                else
                {
                    return Combination.Three;
                }
            }

            if (groupWithMostOccurences.Count == 2)
            {
                if (cardsfromLowest[2].Value == cardsfromLowest[3].Value)
                {
                    return Combination.TwoPairs;
                }
                else
                {                 
                    return Combination.Pair;
                }             
            }

            return Combination.HighCard;
        }
    }
}