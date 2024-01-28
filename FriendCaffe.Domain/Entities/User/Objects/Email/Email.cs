using FriendCaffe.Domain.Entities.User.Objects.Email.Validators;
using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Entities.User.Objects.Email;

public sealed class Email() : ValueObject<Email>
{
    private Email(string value) : this() => Value = value;
    public string Value { get; private set; }

    public static Email Create(string value)
    {
       CheckRule(new EmailMustBeValidRule(value));
       return new Email(value);
    }
    
    protected override int GetHashCodeCore() => (GetType().GetHashCode() + Value.GetHashCode());


    protected override bool EqualsCore(Email other) => Value.Equals(other.Value);

}