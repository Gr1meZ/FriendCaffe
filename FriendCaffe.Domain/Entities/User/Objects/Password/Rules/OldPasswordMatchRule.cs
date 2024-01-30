using DevOne.Security.Cryptography.BCrypt;
using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Entities.User.Objects.Password.Rules;

public class OldPasswordMatchRule : IBusinessRule
{
    private readonly string _oldPassword;
    private readonly string _currentHash;

    public OldPasswordMatchRule(string oldPassword, string currentHash)
    {
        _oldPassword = oldPassword;
        _currentHash = currentHash;
    }

    public bool IsBroken() => !BCryptHelper.CheckPassword(_oldPassword, _currentHash);


    public string Message => "The old password is not valid";
}