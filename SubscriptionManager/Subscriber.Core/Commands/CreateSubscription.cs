using System;
using System.Collections.Generic;
using System.Text;

namespace Subscriber.Core.Commands
{
    public class CreateSubscription
    {
        public CreateSubscription(Guid subscriberId, Guid vendorId, SubscriptionLevel level, Guid subscriptionId)
        {
            SubscriberId = subscriberId;
            VendorId = vendorId;
            Level = level;
            SubscriptionId = subscriptionId;
        }

        public Guid SubscriberId { get; }
        public Guid VendorId { get; }
        public SubscriptionLevel Level { get; }
        public Guid SubscriptionId { get; }
    }
}
