using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Entities.User.Objects.Address.Validators;

public sealed class AddressMustBeNotNullRule : IBusinessRule
{
    private readonly string _country;
    private readonly string _street;
    private readonly string _city;

    public AddressMustBeNotNullRule(string country, string street, string city)
    {
        _country = country;
        _street = street;
        _city = city;
    }

    public bool IsBroken() => string.IsNullOrEmpty(_country) || string.IsNullOrEmpty(_street) || string.IsNullOrEmpty(_city);

    public string Message => "Some of the address values are null or empty";
}