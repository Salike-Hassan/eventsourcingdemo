using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Library.Metadata;

public interface IMetadataResolver
{
    IDictionary<string, string> Resolve(object @event);
}
