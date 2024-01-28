using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Entities.User.Objects.UserDetails.Validators;

public class NicknameMustBeUniqueRule : IBusinessRuleAsync
{
    private readonly IUserRepository _userRepository;
    private readonly string _nickname;

    public NicknameMustBeUniqueRule(IUserRepository userRepository, string nickname)
    {
        _userRepository = userRepository;
        _nickname = nickname;
    }

    public async Task<bool> IsBrokenAsync() => await _userRepository.IsNicknameExistsAsync(_nickname);
    
    public string Message => "Username is already taken";
}