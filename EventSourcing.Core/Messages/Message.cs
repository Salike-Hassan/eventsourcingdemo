namespace EventSourcing.Core.Messages;

public abstract class Message
{
    public Guid Id { get; set; }
}
