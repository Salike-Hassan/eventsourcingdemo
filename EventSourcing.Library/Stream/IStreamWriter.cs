using EventSourcing.Core.Domain;
using QuadPay.Domain.Core;

namespace EventSourcing.Library.Stream;

public interface IStreamWriter
{
    Task Write(IEnumerable<Event> events, string streamId, KeyValuePair<string, string>[] headers, long version);
}
