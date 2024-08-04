using System.Linq.Expressions;

namespace DesignPatterns.Behavioral.Specification;

public abstract class Specification<T>
{
    public static readonly Specification<T> All = new IdentitySpecification<T>();
    
    public bool IsSatisfiedBy(T entity)
    {
        return ToExpression().Compile().Invoke(entity);
    }
    
    public abstract Expression<Func<T, bool>> ToExpression();

    public Specification<T> And(Specification<T> spec)
    {
        if (this == All) return spec;
        if (spec == All) return this;
        
        return new AndSpecification<T>(this, spec);
    }
    
    public Specification<T> Or(Specification<T> spec)
    {
        if (spec == All || this == All) return All;
        
        return new OrSpecification<T>(this, spec);
    }
    
    public Specification<T> Not()
    {
        return new NotSpecification<T>(this);
    }
}

internal sealed class AndSpecification<T>(Specification<T> left, Specification<T> right) : Specification<T>
{
    public override Expression<Func<T, bool>> ToExpression()
    {
        var leftExpression = left.ToExpression();
        var rightExpression = right.ToExpression();
        var andExpression = Expression.AndAlso(leftExpression.Body, rightExpression.Body);
        return Expression.Lambda<Func<T, bool>>(andExpression, leftExpression.Parameters.Single());
    }
}

internal sealed class OrSpecification<T>(Specification<T> left, Specification<T> right) : Specification<T>
{
    public override Expression<Func<T, bool>> ToExpression()
    {
        var leftExpression = left.ToExpression();
        var rightExpression = right.ToExpression();
        var orExpression = Expression.OrElse(leftExpression.Body, rightExpression.Body);
        return Expression.Lambda<Func<T, bool>>(orExpression, leftExpression.Parameters.Single());
    }
}


internal sealed class NotSpecification<T>(Specification<T> spec) : Specification<T>
{
    public override Expression<Func<T, bool>> ToExpression()
    {
        var expression = spec.ToExpression();
        var notExpression = Expression.Not(expression.Body);
        return Expression.Lambda<Func<T, bool>>(notExpression, expression.Parameters.Single());
    }
}

internal sealed class IdentitySpecification<T> : Specification<T>
{
    public override Expression<Func<T, bool>> ToExpression()
    {
        return _ => true;
    }
}