using EventSourcing.Core.Domain;
using EventSourcing.Domain.Events;

namespace EventSourcing.Domain
{
    public class PostAggregate : AggregateRoot
    {
        private bool isActivePost;
        private string content;

        public readonly KeyValuePair<string, string>[] DefaultHeaders = new[]
        {
            new KeyValuePair<string, string>("ClrType", typeof(AggregateRoot).AssemblyQualifiedName),
         };

        public override string StreamPrefix => "SocialMediaPost-";

        public PostAggregate() { }

        public PostAggregate(Guid id, string content)
        {
            RaiseEvent(new SocialMediaPostCreated()
            {
                PostId = id,
                Content = content,
                IsActivePost = true,
                Timestamp = DateTime.UtcNow,
            });
        }

        public void Apply(SocialMediaPostCreated @event)
        {
            Id = @event.PostId;
            isActivePost = @event.IsActivePost;
            content = @event.Content;
        }

        public void LikePost()
        {
            if (!isActivePost)
            {
                throw new InvalidOperationException("You cannot like an inactive post!");
            }

            else
            {
                RaiseEvent(new PostLiked()
                {
                    PostId = Id
                });
            }
        }

        public void Apply(PostLiked @event)
        {
            Id = @event.PostId;
        }
    }
}
