using DesignPatterns.Behavioral.Strategy;

namespace DesignPatterns.Test.Behavioral.Strategy;

public class PointTest
{
    [Theory]
    [InlineData(3,4,0,0, 5)]
    [InlineData(-3,4,0,0, 5)]
    [InlineData(3,-4,0,0, 5)]
    [InlineData(-3,-4,0,0, 5)]
    [InlineData(4,3,0,0, 5)]
    [InlineData(-4,3,0,0, 5)]
    [InlineData(4,-3,0,0, 5)]
    [InlineData(-4,-3,0,0, 5)]
    public void Point_ShouldCalculateEuclideanDistance(double x1, double y1, double x2, double y2, double expectedDistance)
    {
        var point = new Point(x1, y1);
        var otherPoint = new Point(x2, y2);
        Assert.Equal(expectedDistance, point.CalculateDistance(otherPoint));
    }
    
    [Theory]
    [InlineData(3,4,0,0, 7)]
    [InlineData(-3,4,0,0, 7)]
    [InlineData(3,-4,0,0, 7)]
    [InlineData(-3,-4,0,0, 7)]
    [InlineData(4,3,0,0, 7)]
    [InlineData(-4,3,0,0, 7)]
    [InlineData(4,-3,0,0, 7)]
    [InlineData(-4,-3,0,0, 7)]
    public void Point_ShouldCalculateManhattanDistance(double x1, double y1, double x2, double y2, double expectedDistance)
    {
        var point = new Point(x1, y1);
        var otherPoint = new Point(x2, y2);
        Assert.Equal(expectedDistance, point.CalculateDistance(otherPoint, "manhattan"));
    }
    
    [Fact]
    public void Point_ThrowExceptionOnInvalidNorm()
    {
        var point = new Point(3, 4);
        var otherPoint = new Point(15, 7);
        Assert.Throws<InvalidOperationException>(() => point.CalculateDistance(otherPoint, "invalid"));
    }
    
    [Theory]
    [InlineData(3,4,0,0, 5)]
    [InlineData(-3,4,0,0, 5)]
    [InlineData(3,-4,0,0, 5)]
    [InlineData(-3,-4,0,0, 5)]
    [InlineData(4,3,0,0, 5)]
    [InlineData(-4,3,0,0, 5)]
    [InlineData(4,-3,0,0, 5)]
    [InlineData(-4,-3,0,0, 5)]
    public void Point_ShouldCalculateEuclideanDistanceWithStrategy(double x1, double y1, double x2, double y2, double expectedDistance)
    {
        var point = new Point(x1, y1);
        var otherPoint = new Point(x2, y2);
        Assert.Equal(expectedDistance, point.CalculateDistanceWithStrategy(otherPoint));
    }
    
    [Theory]
    [InlineData(3,4,0,0, 7)]
    [InlineData(-3,4,0,0, 7)]
    [InlineData(3,-4,0,0, 7)]
    [InlineData(-3,-4,0,0, 7)]
    [InlineData(4,3,0,0, 7)]
    [InlineData(-4,3,0,0, 7)]
    [InlineData(4,-3,0,0, 7)]
    [InlineData(-4,-3,0,0, 7)]
    public void Point_ShouldCalculateManhattanDistanceWithStrategy(double x1, double y1, double x2, double y2, double expectedDistance)
    {
        var point = new Point(x1, y1);
        var otherPoint = new Point(x2, y2);
        Assert.Equal(expectedDistance, point.CalculateDistanceWithStrategy(otherPoint, new ManhattanDistanceStrategy()));
    }
}