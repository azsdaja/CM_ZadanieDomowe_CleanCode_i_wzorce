using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace PokerHands
{
    public class PokerHandEvaluator
    {
        public Combination WhatIsTheHighestCombination(params string[] cards)
        {

            

            IEnumerable<Card> parsedCards = cards.Select(card => ParseCardString(card));
            List<Card> cardsFromLowest = parsedCards.OrderBy(k => k.Value).ToList();

            Color firstCardColor = cardsFromLowest.First().Color;
            bool cardsAreSameColor = cardsFromLowest.All(c => c.Color == firstCardColor);

            bool isStraight = IsStraight(cardsFromLowest);
            if (isStraight)
            {
                if (cardsAreSameColor)
                {
                    bool highestIsAce = cardsFromLowest.Last().Value == Value.Ace;
                    return highestIsAce ? Combination.RoyalFlush : Combination.StraightFlush;
                }
                return Combination.Straight; 
            }
            else if(cardsAreSameColor)
            {
                return Combination.Flush;
            }

            List<IGrouping<Value, Card>> cardGroupsByValues = GroupCardsByValues(cardsFromLowest).ToList();
            List<Card> groupWithMostOccurences_1 = cardGroupsByValues
                .OrderByDescending(g => g.Count())
                .ThenByDescending(g => g.Key)
                .First().ToList();

            cardsFromLowest.RemoveAll(i => groupWithMostOccurences_1.Contains(i));

            List<IGrouping<Value, Card>> cardGroupsByValuesMinusGroupWithMostOccurences_1 = GroupCardsByValues(cardsFromLowest).ToList();
            List<Card> groupWithMostOccurences_2 = cardGroupsByValuesMinusGroupWithMostOccurences_1
                .OrderByDescending(g => g.Count())
                .ThenByDescending(g => g.Key)
                .First().ToList();

            switch (groupWithMostOccurences_1.Count)
            {
                case 4:
                    AddCombination(Combination.Quads);
                    return Combination.Quads;
                case 3 when groupWithMostOccurences_2.Count == 2:
                    return Combination.Full;
                case 3 when groupWithMostOccurences_2.Count == 1:
                    return Combination.Three;
                case 2 when groupWithMostOccurences_2.Count == 2:
                    return Combination.TwoPairs;
                case 2 when groupWithMostOccurences_2.Count == 1:
                    return Combination.Pair;
                default:
                    return Combination.HighCard;
            }

        }

        bool IsStraight(List<Card> cardsfromLowest) => cardsfromLowest.GroupBy(card => card.Value).Count() == cardsfromLowest.Count() 
                                                    && cardsfromLowest.Max(card => (int)card.Value) - cardsfromLowest.Min(card => (int)card.Value) == 4;

        private static IEnumerable<IGrouping<Value, Card>> GroupCardsByValues(List<Card> cardsByValue)
        {
            return from card in cardsByValue
                group card by card.Value
                into cardGroup
                select cardGroup;
        }

        private Card ParseCardString(string card)
        {
            string valueString;
            string colorString = card.Substring(0, 1);

            if (card.Length == 3)
               valueString = card.Substring(1, 2);
            else
               valueString = card.Substring(1, 1);
            
            Color color = _colorStringsToColors[colorString];
            Value value = ValueStringsToValues[valueString];

            return new Card(color, value);
        }

        public readonly Dictionary<string, Color> _colorStringsToColors = new Dictionary<string, Color>
        {
            {"C", Color.Clubs},
            {"S", Color.Spades},
            {"D", Color.Diamonds},
            {"H", Color.Hearts},
        };

        public Dictionary<string, Value> ValueStringsToValues { get; } = new Dictionary<string, Value>
        {
            {"2", Value.Two},
            {"3", Value.Three},
            {"4", Value.Four},
            {"5", Value.Five},
            {"6", Value.Six},
            {"7", Value.Seven},
            {"8", Value.Eight},
            {"9", Value.Nine},
            {"10", Value.Ten},
            {"J", Value.Jack},
            {"Q", Value.Queen},
            {"K", Value.King},
            {"A", Value.Ace},
        };
        public List<Combination> CombinationListPerHand { get; set; }

        public void AddCombination (Combination combination)
        {

            foreach (var combination in CombinationListPerHand)
            {
                CombinationListPerHand.Add(combination);
            }
            

        }
    }
}