using System;
using System.Collections.Generic;
using System.Text;

namespace PokerHands
{
    public class CardCreator : ICardCreator
    {
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
    }
}
