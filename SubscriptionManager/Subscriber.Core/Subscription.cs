using System;
using System.Collections.Generic;
using System.Text;
using Subscriber.Core.Events;
using Subscription.Framework;

namespace Subscriber.Core
{
    public class Subscription : AggregateRoot
    {
        private Guid _vendorId;
        private string _vendorName;

        private string _subscriberName;
        private Guid _subscriberId;

        private SubscriptionLevel _level;

        public Subscription(
            Guid subscriberId, string subscriberName, 
            Guid vendorId, string vendorName, 
            SubscriptionLevel level,
            Guid subscriptionId)
        :this()
        {
            Raise(new SubscriptionCreated(subscriptionId,
                subscriberId, subscriberName, vendorId, vendorName, level));
        }

        private Subscription()
        {
            Register<SubscriptionCreated>(When);
        }

        public Guid SubscriberId => _subscriberId;

        public string SubscriberName => _subscriberName;

        public Guid VendorId => _vendorId;

        public string VendorName => _vendorName;

        public SubscriptionLevel SubscriptionLevel => _level;

        private void When(SubscriptionCreated e)
        {
            _subscriberId = e.SubscriberId;
            _subscriberName = e.SubscriberName;

            _vendorId = e.VendorId;
            _vendorName = e.VendorName;

            _level = e.Level;

            Id = e.SubscriptionId;
        }
    }
}
