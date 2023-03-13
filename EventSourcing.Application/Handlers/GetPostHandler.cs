//using EventSourcing.Application.Queries;
//using EventSourcing.Application.Repositories;
//using EventSourcing.Domain;
//using MediatR;

//namespace EventSourcing.Application.Handlers;

//public class GetPostHandler : IRequestHandler<GetPost, Post>
//{
//    private readonly IPostAggregateRepository repository;

//    public GetPostHandler(IPostAggregateRepository repository)
//    {
//        this.repository = repository;
//    }

//    public async Task<Post> Handle(GetPost request, CancellationToken cancellationToken)
//    {
//        return await this.repository.GetById(request.Id, cancellationToken);
//    }
//}
