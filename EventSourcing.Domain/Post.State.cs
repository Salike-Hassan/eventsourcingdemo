using EventSourcing.Domain.Events;
using QuadPay.Domain.Core.Aggregate;

namespace EventSourcing.Domain;
public partial class Post
{
    public class State : AggregateState
    {
        private Post Aggregate { get; set; }

        public Guid PostId { get; set; }

        public string Content { get; set; }

        public int TotalLikes { get; set; }

        public bool IsActive { get; set; }

        public static State For(Post aggregate)
        {
            var state = new State { Aggregate = aggregate };
            return state;
        }

        public void Apply(SocialMediaPostCreated @event)
        {
            this.SetId(@event.PostId);
            this.PostId = @event.PostId;
            this.Content = @event.Content;
            this.IsActive = true;
            this.TotalLikes = 0;
        }

        public void Apply(PostLiked @event)
        {
            this.TotalLikes = @event.TotalLikes;
        }
    }
}