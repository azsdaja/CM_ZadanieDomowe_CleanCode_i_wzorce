using System;
using System.Collections.Generic;
using System.Text;

namespace HighestCombinationObserver
{
    public class NotifierSetUp
    {
        INotifier _notifier;
        public HighestCombinationLogger _logger;
        public CardValidator _cardValidator;
        public NotifierSetUp(INotifier notifier)
        {
            _logger = new HighestCombinationLogger();
            _cardValidator = new CardValidator();
            _notifier = notifier;
        }

        
        
        public void SetUp()
        {
            _notifier.HighestCombinationCalculatedEvent += _logger.LogHighestCombination;
            _notifier.HighestCombinationCalculatedEvent += _cardValidator.CheckForDuplicatedCards;
        }

    }
}
