using FriendCaffe.Application.Configuration.Commands;

namespace FriendCaffe.Application.User.Login;

public record class LoginCommand(string Email, string UserName, string Password, string RepeatPassword) : ICommand
{
    public Guid Id { get; }
}