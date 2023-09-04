namespace DesignPatterns.Behavioral.Singleton;

public sealed class DoubleCheckedThreadSafeSingleton
{
    private static DoubleCheckedThreadSafeSingleton? _instance;
    private static readonly object Padlock = new();

    public static DoubleCheckedThreadSafeSingleton Instance
    {
        get
        {
            if (_instance is not null) return _instance;
            
            lock (Padlock)
            {
                _instance ??= new DoubleCheckedThreadSafeSingleton();
            }

            return _instance;
        }
    }
}
