using System.Linq.Expressions;

namespace DesignPatterns.Behavioral.Specification;

public class MovieRepository: IMovieRepository
{
    private readonly List<Movie> _movies =
    [
        new Movie
        {
            Name = "Barbie",
            ReleaseDate = DateTime.Now.AddMonths(-3),
            Rating = 3.4,
            MpaaRating = MpaaRating.G
        },
        new Movie
        {
            Name = "Oppenheimer",
            ReleaseDate = DateTime.Now.AddMonths(-7),
            Rating = 4.8,
            MpaaRating = MpaaRating.R
        }
    ];

    public IReadOnlyList<Movie> GetList(bool forKidsOnly, double minimumRating, bool availableOnCd)
    {
        return _movies.Where(x =>
                (x.MpaaRating <= MpaaRating.PG || !forKidsOnly) &&
                x.Rating >= minimumRating &&
                (x.ReleaseDate <= DateTime.Now.AddMonths(-6) || !availableOnCd))
            .ToList();
    }

    public IReadOnlyList<Movie> GetList(Expression<Func<Movie, bool>> expression)
    {
        return _movies.AsQueryable().Where(expression).ToList();
    }

    public IReadOnlyList<Movie> GetList(GenericSpecification<Movie> specification)
    {
        return _movies.AsQueryable().Where(specification.Expression).ToList();
    }

    public IReadOnlyList<Movie> GetList(Specification<Movie> specification, double minimumRating)
    {
        return _movies
            .AsQueryable()
            .Where(specification.ToExpression())
            .Where(x => x.Rating >= minimumRating)
            .ToList();
    }
    public Movie? GetById(Guid id)
    {
        return _movies.FirstOrDefault(x => x.Id == id);
    }
}