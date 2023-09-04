namespace DesignPatterns.Behavioral.Strategy;

public class Point
{
    public double X { get; set; }
    public double Y { get; set; }

    public IDistanceStrategy DistanceStrategy { get; set; } = new EuclideanDistanceStrategy();
    
    //Non-strategy method
    public double CalculateDistance(Point other, string norm = "euclidean")
    {
        if (norm == "euclidean")
        {
            return Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2));
        }
        else if (norm == "manhattan")
        {
            return Math.Abs(X - other.X) + Math.Abs(Y - other.Y);
        }
        else
        {
            throw new InvalidOperationException();
        }
    }
    
    //Strategy method
    public double CalculateDistanceWithStrategy(Point other, IDistanceStrategy? distanceStrategy = default)
    {
        var strategy = distanceStrategy ?? DistanceStrategy;
        if (strategy is null) throw new InvalidOperationException();
        return strategy.CalculateDistance(this, other);
    }
}