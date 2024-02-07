using FriendCaffe.Domain.Aggregates.User.Address.Validators;
using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Aggregates.User.Address;

public sealed class Address : ValueObject
{
    private Address(string street, string country, string city)
    {
        Street = street;
        Country = country;
        City = city;
    }

    public  string Country { get; private set; }
    public  string Street { get;  private set;}
    public  string City { get;  private set;}

    public static Address Create(string street, string country, string city)
    {
        CheckRule(new AddressMustBeNotNullRule(country, street, city));
        return new Address(street, country, city);
    }

    public void Change(string street, string country, string city)
    {
        CheckRule(new AddressMustBeNotNullRule(country, street, city));
        Country = country;
        Street = street;
        City = city;
    }


    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return Country;
        yield return City;
    }
}