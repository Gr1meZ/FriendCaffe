namespace FriendCaffe.Domain.SeedWork;

public class BusinessRuleValidationException : Exception
{
    private readonly IBusinessRule _brokenRule;

    private readonly string _details;

    public BusinessRuleValidationException(IBusinessRule brokenRule) : base(brokenRule.Message)
    {
        _brokenRule = brokenRule;
        _details = brokenRule.Message;
    }

    public override string ToString()
    {
        return $"{_brokenRule.GetType().FullName}: {_details}";
    }
}