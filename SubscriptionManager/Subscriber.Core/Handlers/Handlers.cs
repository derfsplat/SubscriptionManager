using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Subscriber.Core.Commands;
using Subscription.Framework;
using Subscription.Framework.Commands;

namespace Subscriber.Core.Handlers
{
    public class Handlers : CommandHandlerBase
    {
        //TODO: Come up with a multi-step workflow example, define/persist using https://camunda.com/
        public Handlers(AggregateRepository repository)
        {
            //Imagine these are independent services registering handlers via message bus (e.g. Rabbit / Kafka)
            Register<CreateSubscription>(async c =>
            {
                await repository.Save(new Subscription(
                    c.SubscriberId,
                    "",
                    c.VendorId,
                    "",
                    c.Level,
                    c.SubscriptionId
                ));
            });

            //TODO: Change subscription

            //TODO: Cancel subscription
        }
    }
}
