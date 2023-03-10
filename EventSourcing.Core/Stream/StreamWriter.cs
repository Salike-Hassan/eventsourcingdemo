using EventSourcing.Core.Domain;
using EventStore.ClientAPI;
using System.Text;
using System.Text.Json;

namespace EventSourcing.Core.Stream
{
    public class StreamWriter : IStreamWriter
    {
        private readonly IEventStoreConnection eventStore;

        public StreamWriter(IEventStoreConnection eventStore)
        {
            this.eventStore = eventStore;
        }
        public async Task Write(AggregateRoot aggregate)
        {
            try
            {
                var events = aggregate.GetUncommittedChanges()
                                 .Select(@event => new EventData(
                                    Guid.NewGuid(),
                                    @event.GetType().Name,
                                    true,
                                    Encoding.UTF8.GetBytes(JsonSerializer.Serialize(@event)),
                                    Encoding.UTF8.GetBytes(@event.GetType().FullName)))
                                .ToArray();

                if (!events.Any())
                {
                    return;
                }

                var streamName = GetStreamName(aggregate, aggregate.GetAggregateId());

                var result = await eventStore.AppendToStreamAsync(streamName, ExpectedVersion.Any, events);
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        private string GetStreamName<T>(T type, Guid aggregateId) => $"{type.GetType().Name}-{aggregateId}";
    }
}
