using System.Linq.Expressions;

namespace DesignPatterns.Behavioral.Specification;

public sealed class MovieForKidsSpecification: Specification<Movie>
{
    public override Expression<Func<Movie, bool>> ToExpression()
    {
        return x => x.MpaaRating <= MpaaRating.PG;
    }
}