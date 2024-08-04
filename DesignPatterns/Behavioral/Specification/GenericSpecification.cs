using System.Linq.Expressions;

namespace DesignPatterns.Behavioral.Specification;

public class GenericSpecification<T>(Expression<Func<T, bool>> expression)
{
    public Expression<Func<T, bool>> Expression { get; } = expression;

    public bool IsSatisfiedBy(T entity)
    {
        return Expression.Compile().Invoke(entity);
    }
}