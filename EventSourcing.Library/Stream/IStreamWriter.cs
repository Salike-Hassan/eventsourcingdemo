using EventSourcing.Core.Domain;

namespace EventSourcing.Library.Stream;

public interface IStreamWriter
{
    Task Write(AggregateRoot aggregate, KeyValuePair<string, string>[] headers, string streamId, long version);
}
