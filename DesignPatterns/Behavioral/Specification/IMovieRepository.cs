using System.Linq.Expressions;

namespace DesignPatterns.Behavioral.Specification;

public interface IMovieRepository
{
    IReadOnlyList<Movie> GetList(bool forKidsOnly, double minimumRating, bool availableOnCd);
    IReadOnlyList<Movie> GetList(Expression<Func<Movie, bool>> expression);
    IReadOnlyList<Movie> GetList(GenericSpecification<Movie> specification);
    IReadOnlyList<Movie> GetList(Specification<Movie> specification, double minimumRating);
    Movie? GetById(Guid id);
}