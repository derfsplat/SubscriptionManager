using System;
using System.Net;
using System.Threading.Tasks;
using EventStore.ClientAPI;
using FakeItEasy;
using Subscriber.Core;
using Subscriber.Core.Commands;
using Subscriber.Core.Handlers;
using Subscription.Framework;
using Subscription.Framework.Commands;
using Xunit;

namespace Subscriber.Tests
{
    public class SubscriberShould
    {
        private async Task<AggregateRepository> GetRepo()
        {
            var eventStoreConnection = EventStoreConnection.Create(
                ConnectionSettings.Default,
                new IPEndPoint(IPAddress.Loopback, 1113));

            await eventStoreConnection.ConnectAsync();
            
            return new AggregateRepository(eventStoreConnection);
        }
        async Task<Dispatcher> GetDispatcher(AggregateRepository repo)
        {
            var commandHandlerMap = new CommandHandlerMap(new Handlers(repo));

            return new Dispatcher(commandHandlerMap);
        }

        [Fact]
        public async Task RaiseSubscriptionCreated_WhenCreatingSubscription()
        {
            var repo = await GetRepo();
            var dispatcher = await GetDispatcher(repo);
            var vendorId = Guid.NewGuid();
            var subscriberId = Guid.NewGuid();
            var level = SubscriptionLevel.Standard;
            var subscriptionId = Guid.NewGuid();

            await dispatcher.Dispatch(
                new CreateSubscription(vendorId, subscriberId, 
                    level, subscriptionId));

            var @out = await repo.Get<Core.Subscription>(subscriptionId);
            Assert.Equal(subscriptionId, @out.Id);
        }
    }
}
