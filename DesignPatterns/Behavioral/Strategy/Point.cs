namespace DesignPatterns.Behavioral.Strategy;

public class Point(double x, double y)
{
    public double X { get; set; } = x;
    public double Y { get; set; } = y;

    public IDistanceStrategy DistanceStrategy { get; set; } = new EuclideanDistanceStrategy();
    
    //Non-strategy method
    public double CalculateDistance(Point other, string norm = "euclidean")
    {
        return norm switch
        {
            "euclidean" => Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2)),
            "manhattan" => Math.Abs(X - other.X) + Math.Abs(Y - other.Y),
            _ => throw new InvalidOperationException()
        };
    }
    
    //Strategy method
    public double CalculateDistanceWithStrategy(Point other, IDistanceStrategy? distanceStrategy = default)
    {
        var strategy = distanceStrategy ?? DistanceStrategy;
        if (strategy is null) throw new InvalidOperationException();
        return strategy.CalculateDistance(this, other);
    }
}