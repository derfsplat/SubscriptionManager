using System;
using System.Collections.Generic;
using System.Text;

namespace Subscriber.Core.Events
{
    public class SubscriptionCreated
    { 
        public SubscriptionCreated(Guid subscriptionId, Guid subscriberId, string subscriberName,
            Guid vendorId, string vendorName,
            SubscriptionLevel level)
        {
            SubscriptionId = subscriptionId;
            SubscriberId = subscriberId;
            SubscriberName = subscriberName;
            VendorId = vendorId;
            VendorName = vendorName;
            Level = level;
        }

        public Guid SubscriptionId { get; }
        public Guid SubscriberId { get; }
        public string SubscriberName { get; }
        public Guid VendorId { get; }
        public string VendorName { get; }
        public SubscriptionLevel Level { get; }
    }
}
