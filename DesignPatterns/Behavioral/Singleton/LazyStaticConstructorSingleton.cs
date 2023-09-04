namespace DesignPatterns.Behavioral.Singleton;

public sealed class LazyStaticConstructorSingleton
{
    public static readonly string TestStaticMember = "test";

    public static LazyStaticConstructorSingleton Instance => Nested.Instance;

    private class Nested
    {
        static Nested() {}
        internal static readonly LazyStaticConstructorSingleton Instance = new();
    }
}