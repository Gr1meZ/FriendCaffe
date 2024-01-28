namespace FriendCaffe.Application.Common;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}