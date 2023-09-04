namespace DesignPatterns.Behavioral.Singleton;

public sealed class ThreadSafeSingleton{ 
    private static ThreadSafeSingleton? _instance = null; 
    private static readonly object Padlock = new();

    public static ThreadSafeSingleton Instance {
        get
        {
            lock (Padlock)
            {
                _instance ??= new ThreadSafeSingleton();
            }

            return _instance;
        }
    }
}
