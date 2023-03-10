using EventSourcing.Core.Domain;
using EventSourcing.Library.Stream;
using QuadPay.Domain.Core;
using QuadPay.EventStore.EventStore;

namespace EventSourcing.Application.Store;

public class EventStore : IEventStore
{
    private readonly IStreamWriter streamWriter;

    public EventStore(IStreamWriter streamWriter)
    {
        this.streamWriter = streamWriter;
    }

    public Task<List<Event>> GetEventsAsync(Guid aggregateId)
    {
        throw new NotImplementedException();
    }

    public async Task SaveEventsAsync(AggregateRoot aggregate)
    {
        KeyValuePair<string, string>[] DefaultHeaders = new[] {
            new KeyValuePair<string, string>(HeaderKeys.AggregateClrTypeName, aggregate.Ge),
        };
        // await streamWriter.Write(aggregate, headers, streamId, aggregate.Version);
    }
}