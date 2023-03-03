using EventSourcing.Domain;

namespace EventSourcing.Application.Repositories;

public interface IPostAggregateRepository
{
    Task<Post> GetById(Guid postId, CancellationToken cancellationToken);

    Task<long> Save(Post aggregate);
}

