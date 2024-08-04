namespace DesignPatterns.Behavioral.Specification;

public class BuyCdCommand(Guid movieId, IMovieRepository movieRepository) : ICommand
{
    public void Execute()
    {
        var movie = movieRepository.GetById(movieId);
        if (movie is null) return;

        /*
        var hasCDVersion = Movie.HasCDVersion.Compile();
        
        if (!hasCDVersion(movie))
        {
            throw new Exception("The movie doesn't have a CD version.");
        }
        */

        //var spec = new GenericSpecification<Movie>(x => x.ReleaseDate <= DateTime.Now.AddMonths(-9));

        var spec = new AvailableOnCdSpecification();
        
        if (!spec.IsSatisfiedBy(movie))
        {
            throw new Exception("The movie doesn't have a CD version.");
        }
    }
}