namespace EventSourcing.Library.Stream;

public interface IStreamReader
{
    Task FindAggregateById(string aggregateId);
}
