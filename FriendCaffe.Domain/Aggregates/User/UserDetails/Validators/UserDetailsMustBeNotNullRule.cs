using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Aggregates.User.UserDetails.Validators;

public class UserDetailsMustBeNotNullRule : IBusinessRule
{
    private readonly string _name;
    private readonly string _surname;
    private readonly string _nickname;

    public UserDetailsMustBeNotNullRule(string name, string surname, string nickname)
    {
        _name = name;
        _surname = surname;
        _nickname = nickname;
    }
    public bool IsBroken()
    {
        return string.IsNullOrEmpty(_name) || string.IsNullOrEmpty(_surname) || string.IsNullOrEmpty(_nickname);
    }

    public string Message => "Some of the user details are null or empty";
}