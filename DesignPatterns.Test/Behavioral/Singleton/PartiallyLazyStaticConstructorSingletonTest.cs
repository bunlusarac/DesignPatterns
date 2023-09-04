using DesignPatterns.Behavioral.Singleton;

namespace DesignPatterns.Test.Behavioral.Singleton;

public class PartiallyLazyStaticConstructorSingletonTest
{
    [Fact]
    public void PartiallyLazyStaticConstructorSingleton_ShouldInstantiateOnce()
    {
        var inst1 = PartiallyLazyStaticConstructorSingleton.Instance;
        var inst2 = PartiallyLazyStaticConstructorSingleton.Instance;
        Assert.Equal(inst1.GetHashCode(), inst2.GetHashCode());
    }
    
    [Fact]
    public void PartiallyLazyStaticConstructorSingleton_ShouldBeThreadSafe()
    {
        var nInstances = 3;
        var instances = new List<PartiallyLazyStaticConstructorSingleton>();
        var opts = new ParallelOptions { MaxDegreeOfParallelism = nInstances };
        var range = Enumerable.Range(1, nInstances);

        Parallel.ForEach(range, opts, _ => { instances.Add(PartiallyLazyStaticConstructorSingleton.Instance); });

        var hashes = instances.Select(i => i.GetHashCode());
        hashes = hashes.Distinct();
        Assert.Single(hashes);
    }

    [Fact]
    public void PartiallyLazyStaticConstructorSingleton_AccessingStaticMemberShouldInstantiate()
    {
        var staticMember = PartiallyLazyStaticConstructorSingleton.TestStaticMember;
        Assert.NotNull(PartiallyLazyStaticConstructorSingleton.Instance);
    }
}
