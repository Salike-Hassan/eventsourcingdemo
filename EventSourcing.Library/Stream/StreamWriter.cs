using EventSourcing.Library.Resolver;
using EventStore.ClientAPI;
using QuadPay.Domain.Core;

namespace EventSourcing.Library.Stream;

public class StreamWriter : IStreamWriter
{
    private readonly IEventStoreConnection eventStoreConnection;
    private readonly IEventResolver eventResolver;

    public StreamWriter(IEventStoreConnection eventStoreConnection,
        IEventResolver eventResolver)
    {
        this.eventStoreConnection = eventStoreConnection;
        this.eventResolver = eventResolver;
    }

    public async Task Write(IEnumerable<Event> events, string streamId, KeyValuePair<string, string>[] headers, long version)
    {
        var eventsToSave = events.Select(e => this.eventResolver.Resolve(e, headers))
                         .ToArray();

        var result = await this.eventStoreConnection.AppendToStreamAsync(streamId, version, eventsToSave);

        var ver = result.NextExpectedVersion;
        //return result.NextExpectedVersion;
    }
}