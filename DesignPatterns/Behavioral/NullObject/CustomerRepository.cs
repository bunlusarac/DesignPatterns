namespace DesignPatterns.Behavioral.NullObject;

public class CustomerRepository
{
    private readonly List<ICustomer> _customers = new()
    {
        new Customer(0, "Barış"),
        new Customer(1, "Göktuğ"),
        new Customer(2, "Selen"),
        new Customer(3, "Adem")
    };

    public IEnumerable<ICustomer> GetAll() => _customers;

    public ICustomer GetById(long id)
    {
        var customer = _customers.FirstOrDefault(c => c.Id == id);
        if (customer is null) throw new InvalidOperationException();
        return customer;
    }
    
    public ICustomer GetByIdWithNullObjectSupport(long id)
    {
        var customer = _customers.FirstOrDefault(c => c.Id == id);
        return customer ?? new NullCustomer();
    }
}