namespace FriendCaffe.Domain.SeedWork;

public interface IBusinessRuleAsync
{
    Task<bool> IsBrokenAsync();
    string Message { get; }
}