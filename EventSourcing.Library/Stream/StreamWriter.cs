using EventSourcing.Core.Domain;
using EventSourcing.Library.Resolver;
using EventStore.ClientAPI;
using Newtonsoft.Json;
using System.Text;

namespace EventSourcing.Library.Stream;

public class StreamWriter : IStreamWriter
{
    private readonly IEventStoreConnection eventStoreConnection;

    public StreamWriter(IEventStoreConnection eventStoreConnection,
        IEventResolver eventResolver)
    {
        this.eventStoreConnection = eventStoreConnection;
        EventResolver = eventResolver;
    }

    public IEventResolver EventResolver { get; }

    public async Task Write(AggregateRoot aggregate, KeyValuePair<string, string>[] headers, string streamId, long version)
    {
        var events = aggregate.GetUncommittedChanges();

        var eventToSave = events.Select(e => this.EventResolver.Resolve(e, headers))
            .ToArray();

        try
        {
            var result = await this.eventStoreConnection.AppendToStreamAsync(streamId, version, eventToSave);
            var nextVer = result.NextExpectedVersion;
        }
        catch (Exception ex)
        {
            throw;
        }
        //var events = aggregate.GetUncommittedChanges()
        //                 .Select(@event => new EventData(
        //                    Guid.NewGuid(),
        //                    @event.GetType().Name,
        //                    true,
        //                    Encoding.UTF8.GetBytes(JsonSerializer.Serialize(@event)),
        //                    Encoding.UTF8.GetBytes(@event.GetType().FullName)))
        //                .ToArray();

        //if (!events.Any())
        //{
        //    return;
        //}

        //var streamName = GetStreamName(aggregate, aggregate.GetAggregateId());


        //var result = await eventStore.AppendToStreamAsync(streamName, aggregate.Version, events);

        //var streamResult = await eventStore.ReadStreamEventsForwardAsync(streamName, StreamPosition.Start, 100, false);

        //foreach (var @event in streamResult.Events)
        //{
        //    aggregate.ReplayEvents(@event.OriginalEvent.Data);
        //}



    }

    //private string GetStreamName<T>(T type, Guid aggregateId) => $"{type.GetType().Name}-{aggregateId}";
}