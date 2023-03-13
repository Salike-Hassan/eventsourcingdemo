using EventSourcing.Core.Domain;
using EventSourcing.Library.Stream;
using QuadPay.Domain.Core;
using System.IO;

namespace EventSourcing.Application.Repositories;
public class AggregateRepository : IAggregateRepository
{
    private readonly IStreamWriter streamWriter;
    private readonly IStreamReader streamReader;
    public AggregateRepository(IStreamWriter streamWriter,
        IStreamReader streamReader)
    {
        this.streamWriter = streamWriter;
        this.streamReader = streamReader;
    }
    public Task<List<Event>> GetEventsAsync(Guid aggregateId)
    {
        throw new NotImplementedException();
    }

    public async Task SaveEventsAsync(AggregateRoot aggregate)
    {
        var pendingEvents = aggregate.GetUncommittedChanges().ToArray();
        var streamId = this.GetStreamId(aggregate.GetAggregateId(), aggregate.StreamPrefix);

        if (!pendingEvents.Any())
        {
            //return aggregate.Version;
        }


        KeyValuePair<string, string>[] DefaultHeaders = new[]
      {
            new KeyValuePair<string, string>("ClrType", "PostAggregate"),
         };
        var result = await this.streamReader.FindAggregateById(streamId, CancellationToken.None);

        var expectedVersion = pendingEvents.Length - aggregate.Version;

        pendingEvents.ToList().ForEach(x => x.Version = expectedVersion);

        aggregate.Version = expectedVersion;

        await this.streamWriter.Write(pendingEvents, streamId, DefaultHeaders, expectedVersion);

    }

    private string GetStreamId(Guid aggregateId, string prefix)
    {
        return string.Concat(prefix, aggregateId.ToString("N"));
    }
}
