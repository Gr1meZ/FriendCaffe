using FriendCaffe.Domain.Aggregates.Post.Body.Rules;
using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Aggregates.Post.Body;

public sealed class Body : ValueObject
{
    private Body(string text)
    {
        Text = text;
    }

    public string Text { get; private set; }


    public static Body Create(string body)
    {
        CheckRule(new BodyMustBeValidRule(body));
        return new Body(body);
    }

    public void Change(string body)
    {
        CheckRule(new BodyMustBeValidRule(body));
        Text = body;
    }

    protected override IEnumerable<object?> GetEqualityComponents()
    {
        yield return Text;
    }
}