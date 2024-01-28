using FriendCaffe.Application.Configuration.Commands;
using FriendCaffe.Application.Configuration.Queries;

namespace FriendCaffe.Application.Authentication.Login;

public record LoginQuery : IQuery<AuthenticationResult>
{
    public string Email { get; set; }
    public string Password { get; set; }

}