using FriendCaffe.Domain.Entities.User.Objects.UserDetails.Validators;
using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Entities.User.Objects.UserDetails;

public sealed class UserDetails : ValueObject<UserDetails>
{
    public string Name { get; private set; }
    public string Surname { get; private set; }
    public string Nickname { get; private set; }
    public string? About { get; private set; }
    
    private UserDetails(string name, string surname, string nickname)
    {
        Name = name;
        Surname = surname;
        Nickname = nickname;
    }

    public static async Task<UserDetails> CreateAsync(string name, string surname, string nickname, IUserRepository userRepository)
    {
        CheckRule(new UserDetailsMustBeNotNullRule(name, surname, nickname));
        CheckRule(new NickNameMustBeValidRule(nickname));
        await CheckRuleAsync(new NicknameMustBeUniqueRule(userRepository, nickname));
        
        return new UserDetails(name, surname, nickname);
    }

    public void CreateAbout(string about)
    {
        CheckRule(new AboutMustHaveValidLengthRule(about));
        About = about;
    }
    
    protected override int GetHashCodeCore() => (GetType().GetHashCode() * 907) + About.GetHashCode() + Nickname.GetHashCode();


    protected override bool EqualsCore(UserDetails other)
    {
        return Nickname.Equals(other.Nickname) && Name.Equals(other.Name) && Surname.Equals(other.Surname);
    }
}