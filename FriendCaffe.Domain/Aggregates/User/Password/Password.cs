using DevOne.Security.Cryptography.BCrypt;
using FriendCaffe.Domain.Aggregates.User.Password.Rules;
using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Aggregates.User.Password;

public sealed class Password : ValueObject
{
    private Password(string hash)
    {
        Hash = hash;
    }
    
    public string Hash { get; private set; }

    //TODO make hash via DI
    public static Password Create(string value)
    {
        CheckRule(new PasswordMustBeValidRule(value));
        var salt = BCryptHelper.GenerateSalt();
        var hash = BCryptHelper.HashPassword(value, salt);
        return new Password(hash);
    }
    
    public void Change(string newPassword, string oldPassword)
    {
        CheckRule(new OldPasswordMatchRule(oldPassword, Hash));
        CheckRule(new PasswordMustBeValidRule(newPassword));
        
        var salt = BCryptHelper.GenerateSalt();
        var hash = BCryptHelper.HashPassword(newPassword, salt);
        Hash = hash;
    }
    

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Hash;
    }
}