// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;
// using EventStore.ClientAPI;
// using EventStore.ClientAPI.SystemData;
// using FakeItEasy;
//
// namespace Subscriber.Tests
// {
//     public class EventStoreConnectionStub : IEventStoreConnection
//     {
//         public void Dispose()
//         {
//             throw new NotImplementedException();
//         }
//
//         public Task ConnectAsync()
//         {
//             throw new NotImplementedException();
//         }
//
//         public void Close()
//         {
//             throw new NotImplementedException();
//         }
//
//         public Task<DeleteResult> DeleteStreamAsync(string stream, long expectedVersion, UserCredentials userCredentials = null)
//         {
//             throw new NotImplementedException();
//         }
//
//         public Task<DeleteResult> DeleteStreamAsync(string stream, long expectedVersion, bool hardDelete, UserCredentials userCredentials = null)
//         {
//             throw new NotImplementedException();
//         }
//
//         Dictionary<string, IEnumerable<EventData>> eventStream = new Dictionary<string, IEnumerable<EventData>>();
//
//         public Task<WriteResult> AppendToStreamAsync(string stream, long expectedVersion, params EventData[] events)
//         {
//             eventStream.Add(stream, events);
//             return Task.FromResult(new WriteResult(++expectedVersion, Position.Start));
//         }
//
//         public Task<WriteResult> AppendToStreamAsync(string stream, long expectedVersion, UserCredentials userCredentials,
//             params EventData[] events)
//         {
//             throw new NotImplementedException();
//         }
//
//         public Task<WriteResult> AppendToStreamAsync(string stream, long expectedVersion, IEnumerable<EventData> events,
//             UserCredentials userCredentials = null)
//         {
//             throw new NotImplementedException();
//         }
//
//         public Task<ConditionalWriteResult> ConditionalAppendToStreamAsync(string stream, long expectedVersion, IEnumerable<EventData> events,
//             UserCredentials userCredentials = null)
//         {
//             throw new NotImplementedException();
//         }
//
//         public Task<EventStoreTransaction> StartTransactionAsync(string stream, long expectedVersion, UserCredentials userCredentials = null)
//         {
//             throw new NotImplementedException();
//         }
//
//         public EventStoreTransaction ContinueTransaction(long transactionId, UserCredentials userCredentials = null)
//         {
//             throw new NotImplementedException();
//         }
//
//         public Task<EventReadResult> ReadEventAsync(string stream, long eventNumber, bool resolveLinkTos, UserCredentials userCredentials = null)
//         {
//             throw new NotImplementedException();
//         }
//
//         public Task<StreamEventsSlice> ReadStreamEventsForwardAsync(string stream, long start, int count, bool resolveLinkTos,
//             UserCredentials userCredentials = null)
//         {
//             var slice = new Fake<StreamEventsSlice>();
//             if (!eventStream.ContainsKey(stream))
//                 return Task.FromResult(slice.FakedObject);
//             var events = eventStream[stream].Skip(Convert.ToInt32(start)).Take(count);
//             slice.CallsTo(s => s.Events)
//                 .Returns(events.Select(e =>
//                 {
//                     //can't fake a value type (struct)
//                     var fakeEvent = new Fake<ResolvedEvent>();
//                     fakeEvent.CallsTo(e => e.Event.Data)
//                         .Returns(e.Data);
//                 }).ToArray());
//
//         }
//
//         public Task<StreamEventsSlice> ReadStreamEventsBackwardAsync(string stream, long start, int count, bool resolveLinkTos,
//             UserCredentials userCredentials = null)
//         {
//             throw new NotImplementedException();
//         }
//
//         public Task<AllEventsSlice> ReadAllEventsForwardAsync(Position position, int maxCount, bool resolveLinkTos,
//             UserCredentials userCredentials = null)
//         {
//             throw new NotImplementedException();
//         }
//
//         public Task<AllEventsSlice> ReadAllEventsBackwardAsync(Position position, int maxCount, bool resolveLinkTos,
//             UserCredentials userCredentials = null)
//         {
//             throw new NotImplementedException();
//         }
//
//         public Task<EventStoreSubscription> SubscribeToStreamAsync(string stream, bool resolveLinkTos, Func<EventStoreSubscription, ResolvedEvent, Task> eventAppeared, Action<EventStoreSubscription, SubscriptionDropReason, Exception> subscriptionDropped = null,
//             UserCredentials userCredentials = null)
//         {
//             throw new NotImplementedException();
//         }
//
//         public EventStoreStreamCatchUpSubscription SubscribeToStreamFrom(string stream, long? lastCheckpoint,
//             CatchUpSubscriptionSettings settings, Func<EventStoreCatchUpSubscription, ResolvedEvent, Task> eventAppeared, Action<EventStoreCatchUpSubscription> liveProcessingStarted = null,
//             Action<EventStoreCatchUpSubscription, SubscriptionDropReason, Exception> subscriptionDropped = null, UserCredentials userCredentials = null)
//         {
//             throw new NotImplementedException();
//         }
//
//         public Task<EventStoreSubscription> SubscribeToAllAsync(bool resolveLinkTos, Func<EventStoreSubscription, ResolvedEvent, Task> eventAppeared, Action<EventStoreSubscription, SubscriptionDropReason, Exception> subscriptionDropped = null,
//             UserCredentials userCredentials = null)
//         {
//             throw new NotImplementedException();
//         }
//
//         public EventStorePersistentSubscriptionBase ConnectToPersistentSubscription(string stream, string groupName,
//             Func<EventStorePersistentSubscriptionBase, ResolvedEvent, int?, Task> eventAppeared, Action<EventStorePersistentSubscriptionBase, SubscriptionDropReason, Exception> subscriptionDropped = null, UserCredentials userCredentials = null, int bufferSize = 10,
//             bool autoAck = true)
//         {
//             throw new NotImplementedException();
//         }
//
//         public Task<EventStorePersistentSubscriptionBase> ConnectToPersistentSubscriptionAsync(string stream, string groupName, Func<EventStorePersistentSubscriptionBase, ResolvedEvent, int?, Task> eventAppeared,
//             Action<EventStorePersistentSubscriptionBase, SubscriptionDropReason, Exception> subscriptionDropped = null, UserCredentials userCredentials = null, int bufferSize = 10,
//             bool autoAck = true)
//         {
//             throw new NotImplementedException();
//         }
//
//         public EventStoreAllCatchUpSubscription SubscribeToAllFrom(Position? lastCheckpoint, CatchUpSubscriptionSettings settings,
//             Func<EventStoreCatchUpSubscription, ResolvedEvent, Task> eventAppeared, Action<EventStoreCatchUpSubscription> liveProcessingStarted = null, Action<EventStoreCatchUpSubscription, SubscriptionDropReason, Exception> subscriptionDropped = null,
//             UserCredentials userCredentials = null)
//         {
//             throw new NotImplementedException();
//         }
//
//         public Task UpdatePersistentSubscriptionAsync(string stream, string groupName, PersistentSubscriptionSettings settings,
//             UserCredentials credentials)
//         {
//             throw new NotImplementedException();
//         }
//
//         public Task CreatePersistentSubscriptionAsync(string stream, string groupName, PersistentSubscriptionSettings settings,
//             UserCredentials credentials)
//         {
//             throw new NotImplementedException();
//         }
//
//         public Task DeletePersistentSubscriptionAsync(string stream, string groupName, UserCredentials userCredentials = null)
//         {
//             throw new NotImplementedException();
//         }
//
//         public Task<WriteResult> SetStreamMetadataAsync(string stream, long expectedMetastreamVersion, StreamMetadata metadata,
//             UserCredentials userCredentials = null)
//         {
//             throw new NotImplementedException();
//         }
//
//         public Task<WriteResult> SetStreamMetadataAsync(string stream, long expectedMetastreamVersion, byte[] metadata,
//             UserCredentials userCredentials = null)
//         {
//             throw new NotImplementedException();
//         }
//
//         public Task<StreamMetadataResult> GetStreamMetadataAsync(string stream, UserCredentials userCredentials = null)
//         {
//             throw new NotImplementedException();
//         }
//
//         public Task<RawStreamMetadataResult> GetStreamMetadataAsRawBytesAsync(string stream, UserCredentials userCredentials = null)
//         {
//             throw new NotImplementedException();
//         }
//
//         public Task SetSystemSettingsAsync(SystemSettings settings, UserCredentials userCredentials = null)
//         {
//             throw new NotImplementedException();
//         }
//
//         public string ConnectionName { get; }
//         public ConnectionSettings Settings { get; }
//         public event EventHandler<ClientConnectionEventArgs> Connected;
//         public event EventHandler<ClientConnectionEventArgs> Disconnected;
//         public event EventHandler<ClientReconnectingEventArgs> Reconnecting;
//         public event EventHandler<ClientClosedEventArgs> Closed;
//         public event EventHandler<ClientErrorEventArgs> ErrorOccurred;
//         public event EventHandler<ClientAuthenticationFailedEventArgs> AuthenticationFailed;
//     }
// }
