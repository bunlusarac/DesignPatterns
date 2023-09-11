namespace DesignPatterns.Behavioral.NullObject;

public static class CustomerHelper
{
    public static void PrintCustomerDetails(ICustomer customer)
    {
        if (customer is null) throw new InvalidOperationException();
        if (customer.Id is null) throw new InvalidOperationException();
        if (customer.Name is null) throw new InvalidOperationException();
        
        Console.WriteLine(customer.Id);
        Console.WriteLine(customer.Name);
    }
    
    public static void PrintCustomerDetailsWithoutNullChecks(ICustomer customer)
    {
        Console.WriteLine(customer.Id);
        Console.WriteLine(customer.Name);
    }
}