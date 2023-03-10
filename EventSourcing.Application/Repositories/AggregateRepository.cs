using EventSourcing.Core.Domain;
using EventSourcing.Core.Stream;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Repositories
{
    public class AggregateRepository : IAggregateRepository
    {
        private readonly IStreamWriter streamWriter;

        public AggregateRepository(IStreamWriter streamWriter)
        {
            this.streamWriter = streamWriter;
        }
        public async Task Write(AggregateRoot aggregate)
        {
            await this.streamWriter.Write(aggregate);
        }
    }
}
