using EventSourcing.Domain;
using Microsoft.Extensions.Logging;
using QuadPay.EventStore.EventStore;

namespace EventSourcing.Application.Repositories;

public class EventStoreRepository :  IEventStoreRepository
{
    
    public Task<List<PostAggregate>> FindByAggregateId(Guid aggregateId)
    {
        throw new NotImplementedException();
    }

    public Task SaveAsync(PostAggregate post)
    {
        throw new NotImplementedException();
    }
}
