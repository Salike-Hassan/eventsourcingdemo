using EventSourcing.Application.Commands;
using EventSourcing.Domain;

namespace EventSourcing.Application.Handlers;

public class CommandHandler : ICommandHandler
{
    private readonly IEventSourcingHandler<PostAggregate> eventSourcingHandler;

    public CommandHandler(IEventSourcingHandler<PostAggregate> eventSourcingHandler)
    {
        this.eventSourcingHandler = eventSourcingHandler;
    }
    public async Task HandleAsync(CreatePostCommand command)
    {
        var aggregate = new PostAggregate(command.Id, command.Content);

        await eventSourcingHandler.SaveAsync(aggregate);
    }
}
