using EventSourcing.Domain;
using MediatR;

namespace EventSourcing.Application.Commands;

public class CreatePost : IRequest<Post>
{
    public CreatePost(string content)
    {
        this.Content = content;
    }

    public string Content { get; }
}