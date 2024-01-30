using DevOne.Security.Cryptography.BCrypt;
using FriendCaffe.Domain.Entities.User.Objects.Password.Rules;
using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Entities.User.Objects.Password;

public sealed class Password : ValueObject<Password>
{
    private Password(string hash)
    {
        Hash = hash;
    }
    
    public string Hash { get; private set; }

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
    
    protected override int GetHashCodeCore() => (GetType().GetHashCode() * 907) + Hash.GetHashCode();
    
    protected override bool EqualsCore(Password other) => Hash.Equals(other.Hash);

}