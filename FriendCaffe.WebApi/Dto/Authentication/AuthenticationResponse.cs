namespace FriendCaffe.WebApi.Dto.Authentication;

public record AuthenticationResponse
{
    public Guid UserId { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }
}