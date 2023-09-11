namespace DesignPatterns.Behavioral.NullObject;

public class Customer: ICustomer
{
    public long? Id { get; }
    public string? Name { get; }

    public Customer(long? id, string? name)
    {
        Id = id;
        Name = name;
    }
}