using FriendCaffe.Application.Auth;
using FriendCaffe.Application.Configuration.Commands;
using FriendCaffe.Domain.Entities.User;
using FriendCaffe.Domain.Entities.User.Objects.Email;
using FriendCaffe.Domain.Entities.User.Objects.Password;
using FriendCaffe.Domain.Entities.User.Objects.UserDetails;

namespace FriendCaffe.Application.Authentication.Register;

public class RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    : ICommandHandler<RegisterCommand, AuthenticationResult>
{
    public async Task<AuthenticationResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
            var email = Email.Create(request.Email);
            var password = Password.Create(request.Password);
            var userDetails = UserDetails.Create(request.Name, request.Surname, request.Nickname);

            var user = User.Create(email, password, userDetails);
            
            await userRepository.AddAsync(user);
        
            var token = jwtTokenGenerator.GenerateToken(user);
        
            return new AuthenticationResult(user.Id, user.Email.Value, token);
        }
    }


