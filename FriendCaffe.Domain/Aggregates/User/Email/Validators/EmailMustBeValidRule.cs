using System.ComponentModel.DataAnnotations;
using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Aggregates.User.Email.Validators;

public class EmailMustBeValidRule : IBusinessRule
{
    public EmailMustBeValidRule(string email)
    {
        _email = email;
    }

    private string _email;
    public bool IsBroken()
    {
        var emailAttribute = new EmailAddressAttribute();
        return !emailAttribute.IsValid(_email);
    }

    public string Message => "Email format is not valid";
}