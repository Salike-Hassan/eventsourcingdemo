using EventSourcing.Domain.Events;
using QuadPay.Core;
using QuadPay.Domain.Core.Aggregate;

namespace EventSourcing.Domain;

public partial class Post : Aggregate<Post.State>
{
    public Post()
    {
        this.MyState = State.For(this);
    }

    public string Content
    {
        get
        {
            return this.MyState.Content;
        }
    }

    public int TotalLikes => this.MyState.TotalLikes;

    public static Post Create(Guid postId, string content)
    {
        Ensure.ArgumentNotEmpty(postId, nameof(postId));
        Ensure.ArgumentNotNullOrEmptyOrWhitespace(content, nameof(content));

        var aggregate = new Post();
        aggregate.RaiseEvent(new PostCreated
        {
            PostId = postId,
            Content = content,
            IsActivePost = true,
        });

        return aggregate;
    }
}