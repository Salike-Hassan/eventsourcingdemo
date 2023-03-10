using EventSourcing.Application.Commands;

namespace EventSourcing.Application.Handlers;

public class CommandHandler : ICommandHandler
{
    public Task HandleAsync(CreatePostCommand command)
    {
        throw new NotImplementedException();
    }
}
