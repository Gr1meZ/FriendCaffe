using FriendCaffe.Application.Auth;
using FriendCaffe.Application.Configuration.Commands;
using FriendCaffe.Domain.Entities.User;
using FriendCaffe.Domain.Entities.User.Objects.Email;
using FriendCaffe.Domain.Entities.User.Objects.Password;
using FriendCaffe.Domain.Entities.User.Objects.UserDetails;
using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Application.Authentication.Register;

public class RegisterCommandHandler
    : ICommandHandler<RegisterCommand, AuthenticationResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    public RegisterCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IJwtTokenGenerator jwtTokenGenerator)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<AuthenticationResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
            var email = Email.Create(request.Email);
            var password = Password.Create(request.Password);
            var userDetails = UserDetails.Create(request.Name, request.Surname, request.Nickname);

            var user = User.Create(email, password, userDetails);
            
            await _userRepository.AddAsync(user);
        
            var token = _jwtTokenGenerator.GenerateToken(user);
            await _unitOfWork.CommitAsync(cancellationToken);
            return new AuthenticationResult(user.Id, user.Email.Value, token);
        }
    }


