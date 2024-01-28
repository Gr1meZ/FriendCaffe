namespace FriendCaffe.Domain.SeedWork;

public class EntityValidationException : Exception
{
    private readonly IBusinessRuleAsync _brokenRule;

    private readonly string _details;

    public EntityValidationException(IBusinessRuleAsync brokenRule) : base(brokenRule.Message)
    {
        _brokenRule = brokenRule;
        _details = brokenRule.Message;
    }

    public override string ToString()
    {
        return $"{_brokenRule.GetType().FullName}: {_details}";
    }
}