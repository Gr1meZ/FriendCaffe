using FriendCaffe.Domain.Entities.User.Objects.UserDetails.Validators;
using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Entities.User.Objects.UserDetails;

public sealed class UserDetails : ValueObject<UserDetails>
{
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string Nickname { get; private set; }
    public string About { get; private set; }
    
    private UserDetails(string name, string surname, string nickname, string about)
    {
        Name = name;
        Surname = surname;
        Nickname = nickname;
        About = about;
    }

    public static UserDetails Create(string name, string surname, string nickname, string about)
    {
        CheckRule(new UserDetailsMustBeNotNull(name, surname, nickname, about));
        CheckRule(new AboutMustHaveValidLength(about));
        CheckRule(new NickNameMustBeValid(nickname));

        return new UserDetails(name, surname, nickname, about);
    }
    
    protected override int GetHashCodeCore() => (GetType().GetHashCode() * 907) + About.GetHashCode() + Nickname.GetHashCode();
    

    protected override bool EqualsCore(UserDetails other)
    {
        return Nickname.Equals(other.Nickname) && Name.Equals(other.Name) && Surname.Equals(other.Surname) &&
               About.Equals(other.About);
    }

    
}