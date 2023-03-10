using EventSourcing.Core.Command;

namespace EventSourcing.Core.Dispatchers;

public interface ICommandDispatcher
{
    void RegisterHandler<T>(Func<T, Task> handler) where T : BaseCommand;
    Task SendAsync(BaseCommand command);
}
