using DesignPatterns.Behavioral.Singleton;

namespace DesignPatterns.Test.Behavioral.Singleton;

public class NaiveSingletonTests
{
    [Fact]
    public void NaiveSingleton_ShouldInstantiateOnce()
    {
        var inst1 = NaiveSingleton.Instance;
        var inst2 = NaiveSingleton.Instance;

        Assert.Equal(inst1.GetHashCode(), inst2.GetHashCode());
    }

    [Fact]
    public void NaiveSingleton_ShouldNotReturnNullWhenUninstantiated()
    {
        Assert.NotNull(NaiveSingleton.Instance);
    }

    [Fact]
    public void NaiveSingleton_ShouldNotBeThreadSafe()
    {
        var nInstances = 3;
        var instances = new List<NaiveSingleton>();
        var opts = new ParallelOptions { MaxDegreeOfParallelism = nInstances };
        var range = Enumerable.Range(1, nInstances);
        
        Parallel.ForEach(range,  opts, _ => { instances.Add(NaiveSingleton.Instance); });

        var hashes = instances.Select(i => i.GetHashCode());
        hashes = hashes.Distinct();
        Assert.Equal(nInstances,hashes.Count());
    }
}