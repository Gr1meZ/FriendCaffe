using FriendCaffe.Application.Configuration.Commands;

namespace FriendCaffe.Application.Authentication.Register;

public record RegisterCommand : ICommand<AuthenticationResult>
{
    public Guid Id { get; set; }
    public string Email { get; init;}
    public string Nickname { get; init; }
    public string Name { get;  init; }
    public string Surname { get;  init; }
    public string Password { get; init; }
    
}