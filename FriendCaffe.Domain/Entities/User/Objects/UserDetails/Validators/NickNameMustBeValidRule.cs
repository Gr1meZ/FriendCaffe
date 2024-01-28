using System.Text.RegularExpressions;
using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Entities.User.Objects.UserDetails.Validators;

public class NickNameMustBeValidRule(string nickname) : IBusinessRule
{
    public bool IsBroken()
    {
        var pattern = new Regex(@"^[^0-9][^@#]+$");
        return !pattern.IsMatch(nickname);
    }

    public string Message => "Nickname must be valid";

}