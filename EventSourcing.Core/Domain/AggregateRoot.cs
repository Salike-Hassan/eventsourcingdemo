using Newtonsoft.Json;
using QuadPay.Domain.Core;

namespace EventSourcing.Core.Domain;

public abstract class AggregateRoot
{
    protected Guid Id;

    private readonly List<Event> changes = new();

    public abstract string StreamPrefix { get; }

    protected Type AggregateType => typeof(AggregateRoot);

    [JsonIgnore]
    public int Version { get; set; } = -1;

    public IEnumerable<Event> GetUncommittedChanges()
    {
        return changes;
    }

    public void MarkChangesAsCommitted()
    {
        changes.Clear();
    }

    public Guid GetAggregateId()
    {
        return Id;
    }

    protected void RaiseEvent(Event @event)
    {
        ApplyChange(@event, true);
    }

    public void ReplayEvents(IEnumerable<Event> events)
    {
        foreach (var @event in events)
        {
            ApplyChange(@event, false);
        }
    }

    private void ApplyChange(Event @event, bool isNew)
    {
        var method = this.GetType().GetMethod("Apply", new Type[] { @event.GetType() });

        if (method == null)
        {
            throw new ArgumentNullException(nameof(method), $"The Apply method was not found in the aggregate for {@event.GetType().Name}!");
        }

        method.Invoke(this, new object[] { @event });

        if (isNew)
        {
            changes.Add(@event);
        }
    }
}
