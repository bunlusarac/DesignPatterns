namespace DesignPatterns.Behavioral.Specification;

public class SearchQuery: IQuery<IReadOnlyList<Movie>>
{
    public bool ForKidsOnly { get; set; }
    public double MinimumRating { get; set; }
    public bool OnCd { get; set; }
    public IMovieRepository MovieRepository { get; set; }
    
    public IReadOnlyList<Movie> Execute()
    {
        //return MovieRepository.GetList(ForKidsOnly, MinimumRating, OnCd);

        //var isSuitableForChildren = ForKidsOnly ? Movie.IsSuitableForChildren : x => true;
        
        /*
    var spec = new GenericSpecification<Movie>(x =>
        (!OnCd || x.ReleaseDate < DateTime.UtcNow.AddMonths(-6)) &&
        (!ForKidsOnly || x.MpaaRating < MpaaRating.PG));
    */

        Specification<Movie> spec = Specification<Movie>.All;

        if (ForKidsOnly)
        {
            spec = spec.And(new MovieForKidsSpecification());
        }

        if (OnCd)
        {
            spec = spec.And(new AvailableOnCdSpecification());
        }
        
        return MovieRepository.GetList(spec, MinimumRating);
    }
}