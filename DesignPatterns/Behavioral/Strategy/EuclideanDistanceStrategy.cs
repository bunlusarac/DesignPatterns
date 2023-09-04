namespace DesignPatterns.Behavioral.Strategy;

public class EuclideanDistanceStrategy: DistanceStrategy
{
    public override double CalculateDistance(Point point, Point other)
    {
        return Math.Sqrt(Math.Pow(point.X - other.X, 2) + Math.Pow(point.Y - other.Y, 2));
    }
}