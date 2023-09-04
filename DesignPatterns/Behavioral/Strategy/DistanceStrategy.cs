namespace DesignPatterns.Behavioral.Strategy;

public abstract class DistanceStrategy: IDistanceStrategy
{
    public abstract double CalculateDistance(Point point, Point other);
}