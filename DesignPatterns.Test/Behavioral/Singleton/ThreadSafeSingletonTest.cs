using DesignPatterns.Behavioral.Singleton;

namespace DesignPatterns.Test.Behavioral.Singleton;

public class ThreadSafeSingletonTest
{
    [Fact]
    public void ThreadSafeSingleton_ShouldInstantiateOnce()
    {
        var inst1 = ThreadSafeSingleton.Instance;
        var inst2 = ThreadSafeSingleton.Instance;
        Assert.Equal(inst1.GetHashCode(), inst2.GetHashCode());
    }


    [Fact]
    public void ThreadSafeSingleton_ShouldBeThreadSafe()
    {
        var nInstances = 3;
        var instances = new List<ThreadSafeSingleton>();
        var opts = new ParallelOptions { MaxDegreeOfParallelism = nInstances };
        var range = Enumerable.Range(1, nInstances);

        Parallel.ForEach(range, opts, _ => { instances.Add(ThreadSafeSingleton.Instance); });

        var hashes = instances.Select(i => i.GetHashCode());
        hashes = hashes.Distinct();
        Assert.Single(hashes);
    }
}
