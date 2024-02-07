using FriendCaffe.Domain.Aggregates.Post.Comment.Objects.Body.Rules;
using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Aggregates.Post.Comment.Objects.Body;

public sealed class Body : ValueObject
{
    private Body(string text)
    {
        Text = text;
    }

    public string Text { get; private set; }
    
    public static Body Create(string body)
    {
        CheckRule(new PostCommentBodyMustBeValidRule(body));
        return new Body(body);
    }

    public void Change(string body)
    {
        CheckRule(new PostCommentBodyMustBeValidRule(body));
        Text = body;
    }
    
    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Text;
    }
}