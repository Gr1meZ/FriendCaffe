using DevOne.Security.Cryptography.BCrypt;
using FriendCaffe.Domain.SeedWork;
using static System.Text.RegularExpressions.Regex;

namespace FriendCaffe.Domain.Entities.User.Objects.Password.Rules;

public class PasswordMustBeValidRule : IBusinessRule
{
    private readonly string _password;

    public PasswordMustBeValidRule(string password)
    {
        _password = password;
    }

    public bool IsBroken()
    {
        const string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$";
        return !IsMatch(_password, pattern);
    }

    public string Message => "Password is not valid. Try another one";
}