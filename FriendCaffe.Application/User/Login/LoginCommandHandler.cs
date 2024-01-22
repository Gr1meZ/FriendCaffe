using FriendCaffe.Application.Configuration.Commands;

namespace FriendCaffe.Application.User.Login;

public class LoginCommandHandler : ICommandHandler<LoginCommand>
{
    public Task Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}