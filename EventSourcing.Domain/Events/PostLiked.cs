using QuadPay.Domain.Core;

namespace EventSourcing.Domain.Events;

public class PostLiked : Event
{
    public Guid PostId { get; set; }

    public int TotalLikes { get; set; }
}
