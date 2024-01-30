using FriendCaffe.Domain.Entities.Post.Aggregates.Comment.Objects.Body;
using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Entities.Post.Aggregates.Comment;

public class PostComment : Entity
{
    private PostComment(Guid userId, Body body)
    {
        UserId = userId;
        Body = body;
    }
    
    protected PostComment(){}
    
    public Guid UserId { get; private set; }
    public Body Body { get; private set; }

    public static PostComment Create(Guid userId, Body body)
    {
        return new PostComment(userId, body);
    }
}