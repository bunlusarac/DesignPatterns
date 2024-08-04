namespace DesignPatterns.Behavioral.Singleton;

public sealed class PartiallyLazyStaticConstructorSingleton
{
     public static PartiallyLazyStaticConstructorSingleton Instance { get; } = new();
     public static readonly string TestStaticMember = "test";

     // To bypass beforeFieldInit compiler flag to run static ctor lazily.
     static PartiallyLazyStaticConstructorSingleton() { }
}