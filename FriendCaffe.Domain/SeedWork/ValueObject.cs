using FluentValidation;

namespace FriendCaffe.Domain.SeedWork;

public abstract class ValueObject<T>
    where T : ValueObject<T>
{
    public override bool Equals(object obj)
    {
        return obj is T valueObject && EqualsCore(valueObject);
    }

    public override int GetHashCode()
    {
        return GetHashCodeCore();
    }

    protected abstract int GetHashCodeCore();

    protected abstract bool EqualsCore(T other);

    public static bool operator ==(ValueObject<T> a, ValueObject<T> b)
    {
        if (a is null && b is null)
        {
            return true;
        }

        if (a is null || b is null)
        {
            return false;
        }

        return a.Equals(b);
    }

    protected static void CheckRule(IBusinessRule rule)
    {
        if ( rule.IsBroken())
        {
            throw new DomainException(rule);
        }
    }
    
    protected static async Task CheckRuleAsync(IBusinessRuleAsync rule)
    {
        if (await rule.IsBrokenAsync())
        {
            throw new EntityValidationException(rule);
        }
    }
    
    public static bool operator !=(ValueObject<T> a, ValueObject<T> b)
    {
        return !(a == b);
    }
}