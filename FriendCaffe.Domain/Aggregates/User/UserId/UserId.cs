using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Aggregates.User.UserId;

public sealed class UserId : ValueObject
{
    public UserId()
    {
        Value = Guid.NewGuid();
    }

    public Guid Value { get; private set; }
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Value;
    }
}