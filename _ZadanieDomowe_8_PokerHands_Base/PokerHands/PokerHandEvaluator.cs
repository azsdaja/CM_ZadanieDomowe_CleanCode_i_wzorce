using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

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
         private readonly Dictionary<string, Color> _colorStringsToColors = new Dictionary<string, Color>
        {
            {"C", Color.Clubs},
            {"S", Color.Spades},
            {"D", Color.Diamonds},
            {"H", Color.Hearts},
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
            if(cardsAreSameColor)
            {
                return Combination.Flush;
            }

            List<IGrouping<Value, Card>> cardGroupsByValues = GroupCardsByValues(cardsfromLowest).ToList();

            List<Card> groupWithMostOccurences = cardGroupsByValues
                .OrderByDescending(g => g.Count())
                .ThenByDescending(g => g.Key)
                .First().ToList();
        
            // todo - code above works fine... but what should I write to handle other cases?????     
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

        private static bool IsStraight(List<Card> cardsfromLowest)
        {
            bool resultFinal;
            bool result = false;
            for (int i = 0; i < 4; i++)
            {
            
                if (cardsfromLowest[i+1].Value== cardsfromLowest[i].Value+1)
                {
                    result = true;           
                }
                else
                {
                    result = false;
                    break;
                }

            }
            resultFinal = result;
            return resultFinal;

            // todo: how to check that cards have consequetive values??         

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
        public Card ParseCardString(string card)
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
        
       
        public List<ISubscriber> _subscribers = new List<ISubscriber>();
        public void RegisterSubscriber(ISubscriber subscriber)
        {
            _subscribers.Add(subscriber);
        }
        
        public void NotifyEvaluator(int number, Card card1, Card card2, Card card3, Card card4, Card card5, Combination combination)
        {
            foreach (var subscriber in _subscribers)
            {
                subscriber.Update(number, card1, card2, card3, card4, card5, combination);              
            }
        }
    }

   
}