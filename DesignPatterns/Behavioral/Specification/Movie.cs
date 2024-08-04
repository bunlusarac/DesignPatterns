using System.Linq.Expressions;

namespace DesignPatterns.Behavioral.Specification;

public class Movie
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } 
    public DateTime ReleaseDate { get; set; } 
    public double Rating { get; set; }
    public MpaaRating MpaaRating { get; set; }

    #region Specification

    public static readonly Expression<Func<Movie, bool>> IsSuitableForChildren = x => x.MpaaRating <= MpaaRating.PG;

    public static readonly Expression<Func<Movie, bool>> HasCdVersion = x =>
        x.ReleaseDate < DateTime.UtcNow.AddMonths(-6);

    #endregion
}