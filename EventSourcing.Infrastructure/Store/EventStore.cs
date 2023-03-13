using EventSourcing.Core.Infrastrcuture;
using QuadPay.Domain.Core;

namespace EventSourcing.Infrastructure.Store;

public class EventStore : IEventStore
{
    public Task<List<Event>> GetEventsAsync(Guid aggregateId)
    {
        throw new NotImplementedException();
    }

    public Task SaveEventsAsync(Guid aggregateId, IEnumerable<Event> events, int expectedVersion)
    {
        throw new NotImplementedException();
    }
}
