using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Entities.Post.Aggregates.Comment.Objects.Body.Rules;

public class PostCommentBodyMustBeValidRule : IBusinessRule
{
    private readonly string _body;

    public PostCommentBodyMustBeValidRule(string body)
    {
        _body = body;
    }

    public bool IsBroken() => string.IsNullOrWhiteSpace(_body) || _body.Length > 200;

    public string Message => "Comment's body is empty or length is above 200";
}