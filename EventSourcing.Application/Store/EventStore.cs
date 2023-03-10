using EventSourcing.Core.Domain;
using QuadPay.Domain.Core;

namespace EventSourcing.Application.Store;

public class EventStore : IEventStore
{
    public EventStore()
    {

    }

    public Task<List<Event>> GetEventsAsync(Guid aggregateId)
    {
        throw new NotImplementedException();
    }

    public Task SaveEventsAsync(AggregateRoot root)
    {
        throw new NotImplementedException();
    }
}