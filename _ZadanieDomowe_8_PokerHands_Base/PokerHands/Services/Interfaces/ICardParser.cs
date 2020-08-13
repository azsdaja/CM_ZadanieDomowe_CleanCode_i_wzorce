namespace PokerHands.Services.Interfaces
{
    public interface ICardParser
    {
        Card ParseCardString(string cardName);
    }
}
