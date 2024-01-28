using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Entities.User.Objects.Email.Validators;

public class EmailMustBeUniqueRule : IBusinessRuleAsync
{
    private readonly string _email;
    private readonly IUserRepository _userRepository;
    public EmailMustBeUniqueRule(string email, IUserRepository userRepository)
    {
        _email = email;
        _userRepository = userRepository;
    }

    public async Task<bool> IsBrokenAsync() => await _userRepository.IsEmailExists(_email);
   

    public string Message => "Email is already taken";
}