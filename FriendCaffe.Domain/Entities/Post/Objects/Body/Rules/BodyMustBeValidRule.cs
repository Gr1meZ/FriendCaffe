using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Entities.Post.Objects.Body.Rules;

public class BodyMustBeValidRule : IBusinessRule
{
    private readonly string _body;

    public BodyMustBeValidRule(string body)
    {
        _body = body;
    }

    public bool IsBroken() => string.IsNullOrWhiteSpace(_body) || _body.Length > 200;

    public string Message => "Post's body is empty or length is above 200";
}