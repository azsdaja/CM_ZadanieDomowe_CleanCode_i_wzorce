using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PokerHands
{
    public class PokerHandEvaluator
    {
        // posprzątam jak dostanę więcej czasu na pracę domową, obiecuję! — Krzysiu, 10 VIII 2020

        CardService _cardService = new CardService();
        

        public Combination CheckWhatIsTheHighestCombination(int gameNumber, params string[] cards)
        {
            IEnumerable<Card> parsedCards = cards.Select(card => _cardService.ParseCardString(card));

            List<Card> cardsfromLowest = parsedCards.OrderBy(k => k.Value).ToList();

            bool isStraight = _cardService.CheckIfIsStraight(cardsfromLowest);
            Color firstCardColor = cardsfromLowest.First().Color;
            bool cardsAreSameColor = cardsfromLowest.All(c => c.Color == firstCardColor);

            List<IGrouping<Value, Card>> cardGroupsByValues = _cardService.GroupCardsByValues(cardsfromLowest).ToList();

            List<Card> groupWithMostOccurences = cardGroupsByValues
                .OrderByDescending(g => g.Count())
                .ThenByDescending(g => g.Key)
                .First().ToList();


            //To bym przerobił na Chains of Responsibility, ale niestety nie zdążyłem już

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

            if(cardGroupsByValues.Any(IsGroupOf(4)))
            {
                return Combination.Quads;
            }

            if (cardGroupsByValues.Any(IsGroupOf(2)) && cardGroupsByValues.Any(g => g.Count() == 3))
            {
                return Combination.Full;
            }

            if (cardGroupsByValues.Any(IsGroupOf(3)))
            {
                return Combination.Three;
            }

            if (cardGroupsByValues.Count(IsGroupOf(2)) == 2)
            {
                return Combination.TwoPairs;
            }

            if (cardGroupsByValues.Any(IsGroupOf(2)))
            {
                return Combination.Pair;
            }

            return Combination.HighCard;
        }
        private static Func<IGrouping<Value, Card>, bool> IsGroupOf(int n) => group => group.Count() == n;

    }
}