using EventSourcing.Application.Store;
using EventSourcing.Core.Domain;
using EventSourcing.Domain;

namespace EventSourcing.Application.Handlers;

public class EventSourcingHandler : IEventSourcingHandler<PostAggregate>
{
    private readonly IEventStore eventStore;

    public EventSourcingHandler(IEventStore eventStore)
    {
        this.eventStore = eventStore;
    }

    public Task<PostAggregate> GetByIdAsync(Guid aggregateId)
    {
        throw new NotImplementedException();
    }

    public async Task SaveAsync(AggregateRoot aggregate)
    {
        await this.eventStore.SaveEventsAsync(aggregate);
        aggregate.MarkChangesAsCommitted();
    }
}
