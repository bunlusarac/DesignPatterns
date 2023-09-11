namespace DesignPatterns.Behavioral.NullObject;

public class NullCustomer: ICustomer
{
    public long? Id => -1;
    public string? Name => string.Empty;
}