using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Aggregates.User.Email.Validators;

public class EmailMustBeUniqueRule : IBusinessRule
{
    private readonly string _email;
    private readonly IUserRepository _userRepository;
    public EmailMustBeUniqueRule(string email, IUserRepository userRepository)
    {
        _email = email;
        _userRepository = userRepository;
    }

    public bool IsBroken() =>  _userRepository.IsEmailExists(_email);
    
    public string Message => "Email is already taken";
}