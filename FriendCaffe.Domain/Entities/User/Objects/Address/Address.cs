using FriendCaffe.Domain.Entities.User.Objects.Address.Validators;
using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Entities.User.Objects.Address;

public sealed class Address : ValueObject<Address>
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
    
    protected override int GetHashCodeCore() => (GetType().GetHashCode() * 907) + Street.GetHashCode() + City.GetHashCode();
    
    protected override bool EqualsCore(Address other) => Country.Equals(other.Country) && Street.Equals(other.Street) && City.Equals(City);
  
}