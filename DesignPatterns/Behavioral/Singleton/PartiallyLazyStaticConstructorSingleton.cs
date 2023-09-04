namespace DesignPatterns.Behavioral.Singleton;

public sealed class PartiallyLazyStaticConstructorSingleton
{
     public static PartiallyLazyStaticConstructorSingleton Instance { get; } = new();
     public static readonly string TestStaticMember = "test";

     static PartiallyLazyStaticConstructorSingleton() { }
}