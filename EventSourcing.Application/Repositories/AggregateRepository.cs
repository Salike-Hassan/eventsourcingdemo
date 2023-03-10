using EventSourcing.Core.Domain;
using EventSourcing.Library.Stream;
using QuadPay.EventStore.EventStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Repositories
{
    public class AggregateRepository<TAggregate> : IAggregateRepository<TAggregate>
        where TAggregate : class, new()
    {
        private readonly IStreamWriter streamWriter;

        public AggregateRepository(IStreamWriter streamWriter)
        {
            this.streamWriter = streamWriter;
        }

        public Task<TAggregate> GetByAggregateId(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task Save(TAggregate aggregate)
        {
            await this.streamWriter.Write(aggregate);
        }
    }
}
