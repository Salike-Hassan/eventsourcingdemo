using QuadPay.Domain.Core;

namespace EventSourcing.Library.Stream;

public interface IStreamReader
{
    Task<List<Event>> FindAggregateById(string streamId, CancellationToken ct, int readPageSize = 500);
}
