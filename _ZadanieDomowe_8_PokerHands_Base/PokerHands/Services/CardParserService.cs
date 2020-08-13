using PokerHands.Services.Interfaces;
using System.Collections.Generic;

namespace PokerHands.Services
{
    public class CardParserService : ICardParser
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

        public Card ParseCardString(string cardName)
        {
            string valueString;
            string colorString = cardName.Substring(0, 1);

            if (cardName.Length == 3) valueString = cardName.Substring(1, 2);
            else valueString = cardName.Substring(1, 1);

            Color color = _colorStringsToColors[colorString];
            Value value = _valueStringsToValues[valueString];

            return new Card(color, value);
        }
    }
}
