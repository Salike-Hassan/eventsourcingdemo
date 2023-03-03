using EventSourcing.Domain;
using MediatR;

namespace EventSourcing.Application.Queries;

public class GetPost : IRequest<Post>
{
    public GetPost(Guid id)
    {
        this.Id = id;
    }

    public Guid Id { get; }
}
