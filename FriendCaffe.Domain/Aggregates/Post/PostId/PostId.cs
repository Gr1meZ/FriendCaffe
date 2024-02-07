using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Aggregates.Post.PostId;

public sealed class PostId : ValueObject
{
    public PostId()
    {
        Value = Guid.NewGuid();
    }

    public Guid Value { get; private set; }
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}