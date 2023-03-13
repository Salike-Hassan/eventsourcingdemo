using EventSourcing.Core.Domain;
using QuadPay.Domain.Core;

namespace EventSourcing.Application.Repositories;

public interface IAggregateRepository
{
    Task<List<Event>> GetEventsAsync(Guid aggregateId);

    Task SaveEventsAsync(AggregateRoot aggregate);
}