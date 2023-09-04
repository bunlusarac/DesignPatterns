using DesignPatterns.Behavioral.Singleton;

namespace DesignPatterns.Test.Behavioral.Singleton;

public class DoubleCheckedThreadSafeSingletonTest
{
    [Fact]
    public void DoubleCheckedThreadSafeSingleton_ShouldInstantiateOnce()
    {
        var inst1 = DoubleCheckedThreadSafeSingleton.Instance;
        var inst2 = DoubleCheckedThreadSafeSingleton.Instance;
        Assert.Equal(inst1.GetHashCode(), inst2.GetHashCode());
    }


    [Fact]
    public void DoubleCheckedThreadSafeSingleton_ShouldBeThreadSafe()
    {
        var nInstances = 3;
        var instances = new List<DoubleCheckedThreadSafeSingleton>();
        var opts = new ParallelOptions { MaxDegreeOfParallelism = nInstances };
        var range = Enumerable.Range(1, nInstances);

        Parallel.ForEach(range, opts, _ => { instances.Add(DoubleCheckedThreadSafeSingleton.Instance); });

        var hashes = instances.Select(i => i.GetHashCode());
        hashes = hashes.Distinct();
        Assert.Single(hashes);
    }
}
