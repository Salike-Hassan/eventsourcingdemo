using EventSourcing.Core.Domain;
using EventSourcing.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventSourcing.Domain
{
    public class PostAggregate : AggregateRoot
    {
        private bool isActivePost;
        private string content;

        public PostAggregate() { }

        public PostAggregate(Guid id, string content)
        {
            RaiseEvent(new PostCreated()
            {
                PostId = id,
                Content = content,
                IsActivePost = true,
                Timestamp = DateTime.UtcNow,
            });
        }

        public void Apply(PostCreated @event)
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
