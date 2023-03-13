using EventSourcing.Library.Resolver;
using EventStore.ClientAPI;
using QuadPay.Domain.Core;

namespace EventSourcing.Library.Stream;

public class StreamReader : IStreamReader
{
    private readonly IEventStoreConnection eventStoreConnection;
    private readonly IEventResolver eventResolver;

    public StreamReader(IEventStoreConnection eventStoreConnection,
        IEventResolver eventResolver)
    {
        this.eventStoreConnection = eventStoreConnection;
        this.eventResolver = eventResolver;
    }

    public async Task<List<Event>> FindAggregateById(string streamId, CancellationToken ct, int readPageSize = 500)
    {
        StreamEventsSlice currentSlice;
        long eventNumber = 0;

        var toReturn = new List<Event>();

        do
        {
            ct.ThrowIfCancellationRequested();

            currentSlice = await this.eventStoreConnection
                                     .ReadStreamEventsForwardAsync(streamId, eventNumber, readPageSize, false);

            if (currentSlice.Status != SliceReadStatus.Success)
            {
                // return currentSlice.Status;
                return toReturn;
            }

            eventNumber = currentSlice.NextEventNumber;

            foreach (var resolvedEvent in currentSlice.Events)
            {
                ct.ThrowIfCancellationRequested();

                var payload = this.eventResolver.Resolve(resolvedEvent);

                if (payload == null)
                {
                    throw new ArgumentException($"Unable to find suitable type for event name {resolvedEvent.Event.EventType}.");
                }

                toReturn.Add(payload);
            }
        }
        while (!currentSlice.IsEndOfStream);

        return toReturn;
    }
}
