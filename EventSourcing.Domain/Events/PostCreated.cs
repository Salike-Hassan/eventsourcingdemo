using QuadPay.Domain.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Domain.Events;

public class PostCreated : Event
{
    public Guid PostId { get; set; }

    public string Content { get; set; }

    public bool IsActivePost { get; set; }
}