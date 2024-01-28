using FriendCaffe.Application.Common;

namespace FriendCaffe.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}