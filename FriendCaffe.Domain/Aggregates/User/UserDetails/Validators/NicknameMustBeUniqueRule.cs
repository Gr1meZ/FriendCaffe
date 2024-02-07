using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Aggregates.User.UserDetails.Validators;

public class NicknameMustBeUniqueRule : IBusinessRule
{
    private readonly IUserRepository _userRepository;
    private readonly string _nickname;

    public NicknameMustBeUniqueRule(IUserRepository userRepository, string nickname)
    {
        _userRepository = userRepository;
        _nickname = nickname;
    }

    public  bool IsBroken() =>  _userRepository.IsNicknameExists(_nickname);
    
    public string Message => "Username is already taken";
}