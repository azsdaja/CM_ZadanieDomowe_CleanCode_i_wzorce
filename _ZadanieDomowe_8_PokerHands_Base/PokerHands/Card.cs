namespace PokerHands
{
    public struct Card
    {
        public Color Color { get; }
        public Value Value { get; }

        public Card(Color color, Value value)
        {
            Color = color;
            Value = value;
        }
    }
}