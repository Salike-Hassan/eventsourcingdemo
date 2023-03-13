using EventSourcing.Core.Domain;
using QuadPay.Domain.Core;

namespace EventSourcing.Application.Store;

public interface IEventStore
{
    Task<List<Event>> GetEventsAsync(Guid aggregateId);


    Task SaveEventsAsync(AggregateRoot aggregate);
}
