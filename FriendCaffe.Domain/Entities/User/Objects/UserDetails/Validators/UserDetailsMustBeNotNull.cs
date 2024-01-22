using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Entities.User.Objects.UserDetails.Validators;

public class UserDetailsMustBeNotNull : IBusinessRule
{
    private readonly string _name;
    private readonly string _surname;
    private readonly string _nickname;
    private readonly string _about;

    public UserDetailsMustBeNotNull(string name, string surname, string nickname, string about)
    {
        _name = name;
        _surname = surname;
        _nickname = nickname;
        _about = about;
    }
    public bool IsBroken()
    {
        return string.IsNullOrEmpty(_name) || string.IsNullOrEmpty(_surname) || string.IsNullOrEmpty(_nickname) ||
               string.IsNullOrEmpty(_about);
    }

    public string Message => "Some of the user details are null or empty";
}