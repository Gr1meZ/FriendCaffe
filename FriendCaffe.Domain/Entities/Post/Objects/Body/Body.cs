using FriendCaffe.Domain.Entities.Post.Objects.Body.Rules;
using FriendCaffe.Domain.SeedWork;

namespace FriendCaffe.Domain.Entities.Post.Objects.Body;

public sealed class Body : ValueObject<Body>
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
    
    protected override int GetHashCodeCore() => (GetType().GetHashCode() * 907) + Text.GetHashCode();


    protected override bool EqualsCore(Body other) => Text.Equals(other.Text);

}