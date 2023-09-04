namespace DesignPatterns.Behavioral.Strategy;

public interface IDistanceStrategy
{
    public double CalculateDistance(Point point, Point other);
}