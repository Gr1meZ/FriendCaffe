namespace FriendCaffe.WebApi.Dto.Authentication;

public class RegisterRequest
{
    public string Email { get; set;}
    public string Nickname { get; set; }
    public string Name { get;  set; }
    public string Surname { get;  set; }
    public string Password { get; set; }
    public string RepeatPassword { get; set; }

}