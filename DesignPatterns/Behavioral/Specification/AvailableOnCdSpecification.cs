using System.Linq.Expressions;

namespace DesignPatterns.Behavioral.Specification;

public class AvailableOnCdSpecification: Specification<Movie>
{
    private const int MonthsBeforeDvdIsOut = 6;
    
    public override Expression<Func<Movie, bool>> ToExpression()
    {
        return x => x.ReleaseDate < DateTime.UtcNow.AddMonths(-MonthsBeforeDvdIsOut);
    }
}