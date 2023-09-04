namespace DesignPatterns.Behavioral.Singleton;

public sealed class NaiveSingleton
{
    private static NaiveSingleton? _instance;

    public static NaiveSingleton Instance = _instance ??= new NaiveSingleton();
}