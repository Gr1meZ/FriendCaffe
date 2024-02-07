using FriendCaffe.Domain.Aggregates.User.UserDetails.Validators;
using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Aggregates.User.UserDetails;

public sealed class UserDetails : ValueObject
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

    public static UserDetails Create(string name, string surname, string nickname, IUserRepository userRepository)
    {
        CheckRule(new UserDetailsMustBeNotNullRule(name, surname, nickname));
        CheckRule(new NickNameMustBeValidRule(nickname));
        CheckRule(new NicknameMustBeUniqueRule(userRepository, nickname));
        
        return new UserDetails(name, surname, nickname);
    }

    public void CreateAbout(string about)
    {
        CheckRule(new AboutMustHaveValidLengthRule(about));
        About = about;
    }

    public void Change(string name, string surname, string nickname, IUserRepository userRepository)
    {
        CheckRule(new UserDetailsMustBeNotNullRule(name, surname, nickname));
        if (nickname != Nickname)
        {
            CheckRule(new NickNameMustBeValidRule(nickname));
            CheckRule(new NicknameMustBeUniqueRule(userRepository, nickname));
        }

        Name = name;
        Surname = surname;
        Nickname = nickname;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Name;
        yield return Surname;
        yield return Nickname;
        yield return About;
    }
}