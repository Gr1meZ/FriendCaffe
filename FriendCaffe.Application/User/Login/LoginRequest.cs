namespace FriendCaffe.Application.User.Login;

public record class LoginRequest (string Email, string UserName, string Password, string RepeatPassword)
{
    
}