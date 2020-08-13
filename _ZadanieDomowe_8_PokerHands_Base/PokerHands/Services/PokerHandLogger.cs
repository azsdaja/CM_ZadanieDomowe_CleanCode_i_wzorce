using PokerHands.Model;

namespace PokerHands.Services
{
    public class PokerHandLogger
    {
        public GameLog SaveGameResult(int gameNumber, Combination highestCombination)
        {
            return new GameLog(gameNumber, highestCombination);
        }
    }
}
