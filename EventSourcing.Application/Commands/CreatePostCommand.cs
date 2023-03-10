using EventSourcing.Core.Command;

namespace EventSourcing.Application.Commands;

public class CreatePostCommand : BaseCommand
{
    public string Content { get; set; }

    public string UserName { get; set; }
}
