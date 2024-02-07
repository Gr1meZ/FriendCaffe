using FriendCaffe.Domain.Aggregates.User.UserId;
using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Aggregates.Post;

public class Post : Entity
{
    private Post(UserId creatorId, Body.Body body, DateTime createAt)
    {
        Id = Guid.NewGuid();
        Body = body;
        CreatorId = creatorId;
        CreatedAt = createAt;
    }
    
    protected Post(){}
    
    public UserId CreatorId { get; private set; }
    public DateTime CreatedAt { get; private init; }
    public Body.Body Body { get; private set; }
    
    public static Post Create(UserId userId, Body.Body body, DateTime createAt)
    {
        return new Post(userId, body, createAt);
    }
    
}