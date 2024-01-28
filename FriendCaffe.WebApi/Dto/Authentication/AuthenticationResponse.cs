namespace FriendCaffe.WebApi.Dto.Authentication;

public record AuthenticationResponse
{
    public Guid UserId { get; init; }
    public string Email { get; init; }
    public string Token { get; init; }
}