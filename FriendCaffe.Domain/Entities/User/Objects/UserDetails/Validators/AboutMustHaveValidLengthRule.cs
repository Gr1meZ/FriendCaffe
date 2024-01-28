using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Entities.User.Objects.UserDetails.Validators;

public class AboutMustHaveValidLengthRule : IBusinessRule
{
    private readonly string _about;

    public AboutMustHaveValidLengthRule(string about)
    {
        _about = about;
    }

    public bool IsBroken() => _about.Length is > 200 and > 0;


    public string Message => "Length of about field must be between 0 and 200";
}