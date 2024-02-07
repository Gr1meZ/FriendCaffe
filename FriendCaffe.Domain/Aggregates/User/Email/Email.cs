using FriendCaffe.Domain.Aggregates.User.Email.Validators;
using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Aggregates.User.Email;

public sealed class Email : ValueObject
{
    private Email(string value)
    {
        Value = value;
    }
    public string Value { get; private set; }

    public static Email Create(string value, IUserRepository userRepository)
    {
       CheckRule(new EmailMustBeValidRule(value));
       CheckRule(new EmailMustBeUniqueRule(value, userRepository));
       return new Email(value);
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
   
}