namespace DesignPatterns.Behavioral.Strategy;

public class ManhattanDistanceStrategy: DistanceStrategy
{
    public override double CalculateDistance(Point point, Point other)
    {
        return Math.Abs(point.X - other.X) + Math.Abs(point.Y - other.Y);
    }
}