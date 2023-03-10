using EventSourcing.Domain;
using Microsoft.Extensions.Logging;
using QuadPay.EventStore.EventStore;

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

    public async Task<long> Save(Post aggregate)
    {
        return await base.Save(aggregate);
    }

    public override async Task<Post> GetById(Guid postId, CancellationToken cancellationToken)
    {
        return await base.GetById(postId, cancellationToken);
    }
}
