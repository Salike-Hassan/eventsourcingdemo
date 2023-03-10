using EventSourcing.Core.Domain;
using QuadPay.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Store;

public interface IEventStore
{
    Task<List<Event>> GetEventsAsync(Guid aggregateId);


    Task SaveEventsAsync(AggregateRoot aggregate);
    
}
