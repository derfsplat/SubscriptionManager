using System;
using System.Collections.Generic;
using System.Text;

namespace Subscriber.Core.Commands
{
    public class CancelSubscription
    {
        public CancelSubscription(Guid subscriberId, Guid vendorId)
        {
            SubscriberId = subscriberId;
            VendorId = vendorId;
        }

        public Guid SubscriberId { get; }
        public Guid VendorId { get; }
    }
}
