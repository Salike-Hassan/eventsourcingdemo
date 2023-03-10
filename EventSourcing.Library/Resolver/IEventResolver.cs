using EventStore.ClientAPI;
using QuadPay.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Library.Resolver;

public interface IEventResolver
{
    EventData Resolve(object @event, params KeyValuePair<string, string>[] extraHeaders);

    Event Resolve(ResolvedEvent @event);

    IDictionary<string, string> ResolveMetadata(ResolvedEvent @event);
}
