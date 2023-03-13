using EventSourcing.Application.Commands;

namespace EventSourcing.Application.Handlers;

public interface ICommandHandler
{
    Task HandleAsync(CreatePostCommand command);
}
