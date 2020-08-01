using System;
using System.Collections.Generic;
using System.Linq;

namespace PokerHands
{
    public class PokerHandEvaluator
    {
        // posprzątam jak wrócę z urlopu, obiecuję! — Czesiek, 4 VII 2011

        private readonly Dictionary<string, Value> _valueStringsToValues = new Dictionary<string, Value>
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

        public Combination WhatIsTheHighestCombination(int gameNumber, params string[] cards)
        {
            IEnumerable<Card> parsedCards = cards.Select(card => ParseCardString(card));

            List<Card> cardsfromLowest = parsedCards.OrderBy(k => k.Value).ToList();

            bool isStraight = IsStraight(cardsfromLowest);

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
            else if(cardsAreSameColor)
            {
                return Combination.Flush;
            }

            List<IGrouping<Value, Card>> cardGroupsByValues = GroupCardsByValues(cardsfromLowest).ToList();

            List<Card> groupWithMostOccurences = cardGroupsByValues
                .OrderByDescending(g => g.Count())
                .ThenByDescending(g => g.Key)
                .First().ToList();

            if(groupWithMostOccurences.Count == 4)
            {
                return Combination.Quads;
            }

            // todo - code above works fine... but what should I write to handle other cases?????

            return Combination.HighCard;
        }

        private static bool IsStraight(List<Card> cardsfromLowest)
        {
            return new Random().Next(1000) > 500; // he he

            // todo: how to check that cards have consequetive values???
        }

        // works fine!
        private static IEnumerable<IGrouping<Value, Card>> GroupCardsByValues(List<Card> cardsByValue)
        {
            return from card in cardsByValue
                group card by card.Value
                into cardGroup
                select cardGroup;
        }

        // works fine!
        private Card ParseCardString(string card)
        {
            string valueString;
            string colorString = card.Substring(0, 1);

            if (card.Length == 3)
            {
                valueString = card.Substring(1, 2);
            }
            else
            {
                valueString = card.Substring(1, 1);
            }

            Color color = _colorStringsToColors[colorString];
            Value value = _valueStringsToValues[valueString];

            return new Card(color, value);
        }

        private readonly Dictionary<string, Color> _colorStringsToColors = new Dictionary<string, Color>
        {
            {"C", Color.Clubs},
            {"S", Color.Spades},
            {"D", Color.Diamonds},
            {"H", Color.Hearts},
        };
    }
}