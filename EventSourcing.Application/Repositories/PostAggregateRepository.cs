using EventSourcing.Domain;
using Microsoft.Extensions.Logging;
using QuadPay.EventStore.EventStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Application.Repositories;

public class PostAggregateRepository : AggregateRepository<Post>, IPostAggregateRepository
{
    public PostAggregateRepository(IEventStoreStreamReader streamReader,
        IEventStoreStreamWriter streamWriter,
        ILogger<AggregateRepository<Post>> logger)
        : base(streamReader, streamWriter, logger)
    {
    }
    public override string StreamPrefix => "post-";

    public Task<long> Save(Post aggregate)
    {
        return base.Save(aggregate);
    }
}
