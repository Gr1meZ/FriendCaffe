using FriendCaffe.Domain.Entities.Post.Objects.Body;
using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Entities.Post;

public class Post : Entity
{
    private Post(Guid userId, Body body, DateTime createAt)
    {
        Id = Guid.NewGuid();
        Body = body;
        UserId = userId;
        CreatedAt = createAt;
    }
    
    protected Post(){}
    
    public Guid UserId { get; private set; }
    public DateTime CreatedAt { get; private init; }
    public Body Body { get; private set; }
    
    public User.User User { get; private set; }

    public static Post Create(Guid userId, Body body, DateTime createAt)
    {
        return new Post(userId, body, createAt);
    }
    
}