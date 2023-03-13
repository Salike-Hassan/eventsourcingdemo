using EventSourcing.Application.Repositories;
using EventSourcing.Core.Domain;
using QuadPay.Domain.Core;

namespace EventSourcing.Application.Store;

public class EventStore : IEventStore
{
    private readonly IAggregateRepository aggregateRepository;

    public EventStore(IAggregateRepository postAggregateRepository)
    {
        this.aggregateRepository = postAggregateRepository;
    }

    public Task<List<Event>> GetEventsAsync(Guid aggregateId)
    {
        throw new NotImplementedException();
    }

    public async Task SaveEventsAsync(AggregateRoot aggregate)
    {
        await this.aggregateRepository.SaveEventsAsync(aggregate);
    }
}