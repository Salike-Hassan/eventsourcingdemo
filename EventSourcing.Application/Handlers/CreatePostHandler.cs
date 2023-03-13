﻿//using EventSourcing.Application.Commands;
//using EventSourcing.Application.Repositories;
//using EventSourcing.Domain;
//using MediatR;

//namespace EventSourcing.Application.Handlers;

//public class CreatePostHandler : IRequestHandler<CreatePost, Post>
//{
//    private readonly IAggregateRepository repository;

//    public CreatePostHandler(IAggregateRepository repository)
//    {
//        this.repository = repository;
//    }
//    public async Task<Post> Handle(CreatePost request, CancellationToken cancellationToken)
//    {
//        var post = Post.Create(Guid.NewGuid(), request.Content);

//        await this.repository.SaveEventsAsync(post);

//        //TODO: GetById implimentation not done yet.
//        return await this.repository.GetById(post.Id, cancellationToken);
//    }
//}
