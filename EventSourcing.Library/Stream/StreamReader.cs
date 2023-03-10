using EventStore.ClientAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Library.Stream;

public class StreamReader : IStreamReader
{
    private readonly IEventStoreConnection eventStore;

    public StreamReader(IEventStoreConnection eventStore)
    {
        this.eventStore = eventStore;
    }

    public async Task FindAggregateById(string aggregateId)
    {
        //var result = await eventStore.ReadStreamAsync(Direction.Forwards, $"my-aggregate-{id.Value}", StreamPosition.Start, cancellationToken: cancellationToken);
        var result = await eventStore.ReadStreamEventsForwardAsync(aggregateId, StreamPosition.Start, 100, false);

    }
}
