using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Aggregates.User.UserDetails.Validators;

public class AboutMustHaveValidLengthRule : IBusinessRule
{
    private readonly string _about;

    public AboutMustHaveValidLengthRule(string about)
    {
        _about = about;
    }

    public bool IsBroken() => string.IsNullOrEmpty(_about) || _about.Length > 200 && _about.Length == 0;


    public string Message => "Length of about field must be between 0 and 200";
}