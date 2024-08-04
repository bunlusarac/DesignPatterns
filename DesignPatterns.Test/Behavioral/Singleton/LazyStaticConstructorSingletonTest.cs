using DesignPatterns.Behavioral.Singleton;

namespace DesignPatterns.Test.Behavioral.Singleton;

public class LazyStaticConstructorSingletonTest
{
    [Fact]
    public void LazyStaticConstructorSingleton_ShouldInstantiateOnce()
    {
        var inst1 = LazyStaticConstructorSingleton.Instance;
        var inst2 = LazyStaticConstructorSingleton.Instance;
        Assert.Equal(inst1.GetHashCode(), inst2.GetHashCode());
    }
    
    [Fact]
    public void LazyStaticConstructorSingleton_ShouldBeThreadSafe()
    {
        var nInstances = 3;
        var instances = new List<LazyStaticConstructorSingleton>();
        var opts = new ParallelOptions { MaxDegreeOfParallelism = nInstances };
        var range = Enumerable.Range(1, nInstances);

        Parallel.ForEach(range, opts, _ => { instances.Add(LazyStaticConstructorSingleton.Instance); });

        var hashes = instances.Select(i => i.GetHashCode());
        hashes = hashes.Distinct();
        Assert.Single(hashes);
    }

    [Fact]
    public void LazyStaticConstructorSingleton_AccessingStaticMemberShouldNotInstantiate()
    {
        var staticMember = LazyStaticConstructorSingleton.TestStaticMember;
        var instance = LazyStaticConstructorSingleton.Instance;
        Assert.NotNull(instance);
    }
}
