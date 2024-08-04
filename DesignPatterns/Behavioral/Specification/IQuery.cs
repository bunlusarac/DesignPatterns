namespace DesignPatterns.Behavioral.Specification;

public interface IQuery<T>
{
    T Execute();
}