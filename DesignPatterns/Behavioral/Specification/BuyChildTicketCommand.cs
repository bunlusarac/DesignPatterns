namespace DesignPatterns.Behavioral.Specification;

public class BuyChildTicketCommand(Guid movieId, IMovieRepository movieRepository) : ICommand
{
    public void Execute()
    {
        var movie = movieRepository.GetById(movieId);
        if (movie is null) return;

        /*
        var isSuitableForChildren = Movie.IsSuitableForChildren.Compile();
        if (!isSuitableForChildren(movie))
        {
            throw new Exception("The movie is not suitable for children.");
        }*/
        
        //var spec = new GenericSpecification<Movie>(x => x.MpaaRating <= MpaaRating.PG);

        var spec = new MovieForKidsSpecification();
        
        if (!spec.IsSatisfiedBy(movie))
        {
            throw new Exception("The movie doesn't have a CD version.");
        }
    }
}