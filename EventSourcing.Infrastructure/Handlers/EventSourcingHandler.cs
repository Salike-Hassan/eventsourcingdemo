using EventSourcing.Core.Domain;
using EventSourcing.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Infrastructure.Handlers;

public class EventSourcingHandler : IEventSourcingHandler<PostAggregate>
{
    public Task<PostAggregate> GetByIdAsync(Guid aggregateId)
    {
        throw new NotImplementedException();
    }

    public Task SaveAsync(AggregateRoot aggregate)
    {
        throw new NotImplementedException();
    }
}
