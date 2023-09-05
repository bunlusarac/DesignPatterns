namespace DesignPatterns.Behavioral.Singleton;

public sealed class LazySingleton
{
    //This is thread-safe.
    private static readonly Lazy<LazySingleton> Lazy = new(() => new LazySingleton());

    //This is guaranteed to never be null.
    public static LazySingleton Instance => Lazy.Value;
}