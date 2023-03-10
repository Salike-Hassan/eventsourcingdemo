using EventSourcing.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Core.Stream
{
    public interface IStreamWriter
    {
        Task Write(AggregateRoot aggregate);
    }
}
