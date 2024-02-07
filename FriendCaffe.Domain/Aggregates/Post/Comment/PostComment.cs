using FriendCaffe.Domain.Aggregates.User.UserId;
using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Aggregates.Post.Comment;

public class PostComment : Entity
{
    private PostComment(Objects.Body.PostId.PostId postId, UserId userId, Objects.Body.Body body)
    {
        UserId = userId;
        Body = body;
    }
    
    protected PostComment(){}
    
    public Guid PostId { get; private set; }
    public UserId UserId { get; private set; }
    public Objects.Body.Body Body { get; private set; }

    public static PostComment Create(Objects.Body.PostId.PostId postId, UserId userId, Objects.Body.Body body)
    {
        return new PostComment(postId, userId, body);
    }
}