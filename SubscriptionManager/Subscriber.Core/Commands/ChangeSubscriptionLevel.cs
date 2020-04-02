using System;
using System.Collections.Generic;
using System.Text;

namespace Subscriber.Core.Commands
{
    public class ChangeSubscriptionLevel
    {
        public ChangeSubscriptionLevel(Guid subscriberId, SubscriptionLevel level)
        {
            SubscriberId = subscriberId;
            Level = level;
        }

        public Guid SubscriberId { get; }
        public SubscriptionLevel Level { get; }
    }
}
