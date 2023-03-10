using EventSourcing.Domain;

namespace EventSourcing.Application.Repositories;

public interface IEventStoreRepository
{
    Task SaveAsync(PostAggregate post);
    Task<List<PostAggregate>> FindByAggregateId(Guid aggregateId);
}