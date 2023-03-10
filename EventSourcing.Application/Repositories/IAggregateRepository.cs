using EventSourcing.Core.Domain;

namespace EventSourcing.Application.Repositories;

public interface IAggregateRepository<TAggregate> where TAggregate : class, new()
{
    Task<TAggregate> GetByAggregateId(Guid id, CancellationToken cancellationToken);

    Task Save(TAggregate aggregate);
}
